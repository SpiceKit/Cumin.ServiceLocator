// zlib/libpng License
//
// Copyright (c) 2025 RabitBox
//
// This software is provided 'as-is', without any express or implied warranty.
// In no event will the authors be held liable for any damages arising from the use of this software.
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it freely,
// subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software.
//    If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
// 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
// 3. This notice may not be removed or altered from any source distribution.
using System;
using System.Collections.Generic;

namespace RV.SpiceKit.Cumin
{
    /// <summary>
    /// Service Locator
    /// </summary>
    public static class Locator
    {
        /// <summary>
        /// Instance Dictionary
        /// </summary>
        private static Dictionary<Type, object> _container = new Dictionary<Type, object>();


        /// <summary>
        /// Register the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>()
            where T : class
        {
            _container[typeof(T)] = Activator.CreateInstance(typeof(T)) as T;
        }

        /// <summary>
        /// Register instances.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="instance">Instance</param>
        public static void Register<T>(T instance)
            where T : class
        {
            _container[typeof(T)] = instance;
        }

        /// <summary>
        /// Register classes that inherit from abstract classes.
        /// </summary>
        /// <typeparam name="TAbstract">Abstract Type</typeparam>
        /// <typeparam name="TConcrete">Concrete Type</typeparam>
        public static void Register<TAbstract, TConcrete>()
            where TAbstract : class
            where TConcrete : TAbstract
        {
            _container[typeof(TAbstract)] = Activator.CreateInstance(typeof(TConcrete)) as TAbstract;
        }

        /// <summary>
        /// Unregister the specified type.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        public static void Unregister<T>()
            where T : class
        {
            if (_container.ContainsKey(typeof(T)))
            {
                _container.Remove(typeof(T));
            }
        }

        /// <summary>
        /// Get instance.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Instance</returns>
        public static T Resolve<T>()
            where T : class
        {
            if (_container.TryGetValue(typeof(T), out object obj))
            {
                return obj as T;
            }
            return null;
        }
    }

    /// <summary>
    /// Service Locator [Single Type]
    /// </summary>
    public static class Locator<T>
        where T : class
    {
        /// <summary>
        /// Instance
        /// </summary>
        public static T Instance { get; private set; }

        /// <summary>
        /// Whether the Instance exists or not.
        /// </summary>
        public static bool IsValid => Instance is not null;

        /// <summary>
        /// Register instances.
        /// </summary>
        /// <param name="instance"></param>
        public static void Register(T instance)
        {
            Instance = instance;
        }

        /// <summary>
        /// Unregister instances.
        /// </summary>
        /// <param name="instance"></param>
        public static void Unregister(T instance)
        {
            if (Instance == instance)
            {
                Instance = null;
            }
        }

        /// <summary>
        /// Abandoning an instance.
        /// </summary>
        public static void Clear()
        {
            Instance = null;
        }
    }
}