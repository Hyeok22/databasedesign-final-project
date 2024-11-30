using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace ReviewAPIServer
{
    class DBManager
    {
        private string conString;
        private const string Port = "3306";
        private const string Database = "temp";
        private const string Uid = "root";
        private const string Pwd = "root1230";

        public DBManager()
        {
            conString = string.Format("Server=localhost;Port={0};Database={1};Uid={2};Pwd={3}", Port, Database, Uid, Pwd);
        }

        public void ExecuteCommand(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                //예외 처리
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // 만약에 쿼리가 정상적으로 동작하지 않았다면 메세지 출력
                    if (command.ExecuteNonQuery() != 1)
                        Console.WriteLine("실패");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public string ExecuteSelectCommand(string query)
        {
            string json = string.Empty;

            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                //예외 처리
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);

                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());

                    json = JsonConvert.SerializeObject(dt);

                    DataTable a = JsonConvert.DeserializeObject<DataTable>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }
            }

            return json;
        }
    }
}
