using System;
using System.Collections.Generic;

namespace Organization {
    class Program {

        static void Main(string[] args) {

            //TitleAnimation("ОРГАНИЗАЦИЯ", ConsoleColor.DarkCyan); // анимация заголовка


            // В организации 7 должностей
            Position pos1 = new Position("Генеральный директор", 200000);
            Position pos2 = new Position("Менеджер", 90000);
            Position pos3 = new Position("Бухгалтер", 110000);
            Position pos4 = new Position("Ведущий инженер", 150000);
            Position pos5 = new Position("Старший программист", 140000);
            Position pos6 = new Position("Программист", 120000);
            Position pos7 = new Position("Программист", 120000);

            List<Position> posLstMng = new List<Position>();
            posLstMng.Add(pos1);
            posLstMng.Add(pos2);
            posLstMng.Add(pos3);
            posLstMng.Add(pos4);

            List<Position> posLstJob = new List<Position>();
            posLstJob.Add(pos5);
            posLstJob.Add(pos6);
            posLstJob.Add(pos7);


            // В организации 3 проекта
            Project pr1 = new Project("Проект раз", DateTime.Now, new DateTime(2021, 01, 01), "Подробное описание проекта раз");
            Project pr2 = new Project("Проект два", DateTime.Now, new DateTime(2021, 01, 01), "Подробное описание проекта два");
            Project pr3 = new Project("Проект три", DateTime.Now, new DateTime(2021, 01, 01), "Подробное описание проекта три");

            List<Project> prLst = new List<Project>();
            prLst.Add(pr1);
            prLst.Add(pr2);
            prLst.Add(pr3);


            // В организации 6 сотрудников
            Employee emp1 = new Employee("васиЛий", "пУпкИн", "петровиЧ", DateTime.Parse("01.07.1986"), pos1, prLst);
            Employee emp2 = new Employee("Иванов", "иван", "иванович", DateTime.Parse("01.01.1985"), pos2, pr1);
            Employee emp3 = new Employee("Бухгалтерова", "Вера", "Сергеевна", DateTime.Parse("21.01.1965"), pos3);
            Employee emp4 = new Employee("Старший", "Сидр", "Сидорович", DateTime.Parse("24.05.1975"), pos5, prLst);
            Employee emp5 = new Employee("Разов", "Иван", "Иванович", DateTime.Parse("01.01.1991"), pos6);
            Employee emp6 = new Employee("Двоев", "Сергей", "Сергеевич", DateTime.Parse("02.02.1992"), pos7);
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

            // В организации 2 отдела
            Department depMng = new Department("Отдел управления", posLstMng, lstEmpMng);
            Department depJob = new Department("Отдел зарабатывания", posLstJob, lstEmpJob);

            List<Department> lstDeps = new List<Department>();
            lstDeps.Add(depMng);
            lstDeps.Add(depJob);

            // Создание организации
            Organization organization = new Organization("ОРГАНИЗАЦИЯ", lstDeps);


            //Console.WriteLine(organization.returnOrganizationInfo());
            Console.WriteLine(organization.returnDeps()[0].returnDepartmentInfo());



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

            if (logo.Length > 6) {

                do {

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

                    System.Threading.Thread.Sleep(150);

                } while (true);

            } else {
                Console.SetCursorPosition(centerX - logo.Length / 2, centerY - 1);
                Console.WriteLine(logo);
            }

            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);

            Console.ReadKey();

            Console.ResetColor();

        }
    }
}
