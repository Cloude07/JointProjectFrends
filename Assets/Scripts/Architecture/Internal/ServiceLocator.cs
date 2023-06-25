using System;
using System.Collections.Generic;

namespace CloudeDev.Architecture
{
    internal sealed class ServiceLocator
    {
        private readonly List<object> services = new List<object>();

        internal List<T> GetServices<T>()
        {
            List<T> result = new List<T>();
            foreach (object service in services)
            {
                if (service is T tService)
                {
                    result.Add(tService);
                }
            }
            return result;
        }

        internal object GetService(Type serviceType)
        {
            foreach (object service in services)
            {
                if (serviceType.IsInstanceOfType(service))
                {
                    return service;
                }
            }

            throw new Exception($"Service of type {serviceType.Name} is not found!");
        }

        internal T GetService<T>()
        {
            foreach (object service in services)
            {
                if (service is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Service of type {typeof(T).Name} is not found!");
        }

        internal void AddService(object service)
        {
            services.Add(service);
        }

        internal void AddServices(IEnumerable<object> service)
        {
            this.services.AddRange(service);
        }
    }
}
