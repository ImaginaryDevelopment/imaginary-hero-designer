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
                var srReader = new StreamReader(objWebResponse.GetResponseStream());

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

            var (dserver, duser, dchannel) = (
                MidsContext.Config.DSelServer.Replace(" (Default)", ""),
                MidsContext.Config.DNickName,
                MidsContext.Config.DChannel);
            var (clevel, carchetype, priPowerSet, secPowerSet, globRecharge, endRecovery, totalEndUse, toonName, datalink) = (
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
            var shrunkData = ShrinkTheDatalink(datalink);
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
                    guild = dserver,
                    channel = dchannel,
                    nickname = duser,
                    level = clevel,
                    name = toonName,
                    archetype = carchetype,
                    primpowerset = priPowerSet,
                    secpowerset = secPowerSet,
                    recharge = globRecharge,
                    //dmgbuff = mrb.TotalDamageBuff,
                    //regen = mrb.HPRegen,
                    recov = endRecovery,
                    //tohit = mrb.TotalToHit,
                    enduse = totalEndUse,
                    embedlink = embedurl
                });
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            if (httpResponse != null)
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    var result = streamReader.ReadToEnd();
                    switch (result)
                    {
                        case "Nickname not found in discord":
                        {
                            string message =
                                $"Submission Failed: Your discord nickname was not found in the {dserver} discord server.";
                            const string title = "Discord Export";
                            MessageBox.Show(message, title);
                            break;
                        }

                        case "Export Successful":
                        {
                            string message =
                                $"Submission Successful!! Your build should now be posted in {dchannel} on the {dserver} server.";
                            const string title = "Discord Export";
                            MessageBox.Show(message, title);
                            break;
                        }

                        case "Export Failed":
                        {
                            const string message =
                                "Submission Failed: Please check your discord export settings and make sure you have the latest version of Mids' Reborn : Hero Designer.";
                            const string title = "Discord Export";
                            MessageBox.Show(message, title);
                            break;
                        }

                        case "Failed to add export to queue":
                        {
                            const string message =
                                "Submission Failed: Possible server error, please contact the RebornTeam.";
                            const string title = "Discord Export";
                            MessageBox.Show(message, title);
                            break;
                        }

                        case "RebornBot is not in the discord server":
                        {
                            string message = $"Submission Failed: RebornBot was not found in {dserver}.";
                            const string title = "Discord Export";
                            MessageBox.Show(message, title);
                            break;
                        }
                    }
                }
        }
    }
}
