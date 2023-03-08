using FixItApp.Infrastructure.Entities;
using MySql.Data.MySqlClient;

namespace FixItAppConsoleTest 
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string connStr = "Server=localhost;User=root;Password=password;Database=FixItApp;Port=3306;";

            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();

            try
            {
                string command = "SELECT * FROM FixItApp.Roles;";
                MySqlCommand query = new MySqlCommand(command, conn);

                MySqlDataReader rdr = query.ExecuteReader();

                var roles = new List<RoleEntity>();

                while (rdr.Read())
                {
                    var role = new RoleEntity
                    {
                        Id = rdr.GetInt32(0),
                        Name = rdr.GetString(1)
                    };

                    roles.Add(role);
                }

                rdr.Close();

                foreach (var role in roles)
                    Console.WriteLine("Id - {0}, Name - {1}", role.Id, role.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();

            Console.ReadKey();
        }
    }
}