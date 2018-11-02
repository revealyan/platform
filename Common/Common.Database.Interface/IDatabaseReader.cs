using System;

namespace Common.Database.Interface
{
    public interface IDatabaseReader : IDisposable
    {
        bool Read();
        T GetValue<T>(string name);
    }
}
