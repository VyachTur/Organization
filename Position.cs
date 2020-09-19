using System;
using System.Collections.Generic;
using System.Text;

namespace Organization {

    /// <summary>
    /// Структура реализующая должность в департаменте
    /// </summary>
    struct Position {

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Наименование должности</param>
        /// <param name="salary">Зарплата</param>
        public Position(string name, uint salary) {
            this.Id = ++Count_Pos;
            this.Name = name;
            this.Salary = salary;
        }

        #endregion // Constructors



        #region Methods

        /// <summary>
        /// Информация по должности
        /// </summary>
        /// <returns></returns>
        public string returnPositionInfo() {
            return $"| { this.Id } | { this.Name } | { this.Salary } |";
        }

        #endregion // Methods



        #region Properties

        /// <summary>
        /// Идентификатор должности
        /// </summary>
        public uint Id { get; private set; }

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public uint Salary { get; set; }

        #endregion // Properties



        #region Fields

        private static uint Count_Pos = 0;  // Счетчик должностей для определения идентификатора

        #endregion // Fields
    }
}
