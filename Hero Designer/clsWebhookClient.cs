using System;
using System.Threading;
using Base.Master_Classes;
using Discord;
using Discord.Webhook;
using midsControls;
using Microsoft.VisualBasic.CompilerServices;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Discord.Net.Queue;
using Nancy.Json;

namespace Hero_Designer
{
    public class ClsWebhook
    {
        public string DFileName;
        public string DExt;


        public static string GetDescription(Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, 
                        typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
   
        private string ShrinkTheDatalink(string strUrl)
        {
            var URL = "http://tinyurl.com/api-create.php?url=" + strUrl.ToLower();

            var objWebRequest = (HttpWebRequest) WebRequest.Create(URL);
            objWebRequest.Method = "GET";

            var objWebResponse = (HttpWebResponse) objWebRequest.GetResponse();
            var srReader = new StreamReader(objWebResponse.GetResponseStream());

            var strHtml = srReader.ReadToEnd();

            srReader.Close();
            objWebResponse.Close();
            objWebRequest.Abort();

            return (strHtml);
        }

        public async void MainAsync()
        {

            var usernick = MidsContext.Config.DNickName;
            var datalink = MidsCharacterFileFormat.MxDBuildSaveHyperlink(false, true);
            Thread.Sleep(1000);
            var shrunkData = ShrinkTheDatalink(datalink);
            var embedurl = $"[Click Here to Download]({shrunkData})";
            int num = MidsContext.Character.Level + 1;
            if (num > 50) { num = 50; }



            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://hooks.midsreborn.com:3000/api/?token=UmQhT4kDrS0gA5MF5aGli8zbYCUmQhT4kDrS0gA5MF5aGli8zbYC");
            httpWebRequest.ContentType = "application/json";

            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    guild = "Mids Reborn",
                    channel = "feature-testing",
                    archetype = "Level " + Conversions.ToString(num) + " " + MidsContext.Character.Archetype.DisplayName, 
                    nickname = usernick,
                    field1 = MidsContext.Character.Powersets[0].DisplayName,
                    field2 = MidsContext.Character.Powersets[1].DisplayName,
                    field3 = embedurl
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
            Thread.Sleep(1000);
        }
    }
}
