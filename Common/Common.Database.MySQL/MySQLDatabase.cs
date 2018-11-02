using Common.Database.Interface;
using Common.Database.Interface.Exceptions;
using Common.Logger.Interface;
using Common.Modules.Base;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Common.Database.MySQL
{
    public class MySQLDatabase : BaseModule, IDatabase
    {
        #region core
        private string _connectionString;
        private MySqlConnection _connection;
        private ILogger _logger;
        #endregion

        #region init
        public MySQLDatabase(string name, IDictionary<string, string> parameters) : base(name, parameters)
        {
            RegisterInterface<IDatabase>(this);
            _connection = new MySqlConnection();
        }
        #endregion

        #region BaseModule
        public override void Startup()
        {
            base.Startup();
            _logger = ResolveInterface<ILogger>();
            _connectionString = Parameters["connectionString"];
            try
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
            }
            catch (MySqlException mexc)
            {
                throw new ConnectionFailedException(mexc.Message, mexc);
            }
        }
        public override void Shutdown()
        {
            base.Shutdown();
        }
        #endregion

        #region IDatabase
        public IDatabaseCommand CreateCommand(string command)
        {
            try
            {
                return new MySQLDatabaseCommand(new MySqlCommand(command, _connection));
            }
            catch (MySqlException mexc)
            {
                throw new DatabaseException(mexc.Message, mexc);
            }
        }
        #endregion
    }
}
