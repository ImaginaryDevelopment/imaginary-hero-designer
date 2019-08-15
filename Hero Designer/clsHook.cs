using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace Hero_Designer
{
    public static class Clshook
    {
        public static string DFileName;
        public static string DExt;

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

        public static string ShrinkTheDatalink(string strUrl)
        {
            var url = "http://tinyurl.com/api-create.php?url=" + strUrl;

            var objWebRequest = (HttpWebRequest)WebRequest.Create(url);
            objWebRequest.Method = "GET";
            using (var objWebResponse = (HttpWebResponse)objWebRequest.GetResponse())
            {
                var srReader = new StreamReader(objWebResponse.GetResponseStream() ?? throw new InvalidOperationException());

                var strHtml = srReader.ReadToEnd();

                srReader.Close();
                objWebResponse.Close();
                objWebRequest.Abort();

                return (strHtml);
            }
        }

        internal static async Task DiscordExport()
        {
            //Set vars and shrink the link
            Statistics displayStats = MidsContext.Character.DisplayStats;
            var num = MidsContext.Character.Level + 1;
            if (num > 50) num = 50;

            var (dServer, dUser, dChannel) = (
                MidsContext.Config.DSelServer.Replace(" (Default)", ""),
                MidsContext.Config.DNickName,
                MidsContext.Config.DChannel);
            var (cLevel, cArchetype, cPriPowerset, cSecPowerset, cGlobRecharge, cEndRecovery, cTotalEndUse, cToonName, cDatalink) = (
                Conversions.ToString(num),
                MidsContext.Character.Archetype.DisplayName,
                MidsContext.Character.Powersets[0].DisplayName,
                MidsContext.Character.Powersets[1].DisplayName,
                Strings.Format((float)(displayStats.BuffHaste(false) - 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%",
                Strings.Format(displayStats.EnduranceRecoveryPercentage(false), "###0") + "% (" + Strings.Format(displayStats.EnduranceRecoveryNumeric, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "/s)",
                //HPRegen: Strings.Format(displayStats.HealthRegenPercent(false), "###0") + "%",
                //TotalDamageBuff: Strings.Format(displayStats.BuffDamage(false) - 100f, "##0.#") + "%",
                Strings.Format(displayStats.EnduranceUsage, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "/s",
                //TotalToHit: Strings.Format(displayStats.BuffToHit, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%",
                MidsContext.Character.Name,
                MidsCharacterFileFormat.MxDBuildSaveHyperlink(false, true));
            var shrunkData = ShrinkTheDatalink(cDatalink);
            var embedurl = $"[Click Here to Download]({shrunkData})";
            byte[] data = Convert.FromBase64String("aHR0cDovL2hvb2tzLm1pZHNyZWJvcm4uY29tOjMwMDAvYXBpP3Rva2VuPVVtUWhUNGtEclMwZ0E1TUY1YUdsaTh6YllDVW1RaFQ0a0RyUzBnQTVNRjVhR2xpOHpiWUM=");
            string wString = Encoding.UTF8.GetString(data);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(wString);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(new
                {
                    guild = dServer,
                    channel = dChannel,
                    nickname = dUser,
                    level = cLevel,
                    name = cToonName,
                    archetype = cArchetype,
                    primpowerset = cPriPowerset,
                    secpowerset = cSecPowerset,
                    recharge = cGlobRecharge,
                    //dmgbuff = mrb.TotalDamageBuff,
                    //regen = mrb.HPRegen,
                    recov = cEndRecovery,
                    //tohit = mrb.TotalToHit,
                    enduse = cTotalEndUse,
                    embedlink = embedurl
                });
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
            {
                var result = streamReader.ReadToEnd();
                switch (result)
                {
                    case "Nickname not found in discord":
                        {
                            string message = $"Submission Failed: Your discord nickname was not found in the {dServer} discord server.";
                            string title = "Discord Export";
                            MessageBox.Show(message, title);
                            break;
                        }

                    case "Export Successful":
                        {
                            string message = $"Submission Successful!! Your build should now be posted in {dChannel} on the {dServer} server.";
                            string title = "Discord Export";
                            MessageBox.Show(message, title);
                            break;
                        }

                    case "Export Failed":
                        {
                            string message = "Submission Failed: Please check your discord export settings and make sure you have the latest version of Mids' Reborn : Hero Designer.";
                            string title = "Discord Export";
                            MessageBox.Show(message, title);
                            break;
                        }

                    case "Failed to add export to queue":
                        {
                            string message = "Submission Failed: Possible server error, please contact the RebornTeam.";
                            string title = "Discord Export";
                            MessageBox.Show(message, title);
                            break;
                        }

                    case "RebornBot is not in the discord server":
                        {
                            string message = $"Submission Failed: RebornBot was not found in the {dServer}.";
                            string title = "Discord Export";
                            MessageBox.Show(message, title);
                            break;
                        }
                }
            }
        }
    }
}
