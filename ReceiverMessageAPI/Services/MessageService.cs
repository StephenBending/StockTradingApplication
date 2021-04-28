using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReceiverMessageAPI.Models;

namespace ReceiverMessageAPI.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRabbitService _rabbitService;

        public MessageService(IRabbitService rabbitService)
        {
            _rabbitService = rabbitService;
        }

        public string ReceivedMessage()
        {
            //  string messageJson = JsonConvert.SerializeObject(msg);
            string msg = _rabbitService.CollectMessage("stock");
            var messageInJSON = JsonConvert.SerializeObject(msg);
            return messageInJSON;
        }

        public async void AddToDb(int id, string name, double value)
        {

            var messageReadyToSend = ReceivedMessage();
            var msg = new Message()
            {
                id = id,
                name = name,
                value = value
            };

            
    
            /*
             * UPDATE x WHERE id = id VALUES name, value
             * call send message from within this function?
             */

        //  System.Data.SqlClient.SqlConnection sqlConnection1 =
        //  new System.Data.SqlClient.SqlConnection("Data Source=desktop-f2jtkt5\\sqlll;Initial Catalog=stock;Integrated Security=True");
        //
        //  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        //  cmd.CommandType = System.Data.CommandType.Text;
        //
        //  cmd.CommandText = $"INSERT stockTable (StockID, StockName, StockValue) VALUES ({message})";
        //  cmd.Connection = sqlConnection1;
        //
        //  sqlConnection1.Open();
        //  cmd.ExecuteNonQuery();
        //  sqlConnection1.Close();



            string connectionString = "Data Source = desktop - f2jtkt5\\sqlll; Initial Catalog = stock; Integrated Security = True";

            using (var conn = new SqlConnection(connectionString))
            {
                using (var comm = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        comm.CommandText = $"INSERT INTO stockTable (StockID, StockName, StockValue)" +
                            $" SELECT id, name, value" +
                            $"FROM OPENJSON({ messageReadyToSend})" +
                            $"WITH(id int,name nvarchar(30), value decimal(18, 2))";

                        await Task.Run(() => comm.ExecuteNonQuery());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }


        }
    }
}

//$"INSERT stockTable (StockID, StockName, StockValue) VALUES ({messageReadyToSend})";

