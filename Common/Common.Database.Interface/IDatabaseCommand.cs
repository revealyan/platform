using System;

namespace Common.Database.Interface
{
    public interface IDatabaseCommand : IDisposable
    {
        int ExecuteNonQuery();
        IDatabaseReader ExecuteReader();
    }
}
