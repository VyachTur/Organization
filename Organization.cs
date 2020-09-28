using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;


namespace Organization {

    /// <summary>
    /// Поля для сортировки
    /// </summary>
    public enum FIELDSORT {
        ID = 1,         // для сортировки по идентификатору сотрудника
        DEP,            // для сортировки по департаменту (отделу)
        AGE,            // для сортировки по возрасту
        AGE_SALARY,     // для сортировки по возрасту и зарплате
        DEP_AGE_SALARY  // для сортировки по возрасту и зарплате в рамках одного департамента
    }

    [Serializable]
    /// <summary>
    /// Класс реализующий организацию
    /// </summary>
    public class Organization {

        #region Constructors

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Organization() { }


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
            if (this.departs_Org == null) {
                this.departs_Org = new List<Department>();
            }

            this.departs_Org.Add(dep);
        }

        /// <summary>
        /// Удаляет отдел из организации
        /// </summary>
        /// <param name="dep">Отдел</param>
        public void delDepartment(Department dep) {
            if (this.departs_Org != null) {
                // Если элемент есть в списке, то удаляем его
                if (this.departs_Org.Contains(dep)) this.departs_Org.Remove(dep);
            }
        }

        /// <summary>
        /// Возвращает список отделов организации
        /// </summary>
        /// <returns>Список отделов</returns>
        public List<Department> returnDeps() {
            if (this.departs_Org == null) {
                return new List<Department>();
            }

            return this.departs_Org;
        }

        /// <summary>
        /// Возвращает отдел по его наименованию
        /// </summary>
        /// <param name="nameDep">Отдел (Department)</param>
        /// <returns></returns>
        public Department returnDepAtName(string nameDep) {
            return this.departs_Org.Find((item) => item.Name == nameDep);
        }

        /// <summary>
        /// Проверяет, существует ли отдел в организации (если существует, возвр. true, иначе false)
        /// </summary>
        /// <param name="nameDep">Имя проверяемого департамента</param>
        /// <returns></returns>
        public bool isIncludDep(string nameDep) {
            foreach (Department dep in this.departs_Org) {
                if (dep.Name == nameDep) return true;
            }

            return false;
        }

        /// <summary>
        /// Информация об организации
        /// </summary>
        /// <returns>String: Id, Name, CountDeparts</returns>
        public override string ToString() {
            return $"| Идентификатор организации: { this.Id } | Наименование организации: { this.Name } | Количество отделов: { this.CountDeparts } |";
        }


        /// <summary>
        /// Вывод подробной информации об организации на экран консоли
        /// </summary>
        public void printInfo() {
            Console.WriteLine($"| {"Id", 2} | {"Имя", 10} | {"Фамилия", 15} | {"Возраст", 7} |" +
                                $"{"Департамент", 20} | {"Оплата труда", 12} | {"Кол-во проектов", 15} |");

            Console.WriteLine("------------------------------------------------------------------------------------------------------");

            if (this.departs_Org != null) {

                // Информация выводится по сотрудникам в организации (пустые отделы и должности не выводятся)
                foreach (Department currDep in this.departs_Org) {
                    foreach (Employee currEmp in currDep.returnEmpls()) {

                        Console.WriteLine($"| {currEmp.Id,2} | {currEmp.Name,10} | {currEmp.Family,15} | {currEmp.Age,7} |" +
                                    $"{currEmp.Dep.Name,20} | {currEmp.Post.Salary,12} | {currEmp.CountProjects,15} |");

                    }
                }
            }

            Console.ReadKey();
        }


        //////////////////////////////////////СОРТИРОВКА//////////////////////////////////////////////

        /// <summary>
        /// Сортирует сотрудников в организации по различным критериям (3 критерия)
        /// </summary>
        /// <param name="critSort">Критерии сортировки: FIELDSORT.ID - по идентификатору сотрудника,
        ///                                             FIELDSORT.DEP - по департаменту (отделу),
        ///                                             FIELDSORT.AGE - по возрасту,
        ///                                             FIELDSORT.AGE_SALARY - по возрасту и зарплате,
        ///                                             FIELDSORT.DEP_AGE_SALARY - по возр. и зп. в рамках одного деп.</param>
        /// <returns>Лист сотрудников, отсортированных по выбранному критерию</returns>
        private List<Employee> getSortEmployees(FIELDSORT critSort = FIELDSORT.ID) {
            List<Employee> lstEmp = new List<Employee>();

            foreach (Department currDep in this.departs_Org) {
                lstEmp.AddRange(currDep.returnEmpls());
            }

            
            switch (critSort) {
                case FIELDSORT.ID:
                    // Сортируем всех сотрудников по идентификатору
                    List<Employee> sortedById =
                            lstEmp.OrderBy(i => i.Id).ToList();

                    return sortedById;

                case FIELDSORT.DEP:
                    // Сортируем всех сотрудников по департаменту
                    List<Employee> sortedByDep =
                            lstEmp.OrderBy(d => d.Dep.Name).ToList();

                    return sortedByDep;

                case FIELDSORT.AGE:
                    // Сортируем всех сотрудников по возрасту
                    List<Employee> sortedByAge =
                            lstEmp.OrderBy(a => a.Age).ToList();
                    
                    return sortedByAge;

                case FIELDSORT.AGE_SALARY:
                    // Сортируем всех сотрудников по возрасту и зарплате
                    List<Employee> sortedByAgeSal =
                            lstEmp.OrderBy(a => a.Age).ThenBy(s => s.Post.Salary).ToList();

                    return sortedByAgeSal;

                case FIELDSORT.DEP_AGE_SALARY:
                    // Сортируем сотрудников в рамках одного отдела по возрасту и зарплате
                    List<Employee> sortedByDepAgeSal =
                            lstEmp.OrderBy(d => d.Dep.Name).ThenBy(a => a.Age).ThenBy(s => s.Post.Salary).ToList();

                    return sortedByDepAgeSal;

            }

            return lstEmp;
        }

        /// <summary>
        /// Вывод на экран консоли отсортированного списка сотрудников организации
        /// </summary>
        /// <param name="critSort">Критерий сортировки</param>
        public void printSortedEmployees(FIELDSORT critSort = FIELDSORT.ID) {
            Console.WriteLine($"| {"Id",2} | {"Имя",10} | {"Фамилия",15} | {"Возраст",7} |" +
                                $"{"Департамент",20} | {"Оплата труда",12} | {"Кол-во проектов",15} |");

            Console.WriteLine("------------------------------------------------------------------------------------------------------");

            if (this.departs_Org != null) {
                foreach (Employee emp in this.getSortEmployees(critSort)) {
                    Console.WriteLine($"| {emp.Id,2} | {emp.Name,10} | {emp.Family,15} | {emp.Age,7} |" +
                                    $"{emp.Dep.Name,20} | {emp.Post.Salary,12} | {emp.CountProjects,15} |");
                }
            }

            Console.ReadKey();
        }

        ///////////////////////////////////КОНЕЦ_СОРТИРОВКА////////////////////////////////////////////
        ///




        ///////////////////////////////////////////////СЕРИАЛИЗАЦИЯ///////////////////////////////////////////////////

        /// <summary>
        /// Сериализует организацию
        /// </summary>
        /// /// <param name="path">Путь к файлу импорта (xml)</param>
        public void xmlOrganizationSerializer(string path) {

            XElement xeORGANIZATION = new XElement("ORGANIZATION");
            XAttribute xaNAME_ORG = new XAttribute("name", this.Name);

            XElement xeDEPARTMENTS = new XElement("DEPARTMENTS");
            

            foreach (Department dep in this.Departments) {
                XElement xeDEPARTMENT = new XElement("DEPARTMENT");
                XAttribute xaNAME_DEP = new XAttribute("name", dep.Name);
                XAttribute xaCREATEDATE_DEP = new XAttribute("createdate", dep.CreateDate);

                XElement xeEMPLOYEES = new XElement("EMPLOYEES");

                foreach (Employee emp in dep.returnEmpls()) {
                    XElement xeEMPLOYEE = new XElement("EMPLOYEE");
                    XAttribute xaNAME_EMP = new XAttribute("name", emp.Name);
                    XAttribute xaFAMILY_EMP = new XAttribute("family", emp.Family);
                    XAttribute xaSIRNAME_EMP = new XAttribute("sirname", emp.Sirname);
                    XAttribute xaBIRTHDATE = new XAttribute("birthdate", emp.BirthDate);

                    XAttribute xaNAME_POS = new XAttribute("name", emp.Post.Name);
                    XAttribute xaSALARY_POS = new XAttribute("salary", emp.Post.Salary);
                    XElement xePOSITION_EMP = new XElement("POSITION", xaNAME_POS, xaSALARY_POS);

                    XElement xePROJECTS = new XElement("PROJECTS");

                    foreach (Project proj in emp.returnProjects()) {
                        XElement xePROJECT = new XElement("PROJECT");
                        XAttribute xaNAME_PROJ = new XAttribute("name", proj.Name);
                        XAttribute xaDATEBEG_PROJ = new XAttribute("datebegin", proj.DateBegin);
                        XAttribute xaDATEEND_PROJ = new XAttribute("dateend", proj.DateEnd);
                        XAttribute xaDESCRIPTION = new XAttribute("description", proj.Description);

                        xePROJECT.Add(xaNAME_PROJ, xaDATEBEG_PROJ, xaDATEEND_PROJ, xaDESCRIPTION);

                        xePROJECTS.Add(xePROJECT);
                    }


                    xeEMPLOYEE.Add(xaNAME_EMP, xaFAMILY_EMP, xaSIRNAME_EMP, xaBIRTHDATE);
                    xeEMPLOYEE.Add(xePOSITION_EMP);
                    xeEMPLOYEE.Add(xePROJECTS);

                    xeEMPLOYEES.Add(xeEMPLOYEE);
                }



                xeDEPARTMENT.Add(xaNAME_DEP, xaCREATEDATE_DEP);
                xeDEPARTMENT.Add(xeEMPLOYEES);

                xeDEPARTMENTS.Add(xeDEPARTMENT);

            }

            xeORGANIZATION.Add(xeDEPARTMENTS, xaNAME_ORG);

            xeORGANIZATION.Save(path);
        }



        /// <summary>
        /// Десериализует организацию
        /// </summary>
        /// <param name="path">Путь к файлу экспорта (xml)</param>
        public static Organization xmlOrganizationDeserializer(string path) {
            Organization tmpOrganization = new Organization();

            string xml = File.ReadAllText(path);

            tmpOrganization.Name = XDocument.Parse(xml)
                            .Element("ORGANIZATION")
                            .Attribute("name").Value;


            return tmpOrganization;
        }





        ////////////////////////////////////////////КОНЕЦ_СЕРИАЛИЗАЦИЯ////////////////////////////////////////////////



        #endregion // Methods


        #region Properties


        /// <summary>
        /// Идентификатор организации
        /// </summary>
        public uint Id { get; }

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

        /// <summary>
        /// Список департаментов в организации
        /// </summary>
        public List<Department> Departments {
            get { return this.departs_Org; }
        }


        #endregion // Properties



        #region Fields

        private List<Department> departs_Org;   // департаменты (отделы) в организцаии
        private static uint Count_Org = 0;      // счетчик организаций для идентификатора

        #endregion // Fields

    }
}
