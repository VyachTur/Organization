﻿using System;
using System.Collections.Generic;

namespace Organization {
    class Program {

        static void Main(string[] args) {

            //TitleAnimation("ОРГАНИЗАЦИЯ", ConsoleColor.DarkCyan); // анимация заголовка
            //Console.Clear();

            // Вывод меню (+создание примера организации)
            Menu();




            //// Создаем организацию
            //Organization organization = CreateStructureOrganization();

            //organization.printInfo();


            //Console.WriteLine(organization.returnOrganizationInfo());
            //Console.WriteLine(organization.returnDeps()[0].returnDepartmentInfo());

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
                    Console.WriteLine("3 - Добавить сотрудника в отдел;");
                    Console.WriteLine("4 - Назначить сотрудника на должность;");
                    Console.WriteLine("5 - Удалить сотрудника из отдела;");
                    Console.WriteLine("6 - Упорядочить сотрудников в организации;");
                    Console.WriteLine("7 - Вывод информации об организации;");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("8 - Добавить новый проект;");
                    Console.WriteLine("9 - Назначить проект сотруднику;");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("10 - Импорт информации в xml;");
                    Console.WriteLine("11 - Импорт информации в json;");
                    Console.WriteLine("12 - Экспорт информации из xml;");
                    Console.WriteLine("13 - Экспорт информации из json;");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("14 - Выйти из программы.");
                    Console.WriteLine("========================================================");
                    Console.WriteLine();

                    Console.Write("Выберите пункт: ");
                    int.TryParse(Console.ReadLine(), out choice);
                } while (choice < 1 || choice > 14);

                Console.Clear();

                switch (choice) {
                    case 1: // выбран пункт "Добавить отдел в организацию"


                        continue;

                    case 2: // выбран пункт "Добавить должность в отдел"


                        continue;

                    case 3: // выбран пункт "Добавить сотрудника в отдел"

                        

                        continue;

                    case 4: // выбран пункт "Назначить сотрудника на должность"


                        continue;

                    case 5: // выбран пункт "Удалить сотрудника из отдела"


                        continue;

                    case 6: // выбран пункт "Упорядочить сотрудников в организации"


                        continue;

                    case 7: // выбран пункт "Вывод информации об организации"
                        organization.printInfo();

                        continue;

                    case 8: // выбран пункт "Добавить новый проект"


                        continue;

                    case 9: // выбран пункт "Назначить проект сотруднику"


                        continue;

                    case 10: // выбран пункт "Импорт информации в xml"


                        continue;

                    case 11: // выбран пункт "Импорт информации в json"


                        continue;

                    case 12: // выбран пункт "Экспорт информации из xml"


                        continue;

                    case 13: // выбран пункт "Экспорт информации из json"


                        continue;

                    case 14: // выбран пункт "Выйти"
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
            Employee emp2 = new Employee("Иван", "иванов", "иванович", DateTime.Parse("01.01.1985"), pos2, pr1);
            Employee emp3 = new Employee("Вера", "Бухгалтерова", "Сергеевна", DateTime.Parse("21.01.1965"), pos3);
            Employee emp4 = new Employee("Сидр", "Старший", "Сидорович", DateTime.Parse("24.05.1975"), pos5, prLst);
            Employee emp5 = new Employee("Иван", "Разов", "Иванович", DateTime.Parse("01.01.1991"), pos6);
            Employee emp6 = new Employee("Сергей", "Двоев", "Сергеевич", DateTime.Parse("02.02.1992"), pos7);
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
            depMng.addPost(pos4);   // добавляем в "Отдел управления" должность "Ведущий инженер"

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
