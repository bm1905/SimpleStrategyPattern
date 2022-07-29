using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StrategyPattern.Data;

namespace StrategyPattern.DAL
{
    public class ProcessFeeRepository : IProcessFeeRepository
    {
        private readonly Database _database;

        public ProcessFeeRepository(Database database)
        {
            _database = database;
        }

        public async Task<string> InsertFee<T>(T feeModel)
        {
            string jsonModel = JsonConvert.SerializeObject(feeModel);
            string key = Guid.NewGuid().ToString();
            _database.Data.Add(key, jsonModel);
            await Task.Delay(1);
            return key;
        }

        public async Task<T> GetFee<T>(string key)
        {
            if (!_database.Data.ContainsKey(key)) return default;
            string data = _database.Data[key];
            T model = JsonConvert.DeserializeObject<T>(data);
            await Task.Delay(1);
            return model;
        }
    }
}
