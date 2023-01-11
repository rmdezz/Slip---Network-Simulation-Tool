using Slip.Modules;

namespace Slip.Interfaces
{
    public interface IRunSlip
    {
        void Run(string filter, Config[] configArray);
    }
}