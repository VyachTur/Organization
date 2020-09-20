using System;
using System.Collections.Generic;

namespace Organization {

    /// <summary>
    /// Структура реализующая департамент (отдел)
    /// </summary>
    struct Department {
        const int MaxEmployeesInDep = 1_000_000;    // максимальное количество сотрудников в одном департаменте (отделе)

        #region Constructors

        /// <summary>
        /// Конструктор (1.1)
        /// </summary>
        /// <param name="name">Название департамента (отдела)</param>
        /// <param name="posts">Список должностей</param>
        /// <param name="empls">Список сотрудников</param>
        public Department(string name, List<Position> posts, List<Employee> empls) {
            this.Id = ++Count_Dep;
            this.CreateDate = DateTime.Now;
            this.Name = name;
            this.positions_Dep = posts;

            // Каждый департамент может состоять не более чем из 1_000_000 сотрудников!
            if (empls.Count < MaxEmployeesInDep) {
                this.employees_Dep = empls;
            } else {
                this.employees_Dep = null;
            }
        }

        /// <summary>
        /// Конструктор (1.2)
        /// </summary>
        /// <param name="name">Название департамента (отдела)</param>
        /// <param name="posts">Список должностей</param>
        public Department(string name, List<Position> posts) : this(name, posts, null) { }

        /// <summary>
        /// Конструктор (2.1)
        /// </summary>
        /// <param name="name">Название департамента (отдела)</param>
        /// <param name="post">Должность в департаменте (отделе)</param>
        /// <param name="emp">Сотрудник департамента (отдела)</param>
        public Department(string name, Position post, Employee emp) {
            this.Id = ++Count_Dep;
            this.CreateDate = DateTime.Now;
            this.Name = name;

            this.positions_Dep = new List<Position>();
            this.positions_Dep.Add(post);

            this.employees_Dep = new List<Employee>();
            this.employees_Dep.Add(emp);
        }

        /// <summary>
        /// Конструктор (2.2)
        /// </summary>
        /// <param name="name">Название департамента (отдела)</param>
        /// <param name="post">Должность в департаменте (отделе)</param>
        public Department(string name, Position post) : this(name, post, new Employee()) { }



        /// <summary>
        /// Конструктор (3)
        /// </summary>
        /// <param name="name">Название департамента (отдела)</param>
        /// <param name="posts">Список должностей в департаменте (отделе)</param>
        /// <param name="emp">Сотрудник департамента (отдела)</param>
        public Department(string name, List<Position> posts, Employee emp) {
            this.Id = ++Count_Dep;
            this.CreateDate = DateTime.Now;
            this.Name = name;

            this.positions_Dep = posts;

            this.employees_Dep = new List<Employee>();
            this.employees_Dep.Add(emp);
        }

        #endregion // Constructors



        #region Methods

        /// <summary>
        /// Добавляем должность в отдел
        /// </summary>
        /// <param name="post">Должность</param>
        public void addPost(Position post) {
            this.positions_Dep.Add(post);
        }

        /// <summary>
        /// Сокращение должности в отделе
        /// </summary>
        /// <param name="post">Должность</param>
        public void delPost(Position post) {
            // Если элемент есть в списке, то удаляем его
            if (this.positions_Dep.Contains(post)) this.positions_Dep.Remove(post);
        }

        /// <summary>
        /// Добавляем сотрудника в отдел
        /// </summary>
        /// <param name="empl">Сотрудник</param>
        public void addEmpl(Employee empl) {
            // Каждый департамент может состоять не более чем из 1_000_000 сотрудников!
            if (employees_Dep.Count < MaxEmployeesInDep) {
                this.employees_Dep.Add(empl);
            }
        }

        /// <summary>
        /// Увольнение сотрудника из отдела
        /// </summary>
        /// <param name="empl">Сотрудник</param>
        public void delEmpl(Employee empl) {
            if (this.employees_Dep.Contains(empl)) this.employees_Dep.Remove(empl);
        }

        /// <summary>
        /// Возвращает список должностей в отделе
        /// </summary>
        /// <returns>Список должностей</returns>
        public List<Position> returnPosts() {
            return this.positions_Dep;
        }

        /// <summary>
        /// Возвращает список сотрудников в отделе
        /// </summary>
        /// <returns>Список сотрудников</returns>
        public List<Employee> returnEmpls() {
            return this.employees_Dep;
        }

        /// <summary>
        /// Информация об отделе
        /// </summary>
        /// <returns>String: Id, Name, CountPositions</returns>
        public string returnDepartmentInfo() {
            return $"| Идентификатор отдела: { this.Id } | Название отдела: { this.Name } | Количество должностей: { this.CountPositions } | Количество сотрудников: { this.CountEmployees } |";
        }

        #endregion // Methods



        #region Properties

        /// <summary>
        /// Идентификатор департамента (отдела)
        /// </summary>
        public uint Id { get; private set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        public string Name { get; set; }

        public DateTime CreateDate { get; private set; }

        /// <summary>
        /// Количество должностей в отделе
        /// </summary>
        public int CountPositions {
            get {
                return this.positions_Dep == null ? 0 : this.positions_Dep.Count;
            }
        }

        /// <summary>
        /// Количество сотрудников в отделе
        /// </summary>
        public int CountEmployees {
            get {
                return this.employees_Dep == null ? 0 : this.employees_Dep.Count;
            }
        }

        #endregion // Properties



        #region Fields

        private List<Position> positions_Dep;   // должности в департаменте (отделе)
        private List<Employee> employees_Dep;   // сотрудники департамента (отдела)

        private static uint Count_Dep = 0;  // счетчик для идентификатора департамента

        #endregion // Fields

    }
}
