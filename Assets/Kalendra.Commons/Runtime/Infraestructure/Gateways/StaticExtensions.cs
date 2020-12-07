using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Wolves.Utils.StaticExtensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Finds the declaring type of a variable.
        /// </summary>
        public static Type GetStaticType<T>(T x)
        {
            return typeof(T);
        }

        /// <summary>
        /// As nameof() just works in compile time, using in generics returns "T".
        /// Thus this is the runtime version of nameof().
        /// </summary>
        /// <returns></returns>
        public static string RuntimeNameOf<T>(T type)
        {
            return type.GetType().Name;
        }

        public static string ToStringAuto<T>(T instance)
        {
            var result = string.Empty;
            
            foreach(var propertyInfo in instance.GetType().GetProperties())
                result += $"{propertyInfo.Name}: {propertyInfo.GetValue(instance)} | ";

            return result;
        }
    }

    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> PopulateWithEnum<TKey, TValue>() where TValue : new()
        {
            var dictionary = new Dictionary<TKey, TValue>();

            foreach(TKey key in Enum.GetValues(typeof(TKey)))
                dictionary.Add(key, new TValue());

            return dictionary;
        }
        
        public static Dictionary<TKey, TValue> PopulateWithEnumNull<TKey, TValue>() where TValue : class
        {
            var dictionary = new Dictionary<TKey, TValue>();

            foreach(TKey key in Enum.GetValues(typeof(TKey)))
                dictionary.Add(key, null);

            return dictionary;
        }
    }

    public static class ListExtensions
    {
        public static List<(T1, T2)> JoinAsTuples<T1, T2>(IList<T1> list1, IList<T2> list2)
        {
            if(list1.Count != list2.Count)
                throw new TargetParameterCountException($"{list1} and {list2} have different sizes.");
            
            var tuples = new List<(T1, T2)>();
                
            for(var i=0; i < list1.Count; i++)
                tuples.Add((list1[i], list2[i]));

            return tuples;
        }
        
        public static Dictionary<TKey, TValue> JoinAsDictionary<TKey, TValue>(IList<TKey> keys, IList<TValue> values)
        {
            if(keys.Count != values.Count)
                throw new TargetParameterCountException($"{keys} and {values} have different sizes.");
            
            var dictionary = new Dictionary<TKey, TValue>();
            for(var i=0; i < keys.Count; i++)
                dictionary.Add(keys[i], values[i]);

            return dictionary;
        }
    }

    public static class SystemExtensions
    {
        public static string Clipboard => GUIUtility.systemCopyBuffer;
    }

    public static class ObjectExtensions
    {
        public static void SafeDestroy(UnityObject obj)
        {
            if(Application.isPlaying)
                UnityObject.Destroy(obj);
            else
                UnityObject.DestroyImmediate(obj);
        }

        public static void SafeDestroy(Component component)
        {
            if(Application.isPlaying)
                UnityObject.Destroy(component);
            else
                UnityObject.DestroyImmediate(component);
        }
    }
}