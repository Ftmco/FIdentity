using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace FTeam.DependencyController.Kernel
{
    public class FdependencyKernel<TInterface, TClass> : IFdependencyKernel<TInterface, TClass> where TClass : class, TInterface, new()
    {
        #region ::Depdency::

        /// <summary>
        /// Interface Base For Return Injections
        /// </summary>
        private TInterface _interface;

        /// <summary>
        /// Depdency Collection
        /// </summary>
        private static Dictionary<object, object> _depdencyListDicts;

        #endregion

        public TInterface GetDepdency(Type classType)
        {
            if (classType == null)
                throw new ArgumentNullException(nameof(classType));

            if (typeof(TInterface) != classType)
                throw new TypeAccessException(nameof(classType));

            return Inject(classType);
        }

        public TInterface GetDepdency()
        {
            if (typeof(TInterface) != typeof(TClass))
                throw new TypeAccessException(nameof(TClass));

            return Inject();
        }

        public async Task<TInterface> GetDepdencyAsync(Type classType)
            => await Task.Run(async ()
               =>
               {
                   if (classType == null)
                       throw new ArgumentNullException(nameof(classType));

                   if (typeof(TInterface) != classType)
                       throw new TypeAccessException(nameof(classType));

                   return await InjectAsync(classType);
               });

        public async Task<TInterface> GetDepdencyAsync()
            => await Task.Run(async ()
                =>
                {
                    if (typeof(TInterface) != typeof(TClass))
                        throw new TypeAccessException(nameof(TClass));

                    return await InjectAsync();
                });

        public TInterface Inject()
        {
            if (typeof(TInterface) != typeof(TClass))
                throw new TypeAccessException(nameof(TClass));

            return _interface = new TClass();
        }

        public TInterface Inject(Type classType)
        {
            if (classType == null)
                throw new ArgumentNullException(nameof(classType));

            if (typeof(TInterface) != classType)
                throw new TypeAccessException(nameof(classType));

            ConstructorInfo[] classConstructors = classType.GetConstructors(BindingFlags.Public);

            foreach (ConstructorInfo constructor in classConstructors)
            {

            }

            return _interface = new TClass();
        }

        public async Task<TInterface> InjectAsync()
            => await Task.Run(()
                =>
                {
                    if (typeof(TInterface) != typeof(TClass))
                        throw new TypeAccessException(nameof(TClass));

                    return _interface = new TClass();
                });

        public async Task<TInterface> InjectAsync(Type classType)
            => await Task.Run(()
                =>
                {
                    if (classType == null)
                        throw new ArgumentNullException(nameof(classType));

                    if (typeof(TInterface) != classType)
                        throw new TypeAccessException(nameof(classType));

                    return _interface = new TClass();
                });

        public void Add()
        {
            _depdencyListDicts.Add();
        }

        public Task AddAsync()
        {
            throw new NotImplementedException();
        }

    }
}
