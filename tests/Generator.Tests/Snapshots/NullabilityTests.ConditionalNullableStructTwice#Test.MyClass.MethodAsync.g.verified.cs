﻿//HintName: Test.MyClass.MethodAsync.g.cs
// <auto-generated/>
namespace Test;
partial class MyClass
{
    public void Method(int? myInt)
    {
        _ = (!myInt.HasValue?(int?)null: global::Test.Extension.DoSomething(myInt.Value));
    }
}