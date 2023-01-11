using System.Collections.Generic;

namespace Slip.Modules
{
    public interface IModuleConfigManager
    {
        List<Config> GetModulesConfig();
    }
}