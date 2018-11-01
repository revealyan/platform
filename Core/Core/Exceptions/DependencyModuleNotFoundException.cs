using System;
using System.Runtime.Serialization;
using Core.Entities;

namespace Core.Exceptions
{
    public class DependencyModuleNotFoundException : ModuleInfoException
    {
        #region core
        public DependencyInfo Dependency { get; }
        #endregion

        #region init
        public DependencyModuleNotFoundException(ModuleInfo moduleInfo, DependencyInfo dependencyInfo) : this(null, moduleInfo, dependencyInfo)
        {
        }

        public DependencyModuleNotFoundException(string message, ModuleInfo moduleInfo, DependencyInfo dependencyInfo) : this(message, null, moduleInfo, dependencyInfo)
        {
        }

        public DependencyModuleNotFoundException(string message, Exception innerException, ModuleInfo moduleInfo, DependencyInfo dependencyInfo) : base($"Не найдена одна из зависимостей({dependencyInfo?.Name}) для модуля({moduleInfo?.Name}).{message}", innerException, moduleInfo)
        {
            Dependency = dependencyInfo;
        }

        protected DependencyModuleNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
