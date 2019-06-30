
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

        IMessager mFrm;

        public bool RestartNeeded = false;
        frmZStatus sFrm;

        clsXMLUpdate.clsXMLItem[] Updates = new clsXMLUpdate.clsXMLItem[0];


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
                //Process.Start("http://www.honourableunited.org.uk/mhdreport.php" + "?" + "ver=" + Strings.Format((object) 1.962f, "##0.#####") + "&db=" + Strings.Format((object) DatabaseAPI.Database.Version, "##0.#####") + " (" + Strings.Format((object) DatabaseAPI.Database.Date, "dd/MM/yy") + ")&OS=" + OS.GetQuickOsid() + "&data=" + sData);
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
                string str = "?" + "body=" + Strings.Format(Base.Master_Classes.MidsContext.AppVersion, "##0.#####") + "&db=" + Strings.Format((object)DatabaseAPI.Database.Version, "##0.#####") + " (" + Strings.Format((object)DatabaseAPI.Database.Date, "dd/MM/yy") + ")" + "&at=" + at + "&p=" + pri + "&s=" + sec + "&OS=" + OS.GetQuickOsid();
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
            this.mFrm = null;
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
                Interaction.MsgBox((object)("There was an error starting the default web browser: " + ex.Message), MsgBoxStyle.Exclamation, (object)"Aiee!");
                ProjectData.ClearProjectError();
            }
        }

        bool LoadXMLStrings(string iString)

        {
            this.Updates = new clsXMLUpdate.clsXMLItem[2];
            int num1 = this.Updates.Length - 1;
            for (int index = 0; index <= num1; ++index)
                this.Updates[index] = new clsXMLUpdate.clsXMLItem();
            this.Updates[0].NodeName = "Update";
            this.Updates[0].nType = clsXMLUpdate.eUpdateType.AppUpdate;
            this.Updates[1].NodeName = "Database";
            this.Updates[1].nType = clsXMLUpdate.eUpdateType.DBUpdate;
            bool flag = false;
            int num2 = this.Updates.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (this.ReadXMLString(ref this.Updates[index], iString))
                    flag = true;
            }
            return flag;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        bool ReadXMLString(ref clsXMLUpdate.clsXMLItem item, string xmlString)
        {
            bool flag;
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader((TextReader)new StringReader(xmlString));
                if (xmlTextReader.IsStartElement("Planner"))
                {
                    xmlTextReader.MoveToAttribute("Version");
                    if (xmlTextReader.ReadAttributeValue())
                        Conversion.Val(xmlTextReader.Value);
                }
                int num = 0;
                do
                {
                    xmlTextReader.Read();
                    if (xmlTextReader.Name != item.NodeName)
                        ++num;
                    else
                        break;
                }
                while (num <= 50);
                xmlTextReader.ReadStartElement(item.NodeName);
                xmlTextReader.ReadStartElement("Name");
                item.DisplayName = xmlTextReader.ReadString();
                xmlTextReader.ReadEndElement();
                xmlTextReader.ReadStartElement("URI");
                item.SourceURI = xmlTextReader.ReadString();
                xmlTextReader.ReadEndElement();
                xmlTextReader.ReadStartElement("LocalDest");
                item.LocalDest = FileIO.AddSlash(MyProject.Application.Info.DirectoryPath) + xmlTextReader.ReadString();
                xmlTextReader.ReadEndElement();
                xmlTextReader.ReadStartElement("Size");
                item.Size = (int)Math.Round(Conversion.Val(xmlTextReader.ReadString().Replace(",", "").Replace(".", "")));
                xmlTextReader.ReadEndElement();
                xmlTextReader.ReadStartElement("Version");
                item.Version = (float)Conversion.Val(xmlTextReader.ReadString());
                xmlTextReader.ReadEndElement();
                xmlTextReader.ReadStartElement("Date");
                string[] strArray = xmlTextReader.ReadString().Split("/".ToCharArray());
                if (strArray[2].Length == 2)
                    strArray[2] = "20" + strArray[2];
                item.VersionDate = new DateTime(Conversions.ToInteger(strArray[2]), Conversions.ToInteger(strArray[1]), Conversions.ToInteger(strArray[0]));
                xmlTextReader.ReadEndElement();
                xmlTextReader.ReadStartElement("Restart");
                string str1 = xmlTextReader.ReadString();
                item.Restart = str1 == "YES" | str1 == "1";
                xmlTextReader.ReadEndElement();
                xmlTextReader.ReadStartElement("Manual");
                string str2 = xmlTextReader.ReadString();
                item.Manual = str2 == "YES" | str2 == "1";
                xmlTextReader.ReadEndElement();
                xmlTextReader.ReadStartElement("Notes");
                item.Notes = xmlTextReader.ReadString().Replace("^", "\r\n");
                xmlTextReader.ReadEndElement();
                xmlTextReader.ReadEndElement();
                xmlTextReader.Close();
                flag = true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
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
