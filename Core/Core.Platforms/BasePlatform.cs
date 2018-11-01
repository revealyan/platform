using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Platforms.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utils.Collections.Graphs;

namespace Core.Platforms
{
    public class BasePlatform : IPlatform
    {
        #region core
        public PlatformState State { get; private set; }
        public PlatformConfiguration Configuration { get; }
        protected IDictionary<ModuleInfo, IModule> Modules { get; }
        #endregion

        #region init
        public BasePlatform(PlatformConfiguration configuration)
        {
            State = PlatformState.Creating;

            Configuration = configuration ?? throw new InvalidConfigurationException(configuration);
            Modules = new Dictionary<ModuleInfo, IModule>();

            State = PlatformState.Created;
        }
        #endregion

        #region IPlatform
        public void Startup()
        {
            State = PlatformState.StartingUp;
            try
            {
                Configuration.Load();
                var graph = new DirectedGraph(Configuration.ModuleInfos.ToArray());
                foreach (var moduleInfo in Configuration.ModuleInfos)
                {
                    var dModuleInfos = moduleInfo.DependecyInfos.Select(x => Configuration.ModuleInfos.FirstOrDefault(y => x.Name == y.Name));

                    if (dModuleInfos.Any(x => x == null))
                        throw new DependencyModuleNotFoundException(moduleInfo, moduleInfo.DependecyInfos.FirstOrDefault(x => !dModuleInfos.Any(y => y.Name == x.Name)));

                    foreach (var dModuleInfo in dModuleInfos)
                    {
                        graph.AddTo(moduleInfo, dModuleInfo);
                    }
                }

                if (graph.HasCycles())
                    throw new InvalidConfigurationException($"Конфигурация имеет цикл: ", Configuration);

                var queueLoad = new Queue<ModuleInfo>(graph.ToQueue().Cast<ModuleInfo>());


                foreach (var moduleInfo in queueLoad)
                {
                    var module = (IModule)Activator.CreateInstance(Assembly.LoadFile($"{moduleInfo.Assembly}.dll").GetType(moduleInfo.Class), moduleInfo.Name, moduleInfo.Parameters);
                    var dependencyModule = new Dictionary<Type, IModule>();
                    foreach (var dInfo in moduleInfo.DependecyInfos)
                    {
                        var dType = Assembly.LoadFile($"{dInfo.Assembly}.dll").GetType(dInfo.Interface);
                        dependencyModule.Add(dType, Modules.FirstOrDefault(x => x.Key.Name == dInfo.Name).Value);
                    }
                    module.SetDependencies(dependencyModule);
                    Modules.Add(moduleInfo, module);
                }

                foreach (var module in Modules)
                {
                    try
                    {
                        module.Value.Startup();
                    }
                    catch (Exception exc)
                    {
                        throw new ModuleInfoException("Возникла ошибка при запуске модуля", exc, module.Key);
                    }
                }

                State = PlatformState.StartedUp;
            }
            catch (Exception exc)
            {
                State = PlatformState.ErrorOccured;
                throw new PlatformException("Произошла ошибка при запуске платформы", exc);
            }
        }

        public void Shutdown()
        {
            State = PlatformState.ShuttingDown;
            try
            {
                //TODO : реализовать остановку платформы
                State = PlatformState.ShuttedDown;
            }
            catch (Exception exc)
            {
                State = PlatformState.ErrorOccured;
                throw new PlatformException("Произошла ошибка при остановке платформы", exc);
            }
        }

        public void Restart()
        {
            State = PlatformState.Restarting;
            try
            {
                Shutdown();
                Startup();
            }
            catch (Exception exc)
            {
                State = PlatformState.ErrorOccured;
                throw new PlatformException("Произошла ошибка при перезапуске платформы", exc);
            }
        }
        #endregion
    }
}
