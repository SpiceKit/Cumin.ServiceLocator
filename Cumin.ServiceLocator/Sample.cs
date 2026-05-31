using System;
using System.Collections.Generic;
using System.Text;

public interface ITest
{
	void Test();
}
public class Sample : ITest
{
	public void Test()
	{
		Console.WriteLine("Test");
	}
}