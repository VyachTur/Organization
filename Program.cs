using System;
using System.Collections.Generic;

namespace Organization {
    class Program {
        static void Main(string[] args) {

            Position pos = new Position("Технический специалист", 120000);
            Project pr1 = new Project("Проект раз", DateTime.Now, new DateTime(2021, 01, 01), "Подробное описание проекта раз");
            Project pr2 = new Project("Проект два", DateTime.Now, new DateTime(2021, 01, 01), "Подробное описание проекта два");

            List<Project> prLst = new List<Project>();
            prLst.Add(pr1);
            prLst.Add(pr2);

            Employee emp = new Employee("васиЛий", "пУпкИн", "петровиЧ", DateTime.Parse("01.07.1986"), pos, prLst);

            Console.WriteLine(emp.returnEmployeeInfo());
            Console.WriteLine(emp.Age);
            Console.WriteLine(emp.CountProjects);
            Console.WriteLine();


            ////Console.WriteLine(pr.returnProjectInfo());

            //emp.addProject(pr);
            //Console.WriteLine(emp.returnEmployeeInfo());

            //Position pos = new Position("Технический специалист", 120000);
            //Console.WriteLine(pos.returnPositionInfo());

        }
    }
}
