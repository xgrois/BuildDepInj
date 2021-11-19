using System;
using System.Collections.Generic;

namespace BuildDepInj
{
    public enum ServiceLifetime
    {
        Singleton,
        Transient
    }
    internal class DIServiceCollection
    {
        private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();
        public DIServiceCollection()
        {

        }

        internal DIContainer GenerateContainer()
        {
            return new DIContainer(_serviceDescriptors);
        }

        internal void RegisterSingleton<TService>(TService anyObj)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(anyObj, ServiceLifetime.Singleton));
        }



        internal void RegisterSingleton<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifetime.Singleton));
        }

        internal void RegisterTransient<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifetime.Transient));
        }

        internal void RegisterSingleton<I, T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(I), typeof(T), ServiceLifetime.Singleton));
        }

        internal void RegisterTransient<I, T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(I), typeof(T), ServiceLifetime.Transient));
        }
    }
}