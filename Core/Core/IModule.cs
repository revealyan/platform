using System;
using System.Collections.Generic;

namespace Core
{
    public interface IModule
    {
        void Startup();
        void Shutdown();
        IList<Type> GetInterfaceTypes();
        void SetDependencies(IDictionary<Type, IModule> dependencies);
    }
}
