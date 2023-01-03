﻿using System;
using System.Collections.Generic;

namespace DependencyInjection
{
    public static class DI
    {
        private static Dictionary<Type, object> injections;

        private static Dictionary<Type, object> Injections =>
            injections is null 
            ? injections = new Dictionary<Type, object>() 
            : injections;

        public static void Add<T>(T obj)
        {
            Injections[obj.GetType()] = obj;

            UnityEngine.Debug.Log($"Added {typeof(T)} to the DI");
        }

        public static T Get<T>()
        {
            UnityEngine.Debug.Log($"Get {typeof(T)} from the DI");
            var hasObject = Injections.TryGetValue(typeof(T), out object retVal);

            if (!hasObject)
            {
                throw new Exception($"The object of type {typeof(T)} have not been added to the DI container");
            }

            return (T)retVal; 
        }
    }
}