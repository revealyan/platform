using Common.Database.Interface;
using Common.Database.Interface.Exceptions;
using MySql.Data.MySqlClient;

namespace Common.Database.MySQL
{
    public class MySQLDatabaseReader : IDatabaseReader
    {
        #region core
        private bool _isDisposed = false;
        private MySqlDataReader _reader;
        #endregion

        #region init
        public MySQLDatabaseReader(MySqlDataReader reader)
        {
            _reader = reader;
        }
        #endregion

        #region IDatabaseReader
        public bool Read()
        {
            try
            {
                return _reader.Read();
            }
            catch (MySqlException mexc)
            {
                throw new DatabaseException(mexc.Message, mexc);
            }
        }

        public T GetValue<T>(string name)
        {
            try
            {
                return (T)_reader[name];
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
                _reader.Dispose();
                _isDisposed = true;
            }
        }
        #endregion
    }
}
