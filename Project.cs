using System;

namespace Organization {
    struct Project {

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Название проекта</param>
        /// <param name="dateBeg">Дата начала проекта</param>
        /// <param name="dateEnd">Дата окончания проекта</param>
        /// <param name="description">Описание проекта</param>
        public Project(string name, DateTime dateBeg, DateTime dateEnd, string description) {
            Id = ++Count_Proj;
            Name = name;
            Description = description;
            dateBegin_Proj = dateBeg;
            dateEnd_Proj = dateEnd;
        }

        #endregion // Constructors


        #region Methods

        /// <summary>
        /// Информация по проекту
        /// </summary>
        /// <returns>Id, Name, DateBegin, DateEnd, Description</returns>
        public string returnProjectInfo() {
            return $"| { this.Id } | { this.Name } | { this.DateBegin.ToShortDateString() } | {this.DateEnd.ToShortDateString() } | {this.Description } |";
        }

        #endregion // Methods


        #region Property

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public uint Id { get; private set; }

        /// <summary>
        /// Название проекта
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Дата начала проекта
        /// </summary>
        public DateTime DateBegin {
            get { return dateBegin_Proj; }
            set {
                if (dateBegin_Proj < DateTime.Now) dateBegin_Proj = DateTime.Now;  // если дата начала меньше текущей даты, то присваиваем текущую
                else dateBegin_Proj = value;
            }
        }

        /// <summary>
        /// Дата окончания проекта
        /// </summary>
        public DateTime DateEnd {
            get { return dateEnd_Proj; }
            set {
                if (dateEnd_Proj < dateBegin_Proj) dateEnd_Proj = dateBegin_Proj;   // если дата окончания проекта меньше даты начала, то присваиваем дате окончания дату начала
                else dateEnd_Proj = value;
            }
        }

        /// <summary>
        /// Описание проекта
        /// </summary>
        public string Description { get; set; }

        #endregion // Property


        #region Fields

        private DateTime dateBegin_Proj;    // дата начала проекта
        private DateTime dateEnd_Proj;      // отчество сотрудника

        private static uint Count_Proj = 0;  // счетчик проектов для определения идентификатора проекта (Id)

        #endregion // Fields
    }
}