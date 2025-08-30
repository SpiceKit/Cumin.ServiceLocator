using UnityEngine;

public class LocaterUser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cumin.Locator.Register<IService, ServiceA>();

        Cumin.Locator.Resolve<IService>()?.Log("ロケーターを使用 (1回目)");

		Cumin.Locator.Unregister<IService>();

		Cumin.Locator.Resolve<IService>()?.Log("ロケーターを使用 (2回目)");

		Cumin.Locator.Register<IService, ServiceB>();

		Cumin.Locator.Resolve<IService>()?.Log("ロケーターを使用 (3回目)");
	}
}
