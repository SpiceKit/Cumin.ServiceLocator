using UnityEngine;

public class ServiceA : IService
{
	void IService.Log(string message)
	{
		Debug.Log($"[ServiceA]: {message}");
	}
}

public class ServiceB : IService
{
	void IService.Log(string message)
	{
		Debug.Log($"[ServiceB]: {message}");
	}
}