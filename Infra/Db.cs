using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using bench.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace bench.Infra
{
    public class Db : IDisposable
    {
        MySqlConnection _connection;

        public Db(IConfiguration config)
        {
            var cs = config["ConnectionStrings:Db"];
            _connection = new MySqlConnection(cs);
        }
        
        public async Task<List<Gender>> GetAllGenders()
        {
            await _connection.OpenAsync();
            var cmd = _connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `genders`";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        private async Task<List<Gender>> ReadAllAsync(DbDataReader reader)
        {
            var items = new List<Gender>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var item = new Gender
                    {
                        Id = await reader.GetFieldValueAsync<int>(0),
                        Code = await reader.GetFieldValueAsync<string>(1),
                        Name = await reader.GetFieldValueAsync<string>(2),
                        Order = await reader.GetFieldValueAsync<int>(3),
                    };
                    items.Add(item);
                }
            }
            return items;
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}