using System;

namespace Organization {
    class Program {
        static void Main(string[] args) {
            Employee emp = new Employee("васиЛий", "пУпкИн", "петровиЧ", DateTime.Parse("01.07.1986"));

            Console.WriteLine(emp.returnEmployeeInfo());
            Console.WriteLine(emp.Age);
            Console.WriteLine(emp.CountProjects);
            Console.WriteLine();

            Project pr = new Project("Проект раз", DateTime.Now, new DateTime(2021, 01, 01), "Подробное описание проекта раз");

            //Console.WriteLine(pr.returnProjectInfo());

            emp.addProject(pr);
            Console.WriteLine(emp.returnEmployeeInfo());

        }
    }
}
