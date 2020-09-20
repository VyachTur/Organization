using System;
using System.Collections.Generic;

namespace Organization {

    /// <summary>
    /// Структура реализующая организацию
    /// </summary>
    struct Organization {

        #region Constructors

        /// <summary>
        /// Конструктор (1)
        /// </summary>
        /// <param name="name">Наименование организации</param>
        /// <param name="departs">Департаменты (отделы) в организации</param>
        public Organization(string name, List<Department> departs) {
            this.Id = ++Count_Org;
            this.Name = name;
            this.departs_Org = departs;
        }

        /// <summary>
        /// Конструктор (2)
        /// </summary>
        /// <param name="name">Наименование организации</param>
        /// <param name="depart">Департамент (отдел) в организации</param>
        public Organization(string name, Department depart) {
            this.Id = ++Count_Org;
            this.Name = name;

            this.departs_Org = new List<Department>();
            this.departs_Org.Add(depart);
        }

        #endregion // Constructors



        #region Methods

        /// <summary>
        /// Добавляет отдел в организацию
        /// </summary>
        /// <param name="dep">Отдел</param>
        public void addDepartment(Department dep) {
            this.departs_Org.Add(dep);
        }

        /// <summary>
        /// Удаляет отдел из организации
        /// </summary>
        /// <param name="dep">Отдел</param>
        public void delDepartment(Department dep) {
            // Если элемент есть в списке, то удаляем его
            if (this.departs_Org.Contains(dep)) this.departs_Org.Remove(dep);
        }

        /// <summary>
        /// Возвращает список отделов организации
        /// </summary>
        /// <returns>Список отделов</returns>
        public List<Department> returnDeps() {
            return this.departs_Org;

        }

        /// <summary>
        /// Информация об организации
        /// </summary>
        /// <returns>String: Id, Name, CountDeparts</returns>
        public string returnOrganizationInfo() {
            return $"| Идентификатор организации: { this.Id } | Наименование организации: { this.Name } | Количество отделов: { this.CountDeparts } |";
        }


        /// <summary>
        /// Вывод подробной информации об организации на экран консоли
        /// </summary>
        public void printInfo() {
            int i = 0;  // счетчик для вывода номера по порядку

            Console.WriteLine($"| {"№", 2} | {"Имя", 10} | {"Фамилия", 15} | {"Возраст", 7} |" +
                                $"{"Департамент", 20} | {"Оплата труда", 12} | {"Кол-во проектов", 15} |");

            Console.WriteLine("------------------------------------------------------------------------------------------------------");

            foreach (Department currDep in departs_Org) {
                foreach (Employee currEmp in currDep.returnEmpls()) {

                    Console.WriteLine($"| {++i, 2} | {currEmp.Name, 10} | {currEmp.Family, 15} | {currEmp.Age, 7} |" +
                                $"{currDep.Name, 20} | {currEmp.Post.Salary, 12} | {currEmp.CountProjects, 15} |");

                }
            }
        
        
        }

        #endregion // Methods



        #region Properties

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        public uint Id { get; private set; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Количество отделов в организации
        /// </summary>
        public int CountDeparts {
            get {
                return this.departs_Org == null ? 0 : this.departs_Org.Count;
            }
        }


        #endregion // Properties



        #region Fields

        private List<Department> departs_Org;   // департаменты (отделы) в организцаии
        private static uint Count_Org = 0;      // счетчик организаций для идентификатора

        #endregion // Fields

    }
}
