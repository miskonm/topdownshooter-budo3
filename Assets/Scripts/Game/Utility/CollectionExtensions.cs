using System;
using System.Collections.Generic;
using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.Utility
{
    public static class CollectionExtensions
    {
        public static void Fill<TKey, TValue>(this Dictionary<TKey, TValue> dict, string tag, ICollection<TValue> array,
            Func<TValue, TKey> getKey)
        {
            dict.Clear();

            if (array == null)
                return;

            foreach (TValue value in array)
            {
                TKey key = getKey.Invoke(value);

                if (!dict.ContainsKey(key))
                    dict.Add(key, value);
                else
                    Debug.LogError($"{tag}, {nameof(Fill)}: There is duplicated settings with type '{key}'");
            }
        }
    }
}