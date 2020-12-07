using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Kalendra.Commons.Utils.Serialization
{
    public interface IJsonizable
    {
        string ToJson();
        void FromJson(string json);
    }
    
    [DataContract]
    public abstract class Jsonizable<T> : IJsonizable where T : new()
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void FromJson(string json)
        {
            JsonConvert.PopulateObject(json, this);
        }

        public static T CreateFromJson(string json) 
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public override string ToString() => ToJson();
    }
}