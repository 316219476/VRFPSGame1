/*******************
********************/
using UnityEngine;
using System.Collections;

public class ResourcesManager {

	/// <summary>
	/// 加载枪
	/// </summary>
	/// <returns>The gun.</returns>
	/// <param name="name">Name.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static T LoadGun<T>(string name) where T:AWeapon{
		string path = "Prefabs/"+name;
		T obj = Resources.Load<T> (path);
		T objResult = GameObject.Instantiate<T> (obj);
		return objResult;
	}
}
