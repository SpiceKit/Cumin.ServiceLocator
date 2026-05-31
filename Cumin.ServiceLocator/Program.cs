Cumin.Locator<ITest>.Register(new Sample());

Cumin.Locator<ITest>.Instance?.Test();

Cumin.Locator<ITest>.Dispose();

Cumin.Locator<ITest>.Instance?.Test();