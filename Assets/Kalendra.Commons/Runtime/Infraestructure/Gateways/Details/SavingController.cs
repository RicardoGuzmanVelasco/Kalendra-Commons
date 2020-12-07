using System;
using System.Collections.Generic;
using AndrewLord.UnityPowerPrefs;
using Wolves.Utils.Serialization;
using Wolves.Utils.StaticExtensions;

namespace Wolves.Utils.Persistence
{
    public static class SavingController
    {
        #region Cache
        static readonly Dictionary<string, object> cache = new Dictionary<string, object>();
        public static void ClearCache()
        {
            cache.Clear();
        }
        #endregion

        #region Load
        public static T ForceLoad<T>(object extraInfo = null) where T : class, IJsonizable, new()
        {
            return Load<T>(true, extraInfo?.ToString() ?? "");
        }
        
        public static T Load<T>(object extraInfo = null) where T : class, IJsonizable, new()
        {
            return Load<T>(false, extraInfo?.ToString() ?? "");
        }
        static T Load<T>(bool force, string nameExtraInfo = "") where T : class, IJsonizable, new()
        {
            var jsonizable = new T();
            var typeName = TypeExtensions.RuntimeNameOf(jsonizable);
            var savingName = typeName + nameExtraInfo;
            
            //Already in cache.
            if(!force && cache.ContainsKey(savingName))
                return cache[savingName] as T;

            //Not in cache.
            var json = PowerPrefs.ForString().Get(savingName);

            if(!string.IsNullOrEmpty(json)) //BUG?: selfsaving when creating was deleted to avoid dummy savings.
            {
                jsonizable.FromJson(json);
                cache[savingName] = jsonizable;
            }

            return jsonizable;
        }

        public static T[] LoadBunch<T>(object[] extraInfos) where T : class, IJsonizable, new()
        {
            var bunch = new T[extraInfos.Length];

            for(var i = 0; i < extraInfos.Length; i++)
                bunch[i] = Load<T>(extraInfos[i]);

            return bunch;
        }

        public static void LoadAsync<T>(Action<T> receiver, object extraInfo = null) where T : class, IJsonizable, new()
        {
         //TODO: conexión con backend cuando sea necesario.
         var result = Load<T>(extraInfo);
         receiver.Invoke(result);
        }
        
        #endregion
        
        #region Save
        public static void Save<T>(T savingData, object extraInfo = null) where T : class, IJsonizable, new()
        {
            Save(savingData, extraInfo?.ToString() ?? "");
        }
        static void Save<T>(T savingData, string nameExtraInfo = "") where T : IJsonizable
        {
            var typeName = TypeExtensions.RuntimeNameOf(savingData);
            var savingName = typeName + nameExtraInfo;
            
            //Reminder: []operator updates or adds if is not.
            cache[savingName] = savingData;

            var json = savingData.ToJson();
            PowerPrefs.ForString().Set(typeName + nameExtraInfo, json);
        }
        #endregion
        
        #region Reset
        public static void Reset<T>(T savingData, object extraInfo = null) where T : class, IJsonizable, new()
        {
            var emptySaving = new T();
            Save(emptySaving, extraInfo);
        }
        public static void Reset<T>(object extraInfo = null) where T : class, IJsonizable, new()
        {
            var emptySaving = new T();
            Save(emptySaving, extraInfo);
        }
        #endregion
    }
}