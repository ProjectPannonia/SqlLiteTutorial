using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows;

namespace SqlLiteTutorial
{
    public class SqliteDataAccess
    {
        public static List<Person> LoadPeople()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Person>("select * from Person", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SavePerson(Person person)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Person (FirstName, LastName) " +
                    "values (@FirstName, @LastName)", person);
            }
        }
        public static int GetPerson()
        {
            bool isReserved = true;
            string userName = "Adam";
            int id= 0;
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //id = cnn.Execute("SELECT Id FROM Person WHERE FirstName Like 'Valami'");
                string name = cnn.Execute("SELECT p.LastName As PersonId FROM Person p WHERE p.FirstName = 'valami'").ToString();
                //string firstname = cnn.Execute("SELECT FirstName FROM Person WHERE LastName = 'Cser'").ToString();
                MessageBox.Show(name);
                    string valami = cnn.Query("SELECT p.LastName As PersonId FROM Person p WHERE p.FirstName = 'valami'");
            }
            return id;
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
