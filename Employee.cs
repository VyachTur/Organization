using System;
using System.Collections.Generic;

namespace Organization {

    /// <summary>
    /// Структура реализующая сотрудника департамента
    /// </summary>
    class Employee {

        #region Constructors

        /// <summary>
        /// Конструктор (1.1)
        /// </summary>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="family">Фамилия сотрудника</param>
        /// <param name="sirname">Отчество сотрудника</param>
        /// <param name="birthDate">Дата рождения сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        /// <param name="lstProj">Список текущих проектов сотрудника</param>
        public Employee(string name, string family, string sirname, DateTime birthDate, Position position, List<Project> lstProj) {
            this.Id = ++Count_Emp;
            this.name_Emp = name;
            this.family_Emp = family;
            this.sirname_Emp = sirname;
            this.birthDate_Emp = birthDate;
            this.position_Emp = position;
            this.currentProjects_Emp = lstProj;
        }

        /// <summary>
        /// Конструктор (1.2)
        /// </summary>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="family">Фамилия сотрудника</param>
        /// <param name="sirname">Отчество сотрудника</param>
        /// <param name="birthDate">Дата рождения сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        public Employee(string name, string family, string sirname, DateTime birthDate, Position position) :
            this(name, family, sirname, birthDate, position, null) { }


        /// <summary>
        /// Конструктор (2)
        /// </summary>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="family">Фамилия сотрудника</param>
        /// <param name="sirname">Отчество сотрудника</param>
        /// <param name="birthDate">Дата рождения сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        /// <param name="proj">Текущий проект сотрудника</param>
        public Employee(string name, string family, string sirname, DateTime birthDate, Position position, Project proj) {
            this.Id = ++Count_Emp;
            this.name_Emp = name;
            this.family_Emp = family;
            this.sirname_Emp = sirname;
            this.birthDate_Emp = birthDate;
            this.position_Emp = position;
            this.currentProjects_Emp = new List<Project>();
            this.currentProjects_Emp.Add(proj);
        }

        #endregion // Constructors


        #region Methods

        /// <summary>
        /// Назначить проект сотруднику отдела
        /// </summary>
        /// <param name="proj">Проект</param>
        public void addProject(Project proj) {
            // Проверка наличия проектов у сотрудника
            if (this.currentProjects_Emp == null) {
                this.currentProjects_Emp = new List<Project>();
            }

            this.currentProjects_Emp.Add(proj);
        }

        /// <summary>
        /// Получить список проектов сотрудника
        /// </summary>
        /// <returns>Список проектов сотрудника</returns>
        public List<Project> returnProjects() {
            // Проверка наличия проектов у сотрудника
            if (this.currentProjects_Emp == null) {
                return new List<Project>();
            }

            return this.currentProjects_Emp;
        }


        /// <summary>
        /// Информация о сотруднике
        /// </summary>
        /// <returns>String: Id, Family, Name, Sirname, BirthDate</returns>
        public string returnEmployeeInfo() {
            return $"| Идентификатор сотрудника: { this.Id } | ФИО сотрудника: { this.Family } { this.Name } { this.Sirname } | Дата рождения: { this.BirthDate.ToShortDateString() } г.р. | Должность: { this.Post.Name } | Количество текущих проектов: { this.CountProjects } |";
        }

        #endregion // Methods


        #region Properties
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public uint Id { get; private set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name {
            get { return this.name_Emp.Substring(0, 1).ToUpper() + this.name_Emp.Substring(1, this.name_Emp.Length - 1).ToLower(); }   // первая буква имени прописная, остальные строчные
            set { this.name_Emp = value; }
        }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Family {
            get { return this.family_Emp.Substring(0, 1).ToUpper() + this.family_Emp.Substring(1, this.family_Emp.Length - 1).ToLower(); }   // первая буква фамилии прописная, остальные строчные
            set { this.family_Emp = value; }
        }

        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string Sirname {
            get { return this.sirname_Emp.Substring(0, 1).ToUpper() + this.sirname_Emp.Substring(1, this.sirname_Emp.Length - 1).ToLower(); }   // первая буква отчества прописная, остальные строчные
            set { this.sirname_Emp = value; }
        }

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime BirthDate {
            get { return new DateTime(birthDate_Emp.Year, birthDate_Emp.Month, birthDate_Emp.Day); }
            set { this.birthDate_Emp = value; }
        }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age {
            get {
                int age = DateTime.Now.Year - this.BirthDate.Year;
                if (this.BirthDate > DateTime.Now.AddYears(-age)) --age;
                return age;
            }
        }

        /// <summary>
        /// Количество текущих проектов сотрудника
        /// </summary>
        public int CountProjects {
            get { 
                return this.currentProjects_Emp == null ? 0 : this.currentProjects_Emp.Count; 
            }
        }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public Position Post {
            get { return this.position_Emp; }
        }

        #endregion // Properties


        #region Fields
        
        private string name_Emp;                    // имя сотрудника
        private string family_Emp;                  // фамилия сотрудника
        private string sirname_Emp;                 // отчество сотрудника
        private DateTime birthDate_Emp;             // дата рождения сотрудника
        private Position position_Emp;              // должность сотрудника
        private List<Project> currentProjects_Emp;  // текущие проекты сотрудника

        private static uint Count_Emp = 0;  // счетчик сотрудников для определения идентификатора сотрудника (Id)

        #endregion // Fields
    }
}
