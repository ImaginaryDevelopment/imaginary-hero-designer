using System;
using System.Threading;
using Base.Master_Classes;
using midsControls;
using Microsoft.VisualBasic.CompilerServices;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace Hero_Designer
{
    public class Clshook
    {
        public string DFileName;
        public string DExt;

        /* Not used yet but maybe in next release
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
        }*/
   
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
            //Set vars and shrink the link
            var num = MidsContext.Character.Level + 1;
            if (num > 50) { num = 50; }
            var discordserver = MidsContext.Config.DSelServer.Replace(" (Default)", "");
            var discorduser = MidsContext.Config.DNickName;
            var discordchannel = MidsContext.Config.DChannel;
            var mrblevel = Conversions.ToString(num);
            var mrbarchetype = MidsContext.Character.Archetype.DisplayName;
            var mrbprimarypower = MidsContext.Character.Powersets[0].DisplayName;
            var mrbsecondarypower = MidsContext.Character.Powersets[1].DisplayName;
            var mrbdatalink = MidsCharacterFileFormat.MxDBuildSaveHyperlink(false, true);
            Thread.Sleep(1000);
            var shrunkData = ShrinkTheDatalink(mrbdatalink);
            var embedurl = $"[Click Here to Download]({shrunkData})";



            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://hooks.midsreborn.com:3000/api?token=UmQhT4kDrS0gA5MF5aGli8zbYCUmQhT4kDrS0gA5MF5aGli8zbYC");
            httpWebRequest.ContentType = "application/json";

            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    guild = discordserver,
                    channel = discordchannel,
                    nickname = discorduser,
                    level = mrblevel,
                    archetype = mrbarchetype,
                    primpowerset = mrbprimarypower,
                    secpowerset = mrbsecondarypower, 
                    embedlink = embedurl
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (result == "Nickname not found in discord")
                {
                    string message = "Submission Failed! Check the Discord settings under configuration.";
                    string title = "Discord Export";
                    MessageBox.Show(message, title);
                }
                else if (result == "Nickname found")
                {
                    string message = "Submission Successful!! Your build should now be posted.";
                    string title = "Discord Export";
                    MessageBox.Show(message, title);
                }
            }
            Thread.Sleep(1000);
        }
    }
}
