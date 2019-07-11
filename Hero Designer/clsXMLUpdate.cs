
using Base.IO_Classes;
using Hero_Designer.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
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
        frmZStatus sFrm;

        public clsXMLUpdate(string path)
        {
        }

        static void BugReport(string sData)
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
                Process.Start(targetUrl);
                //Process.Start("http://www.honourableunited.org.uk/mhdreport.php" + "?" + "ver=" + Strings.Format( 1.962f, "##0.#####") + "&db=" + Strings.Format( DatabaseAPI.Database.Version, "##0.#####") + " (" + Strings.Format( DatabaseAPI.Database.Date, "dd/MM/yy") + ")&OS=" + OS.GetQuickOsid() + "&data=" + sData);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Interaction.MsgBox(targetUrl + "\r\n\r\n" + ex.Message, MsgBoxStyle.Critical, "Error");
                ProjectData.ClearProjectError();
            }
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
            clsXMLUpdate.LaunchBrowser("https://forums.homecomingservers.com/index.php/topic,5099.0.html");
        }

        public static void GoToTitan()
        {
            //clsXMLUpdate.LaunchBrowser("http://www.cohtitan.com/");
        }

        void HideMessage()
        {
            if (this.sFrm != null)
                this.sFrm.Hide();
            this.sFrm = null;
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

        public clsXMLUpdate.eCheckResponse UpdateCheck(bool silent, ref IMessager iLoadFrm)
        {
            var eCheckResponse = clsXMLUpdate.eCheckResponse.NoUpdates;
            return eCheckResponse;
        }

        protected class clsXMLItem
        {
            public string DisplayName = "";
            public string LocalDest = "";
            public bool Manual = true;
            public string NodeName = "";
            public string Notes = "";
            public clsXMLUpdate.eUpdateType nType = clsXMLUpdate.eUpdateType.None;
            public bool Restart = false;
            public int Size = 0;
            public string SourceURI = "";
            public float Version = 0.0f;
            public DateTime VersionDate = new DateTime(1, 1, 1);
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
