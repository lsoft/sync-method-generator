﻿namespace Generator.Tests;

public class ExtensionMethodTests
{
    [Fact]
    public Task UnwrapGenericExtensionMethod() => """
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Zomp.SyncMethodGenerator.IntegrationTests
{
    using Extensi.ons123;
    partial class Extensions
    {
        [CreateSyncVersion]
        public static async Task HasGenericExtensionAsync(object o, CancellationToken ct)
        {
            var z = o.TryGetValue<Point>(out var item);
        }

        [CreateSyncVersion]
        public static async Task HasGeneric2ExtensionAsync(object o, CancellationToken ct)
        {
            var z = o.TryGetValue<Point, PointF>(out var _, out var _1);
        }
    }
}

namespace Extensi.ons123
{
    internal static class MyExtensionClass
    {
        public static bool TryGetValue<T>(this object _, out T? item)
        {
            item = default;
            return false;
        }

        public static bool TryGetValue<T1, T2>(this object _, out T1? item1, out T2? item2)
        {
            item1 = default;
            item2 = default;
            return false;
        }
    }
}
""".Verify(sourceType: SourceType.Full);

    [Fact]
    public Task LeftOfTheDotTest() => """
namespace Tests;

internal class Bar
{
    public static Bar Create() => new Bar();
}

partial class Class
{
    [Zomp.SyncMethodGenerator.CreateSyncVersion]
    public async Task MethodAsync()
    {
        _ = Bar.Create()?.DoSomething();
    }
}

internal static class BarExtension
{
    public static Bar DoSomething(this Bar bar) => bar;
}
""".Verify(sourceType: SourceType.Full);
}
