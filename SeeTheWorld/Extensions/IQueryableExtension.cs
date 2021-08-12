using System;
using System.Linq;

namespace SeeTheWorld.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Random<T>(this IQueryable<T> source, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (count == 0)
                return source.Take(0);

            var dataCount = source.Count();
            if (count >= dataCount)
                return source;

            // [0, dataCount - count)
            var indexRand = new Random().Next(0, dataCount - count);
            return source.Skip(indexRand).Take(count);
        }
    }
}
