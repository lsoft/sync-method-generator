﻿//HintName: Test.EnumerableExtensions.GetAveragesAsync.g.cs
// <auto-generated/>
#nullable enable
namespace Test
{
    public static partial class EnumerableExtensions
    {
        public static global::System.Collections.Generic.IEnumerable<double> GetAverages<T>(this global::System.Collections.Generic.IEnumerable<T> list, int adjacentCount)
            where T : global::System.IConvertible
        {
            double total = 0;

            int avgCount = adjacentCount * 2 + 1;

            var meanQueue = new global::System.Collections.Generic.Queue<double>();
            foreach (var o in list)
            {
                var item = o.ToDouble(null);
                if (meanQueue.Count == avgCount)
                {
                    total -= meanQueue.Dequeue();
                }
                meanQueue.Enqueue(item);
                total += item;

                if (meanQueue.Count == avgCount)
                {
                    yield return total / avgCount;
                }
            }
        }
    }
}