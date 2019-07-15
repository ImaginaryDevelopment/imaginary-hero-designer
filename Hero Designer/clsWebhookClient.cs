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

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:3000/api/webhooks/");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    user = "Foo",
                    password = "Baz"
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            //Webhook will not be put in the client, instead it will be resolved from outside source. The one below is for testing.
            //var clsIMG = "https://cdn.discordapp.com/attachments/598239101996498974/598239347719929856/Class_Arachnos_Soldier.png";
            /*using (var client = new DiscordWebhookClient("http://127.0.0.1:3000/testmrb77129h%67#3"))
            {
                var author = new EmbedAuthorBuilder()
                    .WithName("Level " + Conversions.ToString(num) + " " + MidsContext.Character.Archetype.DisplayName);
                    //.WithIconUrl(eImage);
                var footer = new EmbedFooterBuilder()
                    .WithText($"Submitted by {usernick}")
                    .WithIconUrl("https://discordapp.com/assets/28174a34e77bb5e5310ced9f95cb480b.png");
                var field1 = new EmbedFieldBuilder()
                    .WithName("Primary Powerset")
                    .WithValue(MidsContext.Character.Powersets[0].DisplayName)
                    .WithIsInline(true);
                var field2 = new EmbedFieldBuilder()
                    .WithName("Secondary Powerset")
                    .WithValue(MidsContext.Character.Powersets[1].DisplayName)
                    .WithIsInline(true);
                var field3 = new EmbedFieldBuilder()
                    .WithName("Download This Build")
                    .WithValue(embedurl)
                    .WithIsInline(false);
                var embed = new EmbedBuilder()
                    .AddField(field1)
                    .AddField(field2)
                    .AddField(field3)
                    .WithAuthor(author)
                    .WithFooter(footer);

                //Webhooks are able to send multiple embeds per message, embeds must be passed as a collection.

                await client.SendMessageAsync(text: "New build submitted!", false, embeds: new[] { embed.Build() });*/
            Thread.Sleep(1000);
            }
        }
    }
//}

// TO DO -- Code in portion for Acknowledging usernames in the submitted by, and code in the avatar images for title.