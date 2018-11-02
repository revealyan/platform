using Common.Database.Interface;
using Common.Database.Interface.Exceptions;
using MySql.Data.MySqlClient;

namespace Common.Database.MySQL
{
    public class MySQLDatabaseCommand : IDatabaseCommand
    {
        #region core
        private bool _isDisposed = false;
        private MySqlCommand _command;
        #endregion

        #region init
        public MySQLDatabaseCommand(MySqlCommand command)
        {
            _command = command;
        }
        #endregion

        #region IDatabaseCommand
        public int ExecuteNonQuery()
        {
            try
            {
                return _command.ExecuteNonQuery();
            }
            catch (MySqlException mexc)
            {
                throw new DatabaseException(mexc.Message, mexc);
            }
        }

        public IDatabaseReader ExecuteReader()
        {
            try
            {
                return new MySQLDatabaseReader(_command.ExecuteReader());
            }
            catch (MySqlException mexc)
            {
                throw new DatabaseException(mexc.Message, mexc);
            }
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _command.Dispose();
                _isDisposed = true;
            }
        }
        #endregion
    }
}
