using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SenderMessageAPI.Models;
using Newtonsoft.Json;

namespace SenderMessageAPI.Services
{
    public class MessagerService : IMessagerService
    {
        private readonly IRabbitService _rabbitService;

        public MessagerService(IRabbitService rabbitService)
        {
            _rabbitService = rabbitService;
        }
        
        public void sendMessage(Message msg)
        {
            string messageJson = JsonConvert.SerializeObject(msg);
            _rabbitService.publish(messageJson, "StockQueue");
        }

        public async void updateDb(int id, string name, double value)
        {
            //Message
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

            string connectionString = "data source=.\\SQLExpress;initial catalog=StocksDb;user id=sa;password=sa;MultipleActiveResultSets=True;App=EntityFramework";

            using (var conn = new SqlConnection(connectionString))
            {
                using (var comm = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        comm.CommandText = $"UPDATE StockTableSender SET StockName = @name, StockValue = @value WHERE StockId = @Id";
                        comm.Parameters.AddWithValue("@name", name);
                        comm.Parameters.AddWithValue("@value", value);
                        comm.Parameters.AddWithValue("@Id", id);
                        await Task.Run(() => comm.ExecuteNonQuery());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            sendMessage(msg);
        }
    }
}
