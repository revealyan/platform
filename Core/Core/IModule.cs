using System;
using System.Collections.Generic;

namespace Core
{
    public interface IModule
    {
        void Startup();
        void Shutdown();
        void RegisterInterface<T>(T implemetation);
        T ResolveInterface<T>();
        IList<Type> GetInterfaceTypes();
        void SetDependencies(IDictionary<Type, IModule> dependencies);
    }
}
