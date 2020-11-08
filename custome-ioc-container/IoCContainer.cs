using System;
using System.Collections.Generic;
using System.Text;

namespace custome_ioc_container
{
    public static class IoCContainer
    {
        private static readonly Dictionary<Type, Type> _registeredObjects = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, object> _registeredObjectInstances = new Dictionary<Type, object>();


        public static void Register<TKey, TConcrete>() where TConcrete : TKey
        {
            _registeredObjects[typeof(TKey)] = typeof(TConcrete);
        }

        public static dynamic GetTransient<TKey>()
        {
            return Activator.CreateInstance(_registeredObjects[typeof(TKey)]);
        }

        public static dynamic GetSingleton<TKey>()
        {

            if (_registeredObjectInstances.TryGetValue(typeof(TKey), out object registeredObjectInstance))
            {
                return registeredObjectInstance;
            }

            registeredObjectInstance = Activator.CreateInstance(_registeredObjects[typeof(TKey)]);
            _registeredObjectInstances.Add(typeof(TKey), registeredObjectInstance);
            return registeredObjectInstance;
        }
    }
}
