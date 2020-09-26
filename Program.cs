using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Threading;

namespace Organization {
    class Program {

        static void Main(string[] args) {

            //TitleAnimation("ОРГАНИЗАЦИЯ", ConsoleColor.DarkCyan); // анимация заголовка
            //Console.Clear();

            // Вывод меню (+создание примера организации)
            Menu();



            //// Создаем организацию
            //Organization organization = CreateStructureOrganization();

            //Console.WriteLine(organization.Departments[0].returnEmplAtId(9));


            //organization.printSortedEmployees(FIELDSORT.AGE);

        }


        /// <summary>
        /// Вывод главного меню программы
        /// </summary>
        static public void Menu() {

            // Создаем организацию
            Organization organization = CreateStructureOrganization();

            int choice = 0;

            do {    // бесконечный цикл (до выхода пользователя из программы)

                do {
                    Console.Clear();
                    Console.WriteLine("========================================================");
                    Console.WriteLine("                    ГЛАВНОЕ МЕНЮ:");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("1 - Добавить отдел в организацию;");
                    Console.WriteLine("2 - Добавить должность в отдел;");
                    Console.WriteLine("3 - Добавить сотрудника и назначить на должность;");
                    Console.WriteLine("4 - Удалить сотрудника из отдела;");
                    Console.WriteLine("5 - Вывести упорядоченный список сотрудников организации;");
                    Console.WriteLine("6 - Добавить новый проект для сотрудника;");
                    Console.WriteLine("7 - Вывод информации об организации;");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("8 - Импорт информации в xml;");
                    Console.WriteLine("9 - Импорт информации в json;");
                    Console.WriteLine("10 - Экспорт информации из xml;");
                    Console.WriteLine("11 - Экспорт информации из json;");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("12 - Выйти из программы.");
                    Console.WriteLine("========================================================");
                    Console.WriteLine();

                    Console.Write("Выберите пункт: ");
                    int.TryParse(Console.ReadLine(), out choice);
                } while (choice < 1 || choice > 12);

                Console.Clear();

                switch (choice) {
                    case 1: // выбран пункт "Добавить отдел в организацию"
                        string depName;

                        Console.Write("Введите название департамента (отдела): ");
                        depName = Console.ReadLine();


                        organization.addDepartment(new Department(depName));

                        continue;

                    case 2: // выбран пункт "Добавить должность в отдел"
                        string depPostName;
                        uint depPostSalary;
                        
                        Console.Clear();

                        foreach (Department depTmp in organization.returnDeps()) {
                            Console.WriteLine($"{depTmp.Name}");
                        }

                        Console.WriteLine();

                        do {
                            Console.Write("Введите наименование отдела в который необходимо добавить новую должность: ");
                            depName = Console.ReadLine();
                        } while (!organization.isIncludDep(depName));

                        Console.WriteLine();
                        Console.Write("Введите название новой должности в отделе: ");
                        depPostName = Console.ReadLine();
                        Console.Write($"Введите зарплату по должности \"{depPostName}\": ");
                        uint.TryParse(Console.ReadLine(), out depPostSalary);

                        organization.returnDepAtName(depName).addPost(new Position(depPostName, depPostSalary));

                        continue;

                    case 3: // выбран пункт "Добавить сотрудника и назначить на должность"

                        Console.Write("Введите имя нового сотрудника: ");
                        string nameEmpl = Console.ReadLine();
                        Console.Write("Введите фамилию нового сотрудника: ");
                        string famEmpl = Console.ReadLine();
                        Console.Write("Введите отчество нового сотрудника: ");
                        string sirEmpl = Console.ReadLine();
                        Console.Write("Укажите дату рождения нового сотрудника (дд.мм.гггг): ");
                        DateTime birth;
                        DateTime.TryParse(Console.ReadLine(), out birth);

                        Console.Clear();

                        foreach (Department depTmp in organization.returnDeps()) {
                            Console.WriteLine($"{depTmp.Name}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Введите наименование отдела в который необходимо добавить нового сотрудника на должность: ");

                        do {
                            depName = Console.ReadLine();
                        } while (!organization.isIncludDep(depName));

                        Console.Clear();

                        if (!String.IsNullOrEmpty(organization.returnDepAtName(depName).returnVacant())) {
                            Console.WriteLine(organization.returnDepAtName(depName).returnVacant());  // вывод информации о вакантных должностях
                            Console.WriteLine();

                            Console.WriteLine("Введите идентификатор вакантной должности на которую необходимо назначить нового сотрудника: ");
                            uint idPost;

                            do {
                                uint.TryParse(Console.ReadLine(), out idPost);
                            } while (!organization.returnDepAtName(depName).isIncludAndVacant(idPost));


                            // Назначаем нового сотрудника на должность!
                            organization.returnDepAtName(depName).addEmpl(new Employee(nameEmpl, famEmpl, sirEmpl, birth,
                                                                organization.returnDepAtName(depName).returnPostAtId(idPost)));
                        } else {
                            Console.WriteLine($"Вакантных должностей в отделе \"{depName}\" нет!");
                            Console.ReadKey();
                        }

                        continue;

                    case 4: // выбран пункт "Удалить сотрудника из отдела"

                        foreach (Department depTmp in organization.returnDeps()) {
                            Console.WriteLine($"{depTmp.Name}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Введите наименование отдела в котором необходимо уволить сотрудника: ");

                        do {
                            depName = Console.ReadLine();
                        } while (!organization.isIncludDep(depName));

                        Console.Clear();

                        foreach (Employee emp in organization.returnDepAtName(depName).returnEmpls()) {
                            Console.WriteLine(emp.ToString());
                        }

                        Console.WriteLine();

                        uint idEmp;

                        do {
                            Console.Write("Введите идентификатор сотрудника, которого необходимо уволить: ");
                            uint.TryParse(Console.ReadLine(), out idEmp);
                        } while (organization.returnDepAtName(depName).returnEmplAtId(idEmp) == null);


                        organization.returnDepAtName(depName).delEmpl(organization.returnDepAtName(depName).returnEmplAtId(idEmp));

                        continue;

                    case 5: // выбран пункт "Вывести упорядоченный список сотрудников организации"

                        do {
                            Console.Clear();
                            Console.WriteLine("==========================================================");
                            Console.WriteLine("                  КРИТЕРИЙ СОРТИРОВКИ: ");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine("1 - По возрасту;");
                            Console.WriteLine("2 - По возрасту и зарплате;");
                            Console.WriteLine("3 - По возрасту и зарплате (в рамках одного департамента);");
                            Console.WriteLine("4 - По идентификатору сотрудника;");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine("5 - В главное меню.");
                            Console.WriteLine("==========================================================");

                            Console.WriteLine();
                            Console.Write("Выберите пункт: ");
                            int.TryParse(Console.ReadLine(), out choice);
                        } while (choice < 1 || choice > 5);

                        Console.Clear();

                        switch (choice) {
                            case 1:
                                organization.printSortedEmployees(FIELDSORT.AGE);

                                break;

                            case 2:
                                organization.printSortedEmployees(FIELDSORT.AGE_SALARY);

                                break;

                            case 3:
                                organization.printSortedEmployees(FIELDSORT.DEP_AGE_SALARY);

                                break;

                            case 4:
                                organization.printSortedEmployees(FIELDSORT.ID);

                                break;

                            case 5:

                                continue;

                        }

                        continue;

                    case 6: // выбран пункт "Добавить новый проект для сотрудника"

                        foreach (Department depTmp in organization.returnDeps()) {
                            Console.WriteLine($"{depTmp.Name}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Введите наименование отдела в котором сотруднику необходимо назначить проект: ");

                        do {
                            depName = Console.ReadLine();
                        } while (!organization.isIncludDep(depName));

                        Console.Clear();

                        foreach (Employee emp in organization.returnDepAtName(depName).returnEmpls()) {
                            Console.WriteLine(emp.ToString());
                        }

                        Console.WriteLine();

                        Console.Write("Введите идентификатор сотрудника, которому необходимо назначить новый проект: ");
                        uint.TryParse(Console.ReadLine(), out idEmp);

                        Console.Clear();

                        Console.Write("Введите название проекта: ");
                        string prjName = Console.ReadLine();

                        Console.Write("Введите дату начала проекта: ");
                        DateTime prjDateBegin;
                        DateTime.TryParse(Console.ReadLine(), out prjDateBegin);

                        Console.Write("Введите дату окончания проекта: ");
                        DateTime prjDateEnd;
                        DateTime.TryParse(Console.ReadLine(), out prjDateEnd);

                        Console.Write("Введите описание проекта: ");
                        string prjDescr = Console.ReadLine();

                        organization.returnDepAtName(depName).returnEmplAtId(idEmp).addProject(new Project(prjName, prjDateBegin, prjDateEnd, prjDescr));


                        continue;

                    case 7: // выбран пункт "Вывод информации об организации"
                        organization.printInfo();

                        continue;

                    case 8: // выбран пункт "Импорт информации в xml"

                        //Project proj = new Project("Проект", DateTime.Now, DateTime.Now.AddDays(5), "Описание");

                        // Создаем сериализатор на основе указанного типа 
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Organization));

                        // Создаем поток для сохранения данных
                        Stream fStream = new FileStream("organization.xml", FileMode.Create, FileAccess.Write);

                        // Запускаем процесс сериализации
                        xmlSerializer.Serialize(fStream, organization);

                        // Закрываем поток
                        fStream.Close();

                        continue;

                    case 9: // выбран пункт "Импорт информации в json"
                        

                        continue;

                    case 10: // выбран пункт "Экспорт информации из xml"


                        //ДЕЛАТЬ ЗАПРОС НА РЕЗЕРВНУЮ КОПИЮ!!! (файл organization_DateTime.Now.xml)


                        continue;

                    case 11: // выбран пункт "Экспорт информации из json"


                        //ДЕЛАТЬ ЗАПРОС НА РЕЗЕРВНУЮ КОПИЮ!!! (файл organization_DateTime.Now.json)


                        continue;

                    case 12: // выбран пункт "Выйти"
                        return;
                }

            } while (true);
        }




        /// <summary>
        /// Создаем организацию (для проверки)
        /// </summary>
        /// <returns>Организация</returns>
        static Organization CreateStructureOrganization() {
            // В организации 7 должностей
            Position pos1 = new Position("Генеральный директор", 250000);
            Position pos2 = new Position("Менеджер", 90000);
            Position pos3 = new Position("Бухгалтер", 110000);
            Position pos4 = new Position("Ведущий инженер", 150000);
            Position pos5 = new Position("Старший программист", 140000);
            Position pos6 = new Position("Программист", 110000);
            Position pos7 = new Position("Программист", 120000);
            Position pos8 = new Position("Программист", 130000);
            Position pos9 = new Position("Стажер", 10000);
            Position pos10 = new Position("Стажер", 10500);

            List<Position> posLstMng = new List<Position>();
            posLstMng.Add(pos1);
            posLstMng.Add(pos2);
            posLstMng.Add(pos3);
            posLstMng.Add(pos4);

            List<Position> posLstJob = new List<Position>();
            posLstJob.Add(pos5);
            posLstJob.Add(pos6);
            posLstJob.Add(pos7);
            posLstJob.Add(pos8);
            posLstJob.Add(pos9);
            posLstJob.Add(pos10);


            // В организации 3 проекта
            Project pr1 = new Project("Проект раз", DateTime.Now, new DateTime(2021, 01, 01), "Подробное описание проекта раз");
            Project pr2 = new Project("Проект два", DateTime.Now, new DateTime(2021, 01, 01), "Подробное описание проекта два");
            Project pr3 = new Project("Проект три", DateTime.Now, new DateTime(2021, 01, 01), "Подробное описание проекта три");

            List<Project> prLst = new List<Project>();
            prLst.Add(pr1);
            prLst.Add(pr2);
            prLst.Add(pr3);


            // В организации 6 сотрудников
            Employee emp1 = new Employee("васиЛий", "пУпкИн", "петровиЧ", DateTime.Parse("01.07.1971"), pos1, prLst);
            Employee emp2 = new Employee("Иван", "иванов", "иванович", DateTime.Parse("01.01.1985"), pos2, pr1);
            Employee emp3 = new Employee("Вера", "Бухгалтерова", "Сергеевна", DateTime.Parse("21.01.1965"), pos3);
            Employee emp4 = new Employee("Сидр", "Старший", "Сидорович", DateTime.Parse("24.05.1975"), pos5, prLst);
            Employee emp5 = new Employee("Иван", "Разов", "Иванович", DateTime.Parse("01.01.1991"), pos6);
            Employee emp6 = new Employee("Сергей", "Двоев", "Сергеевич", DateTime.Parse("02.01.1991"), pos7);
            Employee emp7 = new Employee("Стажеркин", "Геннадий", "Геннадьевич", DateTime.Parse("15.05.2000"), pos9);

            emp5.addProject(pr1);
            emp5.addProject(pr2);
            emp6.addProject(pr3);

            List<Employee> lstEmpMng = new List<Employee>();
            lstEmpMng.Add(emp1);
            lstEmpMng.Add(emp2);
            lstEmpMng.Add(emp3);

            List<Employee> lstEmpJob = new List<Employee>();
            lstEmpJob.Add(emp4);
            lstEmpJob.Add(emp5);
            lstEmpJob.Add(emp6);
            lstEmpJob.Add(emp7);

            // В организации 2 отдела
            Department depMng = new Department("Отдел управления", posLstMng, lstEmpMng);
            Department depJob = new Department("Отдел зарабатывания", posLstJob, lstEmpJob);

            List<Department> lstDeps = new List<Department>();
            lstDeps.Add(depMng);
            lstDeps.Add(depJob);

            // Создание организации
            Organization organization = new Organization("ОРГАНИЗАЦИЯ", lstDeps);

            // Возвращаем созданную организацию
            return organization;
        }


        /// <summary>
        /// Заставка (анимация) заголовка
        /// </summary>
        static void TitleAnimation(string logo, ConsoleColor fontColor = ConsoleColor.Green) {

            const int DistX = 10;   // отдаленность букв по горизонтали от центра
            const int DistY = 5;    // отдаленность букв по вертикали от центра

            int centerX = Console.WindowWidth / 2;  // центр консоли
            int centerY = Console.WindowHeight / 2; // центр консоли
            int posX = 0;  // смещение курсора по горизонтали 
            int posY = 0;  // смещение курсора по вертикали

            Console.ForegroundColor = fontColor;
            Console.CursorVisible = false;

            if (logo.Length > 6) {

                do {

                    System.Threading.Thread.Sleep(50);
                    Console.Clear();

                    // Р
                    Console.SetCursorPosition(centerX - DistX + 1 + posX, centerY - DistY + posY);
                    Console.Write(logo.Substring(1, 1));

                    // О
                    Console.SetCursorPosition(centerX - DistX + posX, centerY);
                    Console.Write(logo.Substring(0, 1));

                    // Г
                    Console.SetCursorPosition(centerX - DistX + 2 + posX, centerY + DistY - posY);
                    Console.Write(logo.Substring(2, 1));


                    // АНИЗА
                    for (int i = 0; i < logo.Length - 6; ++i) {
                        if (i % 2 == 0) {
                            Console.SetCursorPosition(centerX - 2 + i, centerY - DistY + posY);
                            Console.Write(logo.Substring(3 + i, 1));
                        }
                        else {
                            Console.SetCursorPosition(centerX - 2 + i, centerY + DistY - posY);
                            Console.Write(logo.Substring(3 + i, 1));
                        }
                    }

                    // Ц
                    Console.SetCursorPosition(centerX + DistX - 2 - posX, centerY - DistY + posY);
                    Console.Write(logo.Substring(logo.Length - 3, 1));

                    // Я
                    Console.SetCursorPosition(centerX + DistX - posX, centerY);
                    Console.Write(logo.Substring(logo.Length - 1, 1));

                    // И
                    Console.SetCursorPosition(centerX + DistX - 1 - posX, centerY + DistY - posY);
                    Console.Write(logo.Substring(logo.Length - 2, 1));

                    // Начальная задержка
                    if (posX == 0 && posY == 0) System.Threading.Thread.Sleep(1000);

                    if (posX > DistX - 1 || posY > DistY - 1) break;

                    posX += 1;
                    posY += 1;

                } while (true);

            } else {
                Console.SetCursorPosition(centerX - logo.Length / 2, centerY - 1);
                Console.WriteLine(logo);
            }

            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

            System.Threading.Thread.Sleep(2000);

            Console.ResetColor();
            Console.CursorVisible = true;

        }
    }
}
