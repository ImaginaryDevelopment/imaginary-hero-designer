
using Base;
using Base.IO_Classes;
using Base.Master_Classes;
using Hero_Designer.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
#if NET20
#else
using System.Net.Http;
#endif
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Hero_Designer
{
    public class clsXMLUpdate
    {

        public bool RestartNeeded = false;

        public clsXMLUpdate()
        {
        }
        public static void BugReport(string at, string pri, string sec, string sData = "")
        {
            var targetUrl = "https://github.com/ImaginaryDevelopment/imaginary-hero-designer/issues";
            try
            {
                if (sData.Length > 0)
                {
                    sData = sData.Replace("\r\n", "-");
                    if (sData.Length > 96)
                        sData = sData.Substring(0, 96);
                }
                string str = "?" + "body=" + Strings.Format(Base.Master_Classes.MidsContext.AppVersion, "##0.#####") + "&db=" + Strings.Format(DatabaseAPI.Database.Version, "##0.#####") + " (" + Strings.Format(DatabaseAPI.Database.Date, "dd/MM/yy") + ")" + "&at=" + at + "&p=" + pri + "&s=" + sec + "&OS=" + OS.GetQuickOsid();
                if (sData != "")
                    str = str + "&data=" + sData;
                Process.Start(targetUrl);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Interaction.MsgBox(@"There was an error launching the default web browser to visit:"
                + "\r\n" + targetUrl + "\r\n"
                + ex.Message, MsgBoxStyle.Critical, "Error");
                ProjectData.ClearProjectError();
            }
        }

        public static void Donate()
        {
        }

        public static void GoToCoHPlanner() =>
                clsXMLUpdate.LaunchBrowser("https://github.com/ImaginaryDevelopment/imaginary-hero-designer/");

        public static void GoToForums()
        {
            clsXMLUpdate.LaunchBrowser("https://forums.homecomingservers.com/index.php/topic,6298.0.html");
        }

        static void LaunchBrowser(string iURI)
        {
            try
            {
                Process.Start(iURI);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Interaction.MsgBox(("There was an error starting the default web browser: " + ex.Message), MsgBoxStyle.Exclamation, "Aiee!");
                ProjectData.ClearProjectError();
            }
        }
        const string readmeUrl = "https://raw.githubusercontent.com/ImaginaryDevelopment/imaginary-hero-designer/master/README.md";

        public (eCheckResponse, string) UpdateCheck()
        {
            string response = null;
            try
            {
#if NET20
                using(var client = new WebClient())
                {
                    response = client.DownloadString(readmeUrl);
                }
#else
                using (var client = new HttpClient())
                    response = client.GetStringAsync(readmeUrl).Result;
#endif

            }
            catch (Exception ex)
            {
                var msg = $"Failed to download update information ({ex.Message}) from update :" + readmeUrl;
                return (eCheckResponse.FailedWithMessage, msg);
            }

            if (response.IsNullOrWhiteSpace())
            {
                var msg = "Failed to reach update url: " + readmeUrl;
                return (eCheckResponse.FailedWithMessage, msg);
            }
            string remoteversion;
            try
            {
                remoteversion = response.After("Latest Version").Trim().GetLine(0).Trim().Before("-").Trim();
            }
            catch (Exception ex)
            {
                var msg = $"Failed parse text ({ex.Message}) from update url:" + readmeUrl;
                return (eCheckResponse.FailedWithMessage, msg);
            }
            Version availVer;
            try
            {
                availVer = new Version(remoteversion);
            }
            catch (Exception ex)
            {
                var msg = $"Failed parse version ('{remoteversion}',{ex.Message}) from update url:" + readmeUrl;
                return (eCheckResponse.FailedWithMessage, msg);
            }
            try
            {
                var runningVer = typeof(frmMain).Assembly.GetName().Version;
                // I don't trust that != isn't reference comparison for the version type
                if (runningVer.CompareTo(availVer) < 0) return (eCheckResponse.Updates, $"Version {remoteversion}, installed is {runningVer.ToString()}");
                return (eCheckResponse.NoUpdates, null);
            }
            catch (Exception ex)
            {
                var msg = $"Failed compare versions ('{remoteversion}',{ex.Message}) from update url: {readmeUrl}";
                return (eCheckResponse.FailedWithMessage, msg);
            }
        }

        public enum eCheckResponse
        {
            NoUpdates,
            Updates,
            FailedWithMessage,
        }

        protected enum eUpdateType
        {
            None,
            AppUpdate,
            DBUpdate,
        }
    }
}
