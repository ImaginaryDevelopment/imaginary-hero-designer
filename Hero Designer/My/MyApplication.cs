using System;

namespace Hero_Designer.My
{
    internal class MyApplication
    {
        public class Serializer : ISerialize
        {
            readonly Func<object, string> _serializeFunc;
            public string Extension { get; }
            public Serializer(Func<object, string> serializeFunc, string extension)
            {
                Extension = extension;
                _serializeFunc = serializeFunc;
            }
            public string Serialize(object o) => _serializeFunc(o);
            public T Deserialize<T>(string x) => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(x);
        }
        public static ISerialize GetSerializer()
        {
            return new Serializer(x =>
                Newtonsoft.Json.JsonConvert.SerializeObject(x,
                    Newtonsoft.Json.Formatting.Indented
                    , settings: new Newtonsoft.Json.JsonSerializerSettings()
                    {
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                        PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None,
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                        DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore,

                    }
                    ), "json");
        }

    }
}
