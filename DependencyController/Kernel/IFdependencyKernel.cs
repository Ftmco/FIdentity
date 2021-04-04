using System;
using System.Threading.Tasks;

namespace FTeam.DependencyController.Kernel
{
    public interface IFdependencyKernel<TInterface, TClass> where TClass : class, TInterface, new()
    {
        Task<TInterface> GetDepdencyAsync(Type classType);

        Task<TInterface> GetDepdencyAsync();

        TInterface GetDepdency(Type classType);

        TInterface GetDepdency();

        TInterface Inject();

        TInterface Inject(Type classType);

        Task<TInterface> InjectAsync();

        Task<TInterface> InjectAsync(Type classType);
    }
}
