namespace Hero_Designer.My
{
    internal class MyApplication
    {

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
