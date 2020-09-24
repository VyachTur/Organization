using System;
using System.Collections.Generic;

namespace Organization {

    /// <summary>
    /// Структура реализующая департамент (отдел)
    /// </summary>
    public class Department {
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
                foreach (Employee emp in empls) {
                    emp.Dep = this;
                }
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
        //public Department(string name, List<Position> posts) : this(name, posts, null) { }


        /// <summary>
        /// Конструктор (2)
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
            emp.Dep = this;
            this.employees_Dep.Add(emp);
        }


        /// <summary>
        /// Конструктор (3)
        /// </summary>
        /// <param name="name">Название департамента (отдела)</param>
        /// <param name="post">Должность в департаменте (отделе)</param>
        public Department(string name, Position post) {
            this.Id = ++Count_Dep;
            this.CreateDate = DateTime.Now;
            this.Name = name;

            this.positions_Dep = new List<Position>();
            this.positions_Dep.Add(post);

            this.employees_Dep = null;
        }


        /// <summary>
        /// Конструктор (4)
        /// </summary>
        /// <param name="name">Название департамента (отдела)</param>
        public Department(string name) {
            this.Id = ++Count_Dep;
            this.CreateDate = DateTime.Now;
            this.Name = name;

            this.positions_Dep = null;

            this.employees_Dep = null;
        }


        /// <summary>
        /// Конструктор (5)
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
            emp.Dep = this;
            this.employees_Dep.Add(emp);
        }

        #endregion // Constructors



        #region Methods

        /// <summary>
        /// Добавляем должность в отдел
        /// </summary>
        /// <param name="post">Должность</param>
        public void addPost(Position post) {
            if (this.positions_Dep == null) {
                this.positions_Dep = new List<Position>();
            }

            this.positions_Dep.Add(post);
        }

        /// <summary>
        /// Сокращение должности в отделе
        /// </summary>
        /// <param name="post">Должность</param>
        public void delPost(ref Position post) {
            if (this.positions_Dep != null) {
                // Если элемент есть в списке, то удаляем его
                if (this.positions_Dep.Contains(post)) this.positions_Dep.Remove(post);
            }
        }

        /// <summary>
        /// Добавляем сотрудника в отдел
        /// </summary>
        /// <param name="empl">Сотрудник</param>
        public void addEmpl(Employee empl) {
            if (this.employees_Dep == null) {
                this.employees_Dep = new List<Employee>();
            }

            // Каждый департамент может состоять не более чем из 1_000_000 сотрудников!
            if (employees_Dep.Count < MaxEmployeesInDep) {
                this.employees_Dep.Add(empl);
                empl.Dep = this;
            }
        }

        /// <summary>
        /// Увольнение сотрудника из отдела
        /// </summary>
        /// <param name="empl">Сотрудник</param>
        public void delEmpl(Employee empl) {
            if (this.employees_Dep != null) {
                if (this.employees_Dep.Contains(empl)) this.employees_Dep.Remove(empl);
            }
        }

        /// <summary>
        /// Возвращает список должностей в отделе
        /// </summary>
        /// <returns>Список должностей</returns>
        public List<Position> returnPosts() {
            if (this.positions_Dep == null) {
                return new List<Position>();
            }

            return this.positions_Dep;
        }

        /// <summary>
        /// Возвращает должность по её названию
        /// </summary>
        /// <param name="idPost">Идентификатор должности</param>
        /// <returns></returns>
        public Position returnPostAtId(uint idPost) {
            return this.positions_Dep.Find((item) => item.Id == idPost);
        }

        /// <summary>
        /// Возвращает список сотрудников в отделе
        /// </summary>
        /// <returns>Список сотрудников</returns>
        public List<Employee> returnEmpls() {
            if (this.employees_Dep == null) {
                return new List<Employee>();
            }

            return this.employees_Dep;
        }

        /// <summary>
        /// Возвращает сотрудника по его идентификатору
        /// </summary>
        /// <param name="idEmpl">Идентификатор сотрудника отдела</param>
        /// <returns></returns>
        public Employee returnEmplAtId(uint idEmpl) {
            return this.employees_Dep.Find((item) => item.Id == idEmpl);
        }

        /// <summary>
        /// Возвращает информацию о вакантных должностях
        /// </summary>
        /// <returns>Строка с информацией о вакантах</returns>
        public string returnVacant() {
            string outputStr = null;   // возвращаемая строка с информацией о вакантных должностях
            bool trigger = false;   // "попалась" ли должность среди должностей сотрудников

            foreach (Position pos in positions_Dep) {
                if (employees_Dep != null) {
                    foreach (Employee emp in employees_Dep) {
                        // Если сотрудник с такой должностью есть, то переходи к следующей должности
                        if (pos.Id == emp.Post.Id) {
                            trigger = true; // сотрудник на должности пропускаем
                            break;
                        }
                    }
                }

                // Если прошли цикл и не нашли должность среди сотрудников, то выводим информацию о вакантной должности
                if (!trigger) outputStr += pos.returnPositionInfo() + '\n';
                trigger = false;
            }

            return outputStr;
        }

        /// <summary>
        /// Проверяет, существует ли должность в отделе и вакантна ли она
        /// </summary>
        /// <param name="id">Идентификатор проверяемой должности</param>
        /// <returns></returns>
        public bool isIncludAndVacant(uint idPost) {
            foreach (Position pos in positions_Dep) {
                if (employees_Dep != null) {
                    foreach (Employee emp in employees_Dep) {
                        if (emp.Post.Id == idPost) return false;    // должность существует и занята
                    }
                }

                if (pos.Id == idPost) return true;  // должность существует и не занята
            }

            return false;
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
