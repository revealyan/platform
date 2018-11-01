using Common.Modules.Base.Exceptions;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Modules.Base
{
    public class BaseModule : IModule
    {
        #region core
        public string Name { get; }
        public string Description { get; }

        protected Parameters Parameters { get; }

        private readonly IDictionary<Type, IModule> _dependencies;
        private readonly IDictionary<Type, IModule> _registeredInterfaces;
        #endregion

        #region init
        public BaseModule(string name, IDictionary<string, string> parameters)
        {
            _dependencies = new Dictionary<Type, IModule>();
            _registeredInterfaces = new Dictionary<Type, IModule>();
            Parameters = new Parameters(parameters);
        }
        #endregion

        #region IModule
        public virtual void Startup()
        {
        }

        public virtual void Shutdown()
        {
        }

        public IList<Type> GetInterfaceTypes() => _registeredInterfaces.Keys.ToList();


        public void SetDependencies(IDictionary<Type, IModule> dependencies)
        {
            if(dependencies != null)
            {
                foreach (var dependency in dependencies)
                {
                    _dependencies.Add(dependency);
                }
            }
        }
        #endregion

        #region protected methods
        protected void RegisterInterface<T>(T implemetation)
        {
            var reginstredType = typeof(T);
            if (!reginstredType.IsInterface)
                throw new RegisteringInvalidInterfaceException("Тип не является интерфейсом", Name, reginstredType);

            if (!(implemetation?.GetType().IsSubclassOf(typeof(BaseModule)) ?? false))
                throw new RegisteringInvalidInterfaceException($"Объект не является наследником {typeof(BaseModule).FullName}", Name, reginstredType);


            _registeredInterfaces.Add(reginstredType, (IModule)implemetation);
        }

        protected T ResolveInterface<T>()
        {
            var resolveType = typeof(T);
            if (!resolveType.IsInterface)
                throw new ResolvingIinvalidInterfaceException("Тип не является интерфейсом", Name, resolveType);
            if (!_dependencies.ContainsKey(resolveType))
                throw new ResolvingIinvalidInterfaceException($"Тип {resolveType.FullName} не найден в зависимостях", Name, resolveType);
            return (T)_dependencies[resolveType];
        }
        #endregion
    }
}
