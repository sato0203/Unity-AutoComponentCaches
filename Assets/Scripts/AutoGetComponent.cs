using UnityEngine;
using System.Collections;

public class AutoGetComponent<T> where T :Component{

	private T _instance;
	public T Instance(MonoBehaviour behaviour)
	{ 
		if (_instance == null)
		{
			_instance = behaviour.GetComponent<T>();
		}
		return _instance;
	}



}
