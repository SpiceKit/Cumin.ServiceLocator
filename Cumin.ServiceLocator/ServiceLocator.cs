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

namespace Cumin
{
	public static class Locator<T>
		where T : class
	{
		public static T? Instance { get; private set; }

		public static bool IsValid => Instance is not null;

		public static void Register(T instance) => Instance = instance;

		public static void Dispose() => Instance = null;
	}

	public static class CompositeLocator
	{
		private static Dictionary<Type, object> _container = new Dictionary<Type, object>();

		public static void Register<T>()
			where T : class
			=> _container[typeof(T)] = Activator.CreateInstance<T>();

		public static void Register<T>(T instance)
			where T : class
			=> _container[typeof(T)] = instance;

		public static void Register<TAbstract, TConcrete>()
			where TAbstract : class
			where TConcrete : TAbstract
			=> _container[typeof(TAbstract)] = Activator.CreateInstance<TConcrete>();

		public static void Unregister<T>()
			where T : class
		{
			if (_container.ContainsKey(typeof(T)))
			{
				_container.Remove(typeof(T));
			}
		}

		public static T? Resolve<T>() 
			where T : class
			=> _container.TryGetValue(typeof(T), out object? obj) ? obj as T : null;

		public static void Clear() => _container.Clear();
	}
}
