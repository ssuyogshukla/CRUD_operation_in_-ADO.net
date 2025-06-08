using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Connected_Ado.net
{
    class adNet
    {
        static void Main(string[] args)
        {
              Insert();
              update();
              Delete();
              display();

           

        }
        private static void update()
        {
            string st = "server = localhost; uid = root; pwd = suyog132@gol; database = Cdac";
            using (MySqlConnection conn = new MySqlConnection(st))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update  student" +
                                  "  set name=@name" +
                                  " where id=@id";
                cmd.CommandType = System.Data.CommandType.Text;
                
                Console.WriteLine("Enter a id Which Want to Update");
                int id =int.Parse( Console.ReadLine());
                Console.WriteLine("Enter the Updated Name : ");
                 string name= Console.ReadLine();
                
               

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                int res = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private static void Delete()
        {
            string st = "server = localhost; uid = root; pwd = suyog132@gol; database = Cdac";
            using (MySqlConnection conn = new MySqlConnection(st))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from student  where name=@name";
                cmd.CommandType = System.Data.CommandType.Text;
                Console.WriteLine("Enter a Name Which Want to delete");
                string name = Console.ReadLine();
                cmd.Parameters.AddWithValue("@name", name);

                conn.Open();
                int res = cmd.ExecuteNonQuery();
                Console.WriteLine($"{res}-Deleted");
                conn.Close();
            }
        }

        private static void Insert()
        {
            string st = "server = localhost; uid = root; pwd = suyog132@gol; database = Cdac";
            using (MySqlConnection conn = new MySqlConnection(st))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Insert into Student (id,Name,Age,Grade)" +
                                  "values(@id,@Name,@Age,@Grade)";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@Name","Alex");
                cmd.Parameters.AddWithValue("@Age",25);
                cmd.Parameters.AddWithValue("@Grade","A");

                conn.Open();
                int res = cmd.ExecuteNonQuery();
                Console.WriteLine($"{res}-Inserted");
                conn.Close();

            }

        }

        private static void display()
        {
            string st = "server = localhost; uid = root; pwd = suyog132@gol; database = Cdac";
            using (MySqlConnection conn = new MySqlConnection(st))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select * from student";
                cmd.CommandType = System.Data.CommandType.Text;
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){
                    int id =(int) reader[0];
                    String Name =(string) reader[1];
                    int Age = (int )reader[2];
                    String Grade =(string) reader[3];
                    Console.WriteLine($"{id}-{Name}-{Age}-{Grade}");

                }
                conn.Close();
            }
        }
    }
}
