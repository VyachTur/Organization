using System;
using System.Collections.Generic;
using System.Text;

namespace Organization {

    /// <summary>
    /// Структура реализующая департамент (отдел)
    /// </summary>
    struct Department {

        #region Constructors

        /// <summary>
        /// Конструктор (1)
        /// </summary>
        /// <param name="name">Название департамента (отдела)</param>
        /// <param name="posts">Список должностей</param>
        public Department(string name, List<Position> posts) {
            this.Id = ++Count_Dep;
            this.Name = name;
            this.positions = posts;
        }

        /// <summary>
        /// Конструктор (2)
        /// </summary>
        /// <param name="name">Название департамента (отдела)</param>
        /// <param name="posts">Список должностей</param>
        public Department(string name, Position post) {
            this.Id = ++Count_Dep;
            this.Name = name;
            this.positions = new List<Position>();
            this.positions.Add(post);
        }

        #endregion // Constructors



        #region Methods

        public string returnDepartmentInfo() {
            return $" { this.Id } { this.Name } { this.CountPositions } ";
        }

        #endregion // Methods



        #region Properties

        public uint Id { get; private set; }

        public string Name { get; set; }

        public int CountPositions {
            get {
                return this.positions == null ? 0 : this.positions.Count;
                return this.positions.Count;
            }
        }

        #endregion // Properties



        #region Fields

        private List<Position> positions;   // должности в департаменте (отделе)

        private static uint Count_Dep = 0;      // счетчик для идентификатора департамента

        #endregion // Fields

    }
}
