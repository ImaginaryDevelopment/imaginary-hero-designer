
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
        readonly string _uriUpdatePath = "";

        IMessager mFrm;

        public bool RestartNeeded = false;
        frmZStatus sFrm;

        clsXMLUpdate.clsXMLItem[] Updates = new clsXMLUpdate.clsXMLItem[0];


        public clsXMLUpdate(string path)
        {
            this._uriUpdatePath = path;
        }

        bool ApplyUpdate(ref int updateId)

        {
            DateTime iDate = new DateTime(1, 1, 1);
            string empty = string.Empty;
            bool flag;
            if (System.IO.File.Exists(this.Updates[updateId].LocalDest) && new Zlib().UnPack(MyProject.Application.Info.DirectoryPath, this.Updates[updateId].LocalDest, ref iDate, ref empty) > 0)
            {
                System.IO.File.Delete(this.Updates[updateId].LocalDest);
                flag = true;
            }
            else
                flag = false;
            return flag;
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

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static void LaunchSelfUpdate()
        {
            return;
            Process process = (Process)null;
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = FileIO.AddSlash(MyProject.Application.Info.DirectoryPath) + "MHDLoader.exe"
            };
            if (Environment.OSVersion.Version.Major >= 6)
                startInfo.Verb = "runas";
            startInfo.Arguments = "";
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.UseShellExecute = true;
            try
            {
                process = Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
            finally
            {
                process?.Dispose();
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

        public static void MailMe()
        {
            //clsXMLUpdate.LaunchBrowser("mailto:midsteam@cohtitan.com&subject=Mids' Hero Designer");
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

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        bool RequestWithProgress(ref int updateId)

        {
            byte[] numArray = new byte[16385];
            int count = 16384;
            FileStream fileStream = null;
            BinaryWriter binaryWriter = null;
            string str1 = FileIO.AddSlash(MyProject.Application.Info.DirectoryPath) + "Autoupdate.tmp";
            this.SetMessage("Requesting file: ", this.Updates[updateId].DisplayName);
            if (System.IO.File.Exists(str1))
                System.IO.File.Delete(str1);
            HttpWebResponse httpWebResponse = null;
            Stream input = (Stream)null;
            BinaryReader binaryReader = (BinaryReader)null;
            bool flag1;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(this.Updates[updateId].SourceURI);
                httpWebRequest.Timeout = 20000;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                this.Updates[updateId].Size = (int)httpWebResponse.ContentLength;
                try
                {
                    fileStream = new FileStream(str1, FileMode.Create);
                    binaryWriter = new BinaryWriter((Stream)fileStream);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    httpWebResponse?.Close();
                    this.HideMessage();
                    if (!(!exception.Message.Contains("404") & !(exception.Message.ToLower().Contains("time") & exception.Message.ToLower().Contains("out")) & !exception.Message.Contains("resolved")))
                    {
                        string str2;
                        if (exception.Message.ToLower().Contains("time") & exception.Message.ToLower().Contains("out"))
                            str2 = "Unable to download update. The conenction timed out. The server may be busy. Please try again later.";
                        else if (exception.Message.Contains("404"))
                        {
                            str2 = "Unable to download update. The update package wasn't found on the server. If this problem persists, please submit a bug report from the Help menu.";
                        }
                        else
                        {
                            if (!exception.Message.Contains("resolved"))
                            {
                                int num = (int)Interaction.MsgBox((object)("Unable to download " + this.Updates[updateId].DisplayName + "\r\nError: " + exception.Message + OS.VistaUacErrorText() + "\r\n\r\nYou will now be directed to the bug report page. If this problem is a known issue, there will be instructions there for applying the update manually."), MsgBoxStyle.Exclamation, (object)"Update Error");
                                clsXMLUpdate.BugReport("Request." + this.Updates[updateId].DisplayName + "." + exception.Message);
                                bool flag2 = false;
                                ProjectData.ClearProjectError();
                                return flag2;
                            }
                            str2 = "Unable to download update. The conenction to the server could not be established. Please try again later.";
                        }
                        int num1 = (int)Interaction.MsgBox((object)str2, MsgBoxStyle.Exclamation, (object)"Update Error");
                        bool flag3 = false;
                        ProjectData.ClearProjectError();
                        return flag3;
                    }
                    ProjectData.ClearProjectError();
                }
                try
                {
                    bool flag2 = false;
                    this.SetMessage("Initiating Download...", "");
                    int num = 0;
                    input = httpWebResponse.GetResponseStream();
                    binaryReader = new BinaryReader(input);
                    if (num < this.Updates[updateId].Size)
                        flag2 = true;
                    while (flag2)
                    {
                        if (num + count > this.Updates[updateId].Size)
                            count = this.Updates[updateId].Size - num;
                        byte[] buffer = binaryReader.ReadBytes(count);
                        num += count;
                        binaryWriter.Write(buffer);
                        flag2 = num < this.Updates[updateId].Size;
                        this.SetMessage("Downloading: " + Strings.Format((object)((double)num / (double)this.Updates[updateId].Size * 100.0), "##0") + "%", "(" + Strings.Format((object)(int)Math.Round((double)num / 1024.0), "###,##0") + " of " + Strings.Format((object)(int)Math.Round((double)this.Updates[updateId].Size / 1024.0), "###,##0") + "KB) Done.");
                        Application.DoEvents();
                    }
                    binaryReader?.Close();
                    input?.Close();
                    httpWebResponse?.Close();
                    input?.Close();
                    binaryWriter?.Close();
                    fileStream?.Close();
                    if (System.IO.File.Exists(this.Updates[updateId].LocalDest))
                        System.IO.File.Delete(this.Updates[updateId].LocalDest);
                    System.IO.File.Move(str1, this.Updates[updateId].LocalDest);
                    return true;
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    binaryReader?.Close();
                    input?.Close();
                    httpWebResponse?.Close();
                    input?.Close();
                    binaryWriter?.Close();
                    fileStream?.Close();
                    this.HideMessage();
                    if (exception.Message.ToLower().Contains("time") & exception.Message.ToLower().Contains("out"))
                    {
                        int num1 = (int)Interaction.MsgBox((object)"Unable to download update. The conenction timed out. The server may be busy. Please try again later.", MsgBoxStyle.Exclamation, (object)"Update Error");
                    }
                    else
                    {
                        int num2 = (int)Interaction.MsgBox((object)("Unable to download " + this.Updates[updateId].DisplayName + "\r\nError: " + exception.Message + OS.VistaUacErrorText() + "\r\n\r\nYou will now be directed to the bug report page. If this problem is a known issue, there will be instructions there for applying the update manually."), MsgBoxStyle.Exclamation, (object)"Update Error");
                        clsXMLUpdate.BugReport("RWP." + this.Updates[updateId].DisplayName + "." + exception.Message);
                    }
                    bool flag2 = false;
                    ProjectData.ClearProjectError();
                    return flag2;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                binaryReader?.Close();
                input?.Close();
                httpWebResponse?.Close();
                input?.Close();
                binaryWriter?.Close();
                fileStream?.Close();
                this.HideMessage();
                if (exception.Message.ToLower().Contains("time") & exception.Message.ToLower().Contains("out"))
                {
                    int num1 = (int)Interaction.MsgBox((object)"Unable to download update. The conenction timed out. The server may be busy. Please try again later.", MsgBoxStyle.Exclamation, (object)"Update Error");
                }
                else if (exception.Message.Contains("404"))
                {
                    int num2 = (int)Interaction.MsgBox((object)"Unable to download update. The update package wasn't found on the server. If this problem persists, please submit a bug report from the Help menu.", MsgBoxStyle.Exclamation, (object)"Update Error");
                }
                else if (exception.Message.Contains("resolved"))
                {
                    int num3 = (int)Interaction.MsgBox((object)"Unable to download update. The conenction to the server could not be established. Please try again later.", MsgBoxStyle.Exclamation, (object)"Update Error");
                }
                else
                {
                    int num4 = (int)Interaction.MsgBox((object)("Unable to download " + this.Updates[updateId].DisplayName + "\r\nError: " + exception.Message + OS.VistaUacErrorText() + "\r\n\r\nYou will now be directed to the bug report page. If this problem is a known issue, there will be instructions there for applying the update manually."), MsgBoxStyle.Exclamation, (object)"Update Error");
                    clsXMLUpdate.BugReport("RWP." + this.Updates[updateId].DisplayName + "." + exception.Message);
                }
                flag1 = false;
                ProjectData.ClearProjectError();
            }
            return flag1;
        }

        bool RequestXMLVersionInfo()

        {
            string requestUriString = this._uriUpdatePath + "version.xml";
            byte[] numArray = new byte[16385];
            int count = 16384;
            string iString = "";
            HttpWebResponse httpWebResponse1 = (HttpWebResponse)null;
            BinaryReader binaryReader1 = (BinaryReader)null;
            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            int contentLength;
            Stream input;
            BinaryReader binaryReader2;
            BinaryReader binaryReader3;
            HttpWebResponse httpWebResponse2;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                httpWebRequest.Timeout = 20000;
                httpWebResponse1 = (HttpWebResponse)httpWebRequest.GetResponse();
                contentLength = (int)httpWebResponse1.ContentLength;
                if (contentLength == 0 | contentLength > 16384)
                    return false;
                input = httpWebResponse1.GetResponseStream();
                binaryReader2 = new BinaryReader(input);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                binaryReader1?.Close();
                httpWebResponse1?.Close();
                binaryReader3 = (BinaryReader)null;
                httpWebResponse2 = (HttpWebResponse)null;
                this.HideMessage();
                if (!exception.Message.Contains("404") & !exception.Message.Contains("timed out") & !exception.Message.Contains("resolved"))
                {
                    int num = (int)Interaction.MsgBox((object)("An error ocurred while checking for an online update.\r\nURL: " + requestUriString + "\r\nError: " + exception.Message), MsgBoxStyle.Exclamation, (object)"Update Error");
                }
                bool flag = false;
                ProjectData.ClearProjectError();
                return flag;
            }
            bool flag1;
            try
            {
                bool flag2 = false;
                int num = 0;
                if (num < contentLength)
                    flag2 = true;
                for (; flag2; flag2 = num < contentLength)
                {
                    if (num + count > contentLength)
                        count = contentLength - num;
                    byte[] bytes = binaryReader2.ReadBytes(count);
                    num += count;
                    iString += asciiEncoding.GetString(bytes, 0, bytes.Length);
                }
                binaryReader2?.Close();
                input?.Close();
                httpWebResponse1?.Close();
                binaryReader2 = (BinaryReader)null;
                input = (Stream)null;
                httpWebResponse1 = (HttpWebResponse)null;
                if (iString.Length > 0)
                    return this.LoadXMLStrings(iString);
                flag1 = false;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                binaryReader2?.Close();
                input?.Close();
                httpWebResponse1?.Close();
                binaryReader3 = (BinaryReader)null;
                httpWebResponse2 = (HttpWebResponse)null;
                this.HideMessage();
                int num = (int)Interaction.MsgBox((object)("An error ocurred while checking for an online update.\r\nURL: " + requestUriString + "\r\nError: " + exception.Message), MsgBoxStyle.Exclamation, (object)"Update Error");
                flag1 = false;
                ProjectData.ClearProjectError();
            }
            return flag1;
        }

        void SetMessage(string messageA, string messageB)
        {
            if (this.sFrm != null)
            {
                this.sFrm.SetText1(messageA);
                this.sFrm.SetText2(messageB);
                this.sFrm.Refresh();
            }
            else
            {
                if (this.mFrm == null)
                    return;
                this.mFrm.SetMessage(messageA);
            }
        }

        void ShowMessage(bool silent, ref IMessager iLoadFrm)

        {
            if (!silent & iLoadFrm == null)
            {
                this.sFrm = new frmZStatus();
                this.sFrm.Show();
                this.sFrm.Refresh();
            }
            else
                this.mFrm = iLoadFrm;
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

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        struct Keys

        {
            public const string DisplayName = "Name";
            public const string SourceURI = "URI";
            public const string DestFn = "LocalDest";
            public const string Size = "Size";
            public const string Version = "Version";
            public const string VersionDate = "Date";
            public const string Restart = "Restart";
            public const string Manual = "Manual";
            public const string Notes = "Notes";

            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Attribs
            {
                public const string Version = "Version";
            }

            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Nodes
            {
                public const string Main = "Planner";
                public const string AppUpdate = "Update";
                public const string DBUpdate = "Database";
            }
        }
    }
}
