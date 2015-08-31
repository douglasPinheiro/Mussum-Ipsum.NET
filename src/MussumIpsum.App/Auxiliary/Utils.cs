using System;
using System.Linq;

namespace MussumIpsum.App.Auxiliary
{
    public static class Utils
    {
        public static Random Random = new Random();

        public static T GetRandomFromList<T>(T[] list)
        {
            return list[Random.Next(0, list.Length)];
        }

        public static T GetRandomEnumValue<T>()
        {
            var values = System.Enum.GetValues(typeof(T)).Cast<T>().ToArray();
            return GetRandomFromList<T>(values);
        }
    }
}