using Core.Entities;

namespace Core.Platforms.Configurations
{
    public class FileConfigurationContainer
    {
        public string Name { get; set; }
        public ModuleInfo[] Modules { get; set; }
    }
}
