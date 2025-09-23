using UnityEngine;
using RVSpiceKit.Cumin;

public class LocaterUser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Locator.Register<IService, ServiceA>();

        Locator.Resolve<IService>()?.Log("ロケーターを使用 (1回目)");

		Locator.Unregister<IService>();

		Locator.Resolve<IService>()?.Log("ロケーターを使用 (2回目)");

		Locator.Register<IService, ServiceB>();

		Locator.Resolve<IService>()?.Log("ロケーターを使用 (3回目)");
	}
}
