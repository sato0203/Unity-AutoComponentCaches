using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AutoComponentCathes
{
	/// <summary>
	/// GetComponent等を自動で行ってくれる。
	/// </summary>
	public static class AutoComponentCathesManager
	{
		#region public
		/// <summary>
		/// GetComponentの自動化
		/// </summary>
		/// <returns>The get component.</returns>
		/// <param name="behaviour">Behaviour.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T AutoGetComponent<T>(this MonoBehaviour behaviour) where T : Object
		{
			string hashKey = GetComponentHashForGetComponent(behaviour.gameObject, typeof(T));
			var ls = getComponentList;

			bool isAlreadySet = ls.ContainsKey(hashKey);
			if (!isAlreadySet)
			{
				var theComponent = behaviour.GetComponent<T>();
				ls.Add(hashKey, theComponent);
			}
			return (T)ls[hashKey];
		}
		/// <summary>
		/// GetComponentsの自動化
		/// </summary>
		/// <returns>The get component.</returns>
		/// <param name="behaviour">Behaviour.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T[] AutoGetComponents<T>(this MonoBehaviour behaviour) where T : Object
		{
			string hashKey = GetComponentHashForGetComponent(behaviour.gameObject, typeof(T));
			var ls = getComponentsList;

			bool isAlreadySet = ls.ContainsKey(hashKey);
			if (!isAlreadySet)
			{
				var theComponents = behaviour.GetComponents<T>();
				ls.Add(hashKey, theComponents);
			}
			return (T[])ls[hashKey];
		}
		/// <summary>
		/// GetComponentInChildrenの自動化
		/// </summary>
		/// <returns>The get component.</returns>
		/// <param name="behaviour">Behaviour.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T AutoGetComponentInChildren<T>(this MonoBehaviour behaviour) where T : Object
		{
			string hashKey = GetComponentHashForGetComponent(behaviour.gameObject, typeof(T));
			var ls = getComponentInChildrenList;

			bool isAlreadySet = ls.ContainsKey(hashKey);
			if (!isAlreadySet)
			{
				var theComponent = behaviour.GetComponentInChildren<T>();
				ls.Add(hashKey, theComponent);
			}
			return (T)ls[hashKey];
		}
		/// <summary>
		/// GetComponentsInChildrenの自動化
		/// </summary>
		/// <returns>The get component.</returns>
		/// <param name="behaviour">Behaviour.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T[] AutoGetComponentsInChildren<T>(this MonoBehaviour behaviour) where T : Object
		{
			string hashKey = GetComponentHashForGetComponent(behaviour.gameObject, typeof(T));
			var ls = getComponentsInChildrenList;

			bool isAlreadySet = ls.ContainsKey(hashKey);
			if (!isAlreadySet)
			{
				var theComponents = behaviour.GetComponentsInChildren<T>();
				ls.Add(hashKey, theComponents);
			}
			return (T[])ls[hashKey];
		}

		/// <summary>
		/// FindObjectOfTypeの自動化
		/// </summary>
		/// <returns>The get component.</returns>
		/// <param name="behaviour">Behaviour.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T AutoFindObject<T>(this MonoBehaviour behaviour) where T : Object
		{
			string hashKey = GetComponentHashForFindObject(typeof(T));
			var ls = findObjectList;

			bool isAlreadySet = ls.ContainsKey(hashKey);
			if (!isAlreadySet)
			{
				var theComponent = Object.FindObjectOfType<T>();
				ls.Add(hashKey, theComponent);
			}
			return (T)ls[hashKey];
		}

		/// <summary>
		/// FindObjectsOfTypeの自動化
		/// </summary>
		/// <returns>The get component.</returns>
		/// <param name="behaviour">Behaviour.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T[] AutoFindObjects<T>(this MonoBehaviour behaviour) where T : Object
		{
			string hashKey = GetComponentHashForFindObject(typeof(T));
			var ls = findObjectsList;

			bool isAlreadySet = ls.ContainsKey(hashKey);
			if (!isAlreadySet)
			{
				var theComponents = Object.FindObjectsOfType<T>();
				ls.Add(hashKey, theComponents);
			}
			return (T[])ls[hashKey];
		}

		#endregion


		#region private

		//コンポーネントを格納するDictionary
		private static Dictionary<string, Object> getComponentList = new Dictionary<string, Object>();
		private static Dictionary<string, Object[]> getComponentsList= new Dictionary<string, Object[]>();
		private static Dictionary<string, Object> getComponentInChildrenList = new Dictionary<string, Object>();
		private static Dictionary<string, Object[]> getComponentsInChildrenList = new Dictionary<string, Object[]>();
		private static Dictionary<string, Object> findObjectList = new Dictionary<string, Object>();
		private static Dictionary<string, Object[]> findObjectsList = new Dictionary<string, Object[]>();

		//コンポーネントごとのハッシュ値計算(GetComponent用)
		private static string GetComponentHashForGetComponent(GameObject behaviour, System.Type type)
		{
			//~はクラス名に使えないのでハッシュ値被り防止のために使用。
			string str = behaviour.GetInstanceID().ToString() + "~" + type.Name;
			return str;
		}
		//コンポーネントごとのハッシュ値計算(FindObject用)
		private static string GetComponentHashForFindObject(System.Type type)
		{
			string str = type.Name;
			return str;
		}

		#endregion
	}
}
