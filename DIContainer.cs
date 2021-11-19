using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildDepInj
{
    internal class DIContainer
    {
        private List<ServiceDescriptor> _serviceDescriptors;

        public DIContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        private object GetService(Type SType)
        {
            // Find service descriptor in the registry assuming T is a class
            var descriptor = _serviceDescriptors.SingleOrDefault(x => x.CType == SType);

            // If not found T as a class, find service descriptor in the registry assuming T is an interface
            if (descriptor is null)
                descriptor = _serviceDescriptors.SingleOrDefault(x => x.IType == SType);

            // If not found then it has not been registered
            if (descriptor is null)
                throw new Exception($"Service of type {SType.Name} is not registered");

            object obj;
            // The service was registered as transient, so we always return a new instance of T
            if (descriptor.Lifetime == ServiceLifetime.Transient)
            {
                // Create instance and dependencies
                //obj = Activator.CreateInstance(descriptor.CType);
                obj = BuildInstance(descriptor);
            }


            // The service was registered as singleton, so we return the unique instance of it
            else if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                if (descriptor.Obj is null)
                {
                    //obj = Activator.CreateInstance(descriptor.CType);
                    obj = BuildInstance(descriptor);
                    descriptor.Obj = obj;
                }

                else
                    obj = descriptor.Obj;
            }


            else
                throw new Exception("Service lifetime is not known (singleton or transient).");


            return obj;
        }

        private object BuildInstance(ServiceDescriptor descriptor)
        {
            object obj;
            var constructorInfo = (descriptor.CType).GetConstructors().First();
            var parameters = constructorInfo.GetParameters()
                .Select(x => GetService(x.ParameterType)).ToArray();
            obj = Activator.CreateInstance(descriptor.CType, parameters);
            return obj;
        }

        internal T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }



    }
}
