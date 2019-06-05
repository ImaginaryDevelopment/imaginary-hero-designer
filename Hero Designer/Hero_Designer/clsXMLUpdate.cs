using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Base.IO_Classes;
using Hero_Designer.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x02000010 RID: 16
	public class clsXMLUpdate
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x000100A3 File Offset: 0x0000E2A3
		public clsXMLUpdate(string path)
		{
			this._uriUpdatePath = path;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000100E4 File Offset: 0x0000E2E4
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private bool ApplyUpdate(ref int updateId)
		{
			DateTime iDate = new DateTime(1, 1, 1);
			string empty = string.Empty;
			bool flag;
			if (File.Exists(this.Updates[updateId].LocalDest) && new Zlib().UnPack(MyProject.Application.Info.DirectoryPath, this.Updates[updateId].LocalDest, ref iDate, ref empty) > 0)
			{
				File.Delete(this.Updates[updateId].LocalDest);
				flag = true;
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0001017C File Offset: 0x0000E37C
		private static void BugReport(string sData)
		{
			try
			{
				if (sData.Length > 0)
				{
					sData = sData.Replace("\r\n", "-");
					if (sData.Length > 96)
					{
						sData = sData.Substring(0, 96);
					}
				}
				string text = "?";
				Process.Start(string.Concat(new string[]
				{
					"http://www.honourableunited.org.uk/mhdreport.php",
					text,
					"ver=",
					Strings.Format(1.962f, "##0.#####"),
					"&db=",
					Strings.Format(DatabaseAPI.Database.Version, "##0.#####"),
					" (",
					Strings.Format(DatabaseAPI.Database.Date, "dd/MM/yy"),
					")&OS=",
					OS.GetQuickOsid(),
					"&data=",
					sData
				}));
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				Interaction.MsgBox("There was an error launching the default web browser to visit:\r\nhttp://www.honourableunited.org.uk/mhdreport.php\r\n\r\n" + ex2.Message, MsgBoxStyle.Critical, "Error");
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000102D8 File Offset: 0x0000E4D8
		public static void BugReport(string at, string pri, string sec, string sData = "")
		{
			try
			{
				if (sData.Length > 0)
				{
					sData = sData.Replace("\r\n", "-");
					if (sData.Length > 96)
					{
						sData = sData.Substring(0, 96);
					}
				}
				string str = "?";
				str = string.Concat(new string[]
				{
					str,
					"ver=",
					Strings.Format(1.962f, "##0.#####"),
					"&db=",
					Strings.Format(DatabaseAPI.Database.Version, "##0.#####"),
					" (",
					Strings.Format(DatabaseAPI.Database.Date, "dd/MM/yy"),
					")"
				});
				str = string.Concat(new string[]
				{
					str,
					"&at=",
					at,
					"&p=",
					pri,
					"&s=",
					sec,
					"&OS=",
					OS.GetQuickOsid()
				});
				if (sData != "")
				{
					str = str + "&data=" + sData;
				}
				Process.Start("http://www.honourableunited.org.uk/mhdreport.php" + str);
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				Interaction.MsgBox("There was an error launching the default web browser to visit:\r\nhttp://www.honourableunited.org.uk/mhdreport.php\r\n\r\n" + ex2.Message, MsgBoxStyle.Critical, "Error");
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00010490 File Offset: 0x0000E690
		public static void Donate()
		{
			clsXMLUpdate.LaunchBrowser("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8057167");
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0001049E File Offset: 0x0000E69E
		public static void GoToCoHPlanner()
		{
			clsXMLUpdate.LaunchBrowser("http://www.cohplanner.com/");
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000104AC File Offset: 0x0000E6AC
		public static void GoToForums()
		{
			clsXMLUpdate.LaunchBrowser("http://www.cohtitan.com/forum/");
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000104BA File Offset: 0x0000E6BA
		public static void GoToTitan()
		{
			clsXMLUpdate.LaunchBrowser("http://www.cohtitan.com/");
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000104C8 File Offset: 0x0000E6C8
		private void HideMessage()
		{
			if (this.sFrm != null)
			{
				this.sFrm.Hide();
			}
			this.sFrm = null;
			this.mFrm = null;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00010500 File Offset: 0x0000E700
		private static void LaunchBrowser(string iURI)
		{
			try
			{
				Process.Start(iURI);
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				Interaction.MsgBox("There was an error starting the default web browser: " + ex2.Message, MsgBoxStyle.Exclamation, "Aiee!");
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0001055C File Offset: 0x0000E75C
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static void LaunchSelfUpdate()
		{
			Process process = null;
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = FileIO.AddSlash(MyProject.Application.Info.DirectoryPath) + "MHDLoader.exe"
			};
			if (Environment.OSVersion.Version.Major >= 6)
			{
				startInfo.Verb = "runas";
			}
			startInfo.Arguments = "";
			startInfo.WindowStyle = ProcessWindowStyle.Normal;
			startInfo.UseShellExecute = true;
			try
			{
				process = Process.Start(startInfo);
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				if (process != null)
				{
					process.Dispose();
				}
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00010648 File Offset: 0x0000E848
		private bool LoadXMLStrings(string iString)
		{
			this.Updates = new clsXMLUpdate.clsXMLItem[2];
			int num = this.Updates.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				this.Updates[index] = new clsXMLUpdate.clsXMLItem();
			}
			this.Updates[0].NodeName = "Update";
			this.Updates[0].nType = clsXMLUpdate.eUpdateType.AppUpdate;
			this.Updates[1].NodeName = "Database";
			this.Updates[1].nType = clsXMLUpdate.eUpdateType.DBUpdate;
			bool flag = false;
			int num2 = this.Updates.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				if (this.ReadXMLString(ref this.Updates[index], iString))
				{
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0001071C File Offset: 0x0000E91C
		public static void MailMe()
		{
			clsXMLUpdate.LaunchBrowser("mailto:midsteam@cohtitan.com&subject=Mids' Hero Designer");
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0001072C File Offset: 0x0000E92C
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private bool ReadXMLString(ref clsXMLUpdate.clsXMLItem item, string xmlString)
		{
			bool flag;
			try
			{
				StringReader input = new StringReader(xmlString);
				XmlTextReader xmlTextReader = new XmlTextReader(input);
				if (xmlTextReader.IsStartElement("Planner"))
				{
					xmlTextReader.MoveToAttribute("Version");
					if (xmlTextReader.ReadAttributeValue())
					{
						Conversion.Val(xmlTextReader.Value);
					}
				}
				int num = 0;
				do
				{
					xmlTextReader.Read();
					if (!(xmlTextReader.Name != item.NodeName))
					{
						break;
					}
					num++;
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
				{
					strArray[2] = "20" + strArray[2];
				}
				item.VersionDate = new DateTime(Conversions.ToInteger(strArray[2]), Conversions.ToInteger(strArray[1]), Conversions.ToInteger(strArray[0]));
				xmlTextReader.ReadEndElement();
				xmlTextReader.ReadStartElement("Restart");
				string str = xmlTextReader.ReadString();
				item.Restart = (str == "YES" | str == "1");
				xmlTextReader.ReadEndElement();
				xmlTextReader.ReadStartElement("Manual");
				string str2 = xmlTextReader.ReadString();
				item.Manual = (str2 == "YES" | str2 == "1");
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
				flag = false;
			}
			return flag;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00010A24 File Offset: 0x0000EC24
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private bool RequestWithProgress(ref int updateId)
		{
			bool flag = false;
			byte[] buffer = new byte[16385];
			int count = 16384;
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			string str = FileIO.AddSlash(MyProject.Application.Info.DirectoryPath) + "Autoupdate.tmp";
			this.SetMessage("Requesting file: ", this.Updates[updateId].DisplayName);
			if (File.Exists(str))
			{
				File.Delete(str);
			}
			HttpWebResponse httpWebResponse = null;
			Stream input = null;
			BinaryReader binaryReader = null;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(this.Updates[updateId].SourceURI);
				httpWebRequest.Timeout = 20000;
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				this.Updates[updateId].Size = (int)httpWebResponse.ContentLength;
				try
				{
					fileStream = new FileStream(str, FileMode.Create);
					binaryWriter = new BinaryWriter(fileStream);
				}
				catch (Exception ex)
				{
					Exception exception = ex;
					if (httpWebResponse != null)
					{
						httpWebResponse.Close();
					}
					this.HideMessage();
					if (!(!exception.Message.Contains("404") & !(exception.Message.ToLower().Contains("time") & exception.Message.ToLower().Contains("out")) & !exception.Message.Contains("resolved")))
					{
						string str2;
						if (exception.Message.ToLower().Contains("time") & exception.Message.ToLower().Contains("out"))
						{
							str2 = "Unable to download update. The conenction timed out. The server may be busy. Please try again later.";
						}
						else if (exception.Message.Contains("404"))
						{
							str2 = "Unable to download update. The update package wasn't found on the server. If this problem persists, please submit a bug report from the Help menu.";
						}
						else
						{
							if (!exception.Message.Contains("resolved"))
							{
								Interaction.MsgBox(string.Concat(new string[]
								{
									"Unable to download ",
									this.Updates[updateId].DisplayName,
									"\r\nError: ",
									exception.Message,
									OS.VistaUacErrorText(),
									"\r\n\r\nYou will now be directed to the bug report page. If this problem is a known issue, there will be instructions there for applying the update manually."
								}), MsgBoxStyle.Exclamation, "Update Error");
								clsXMLUpdate.BugReport("Request." + this.Updates[updateId].DisplayName + "." + exception.Message);
								flag = false;
								return flag;
							}
							str2 = "Unable to download update. The conenction to the server could not be established. Please try again later.";
						}
						Interaction.MsgBox(str2, MsgBoxStyle.Exclamation, "Update Error");
						flag = false;
						return flag;
					}
				}
				try
				{
					bool flag2 = false;
					string messageA = "Initiating Download...";
					this.SetMessage(messageA, "");
					int num = 0;
					input = httpWebResponse.GetResponseStream();
					binaryReader = new BinaryReader(input);
					if (num < this.Updates[updateId].Size)
					{
						flag2 = true;
					}
					while (flag2)
					{
						if (num + count > this.Updates[updateId].Size)
						{
							count = this.Updates[updateId].Size - num;
						}
						buffer = binaryReader.ReadBytes(count);
						num += count;
						binaryWriter.Write(buffer);
						flag2 = (num < this.Updates[updateId].Size);
						this.SetMessage("Downloading: " + Strings.Format((double)num / (double)this.Updates[updateId].Size * 100.0, "##0") + "%", string.Concat(new string[]
						{
							"(",
							Strings.Format((int)Math.Round((double)num / 1024.0), "###,##0"),
							" of ",
							Strings.Format((int)Math.Round((double)this.Updates[updateId].Size / 1024.0), "###,##0"),
							"KB) Done."
						}));
						Application.DoEvents();
					}
					if (binaryReader != null)
					{
						binaryReader.Close();
					}
					if (input != null)
					{
						input.Close();
					}
					if (httpWebResponse != null)
					{
						httpWebResponse.Close();
					}
					if (input != null)
					{
						input.Close();
					}
					if (binaryWriter != null)
					{
						binaryWriter.Close();
					}
					if (fileStream != null)
					{
						fileStream.Close();
					}
					if (File.Exists(this.Updates[updateId].LocalDest))
					{
						File.Delete(this.Updates[updateId].LocalDest);
					}
					File.Move(str, this.Updates[updateId].LocalDest);
					return true;
				}
				catch (Exception ex2)
				{
					Exception exception2 = ex2;
					if (binaryReader != null)
					{
						binaryReader.Close();
					}
					if (input != null)
					{
						input.Close();
					}
					if (httpWebResponse != null)
					{
						httpWebResponse.Close();
					}
					if (input != null)
					{
						input.Close();
					}
					if (binaryWriter != null)
					{
						binaryWriter.Close();
					}
					if (fileStream != null)
					{
						fileStream.Close();
					}
					this.HideMessage();
					if (exception2.Message.ToLower().Contains("time") & exception2.Message.ToLower().Contains("out"))
					{
						string str2 = "Unable to download update. The conenction timed out. The server may be busy. Please try again later.";
						Interaction.MsgBox(str2, MsgBoxStyle.Exclamation, "Update Error");
					}
					else
					{
						Interaction.MsgBox(string.Concat(new string[]
						{
							"Unable to download ",
							this.Updates[updateId].DisplayName,
							"\r\nError: ",
							exception2.Message,
							OS.VistaUacErrorText(),
							"\r\n\r\nYou will now be directed to the bug report page. If this problem is a known issue, there will be instructions there for applying the update manually."
						}), MsgBoxStyle.Exclamation, "Update Error");
						clsXMLUpdate.BugReport("RWP." + this.Updates[updateId].DisplayName + "." + exception2.Message);
					}
					flag = false;
					return flag;
				}
			}
			catch (Exception ex3)
			{
				Exception exception3 = ex3;
				if (binaryReader != null)
				{
					binaryReader.Close();
				}
				if (input != null)
				{
					input.Close();
				}
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
				if (input != null)
				{
					input.Close();
				}
				if (binaryWriter != null)
				{
					binaryWriter.Close();
				}
				if (fileStream != null)
				{
					fileStream.Close();
				}
				this.HideMessage();
				if (exception3.Message.ToLower().Contains("time") & exception3.Message.ToLower().Contains("out"))
				{
					string str2 = "Unable to download update. The conenction timed out. The server may be busy. Please try again later.";
					Interaction.MsgBox(str2, MsgBoxStyle.Exclamation, "Update Error");
				}
				else if (exception3.Message.Contains("404"))
				{
					string str2 = "Unable to download update. The update package wasn't found on the server. If this problem persists, please submit a bug report from the Help menu.";
					Interaction.MsgBox(str2, MsgBoxStyle.Exclamation, "Update Error");
				}
				else if (exception3.Message.Contains("resolved"))
				{
					string str2 = "Unable to download update. The conenction to the server could not be established. Please try again later.";
					Interaction.MsgBox(str2, MsgBoxStyle.Exclamation, "Update Error");
				}
				else
				{
					Interaction.MsgBox(string.Concat(new string[]
					{
						"Unable to download ",
						this.Updates[updateId].DisplayName,
						"\r\nError: ",
						exception3.Message,
						OS.VistaUacErrorText(),
						"\r\n\r\nYou will now be directed to the bug report page. If this problem is a known issue, there will be instructions there for applying the update manually."
					}), MsgBoxStyle.Exclamation, "Update Error");
					clsXMLUpdate.BugReport("RWP." + this.Updates[updateId].DisplayName + "." + exception3.Message);
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0001130C File Offset: 0x0000F50C
		private bool RequestXMLVersionInfo()
		{
			string requestUriString = this._uriUpdatePath + "version.xml";
			byte[] bytes = new byte[16385];
			int count = 16384;
			string iString = "";
			HttpWebResponse httpWebResponse = null;
			BinaryReader binaryReader2 = null;
			ASCIIEncoding asciiEncoding = new ASCIIEncoding();
			int contentLength;
			Stream input;
			bool flag;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.Timeout = 20000;
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				contentLength = (int)httpWebResponse.ContentLength;
				if (contentLength == 0 | contentLength > 16384)
				{
					return false;
				}
				input = httpWebResponse.GetResponseStream();
				binaryReader2 = new BinaryReader(input);
			}
			catch (Exception ex)
			{
				Exception exception = ex;
				if (binaryReader2 != null)
				{
					binaryReader2.Close();
				}
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
				binaryReader2 = null;
				httpWebResponse = null;
				this.HideMessage();
				if (!exception.Message.Contains("404") & !exception.Message.Contains("timed out") & !exception.Message.Contains("resolved"))
				{
					Interaction.MsgBox("An error ocurred while checking for an online update.\r\nURL: " + requestUriString + "\r\nError: " + exception.Message, MsgBoxStyle.Exclamation, "Update Error");
				}
				flag = false;
				return flag;
			}
			try
			{
				bool flag2 = false;
				int num = 0;
				if (num < contentLength)
				{
					flag2 = true;
				}
				while (flag2)
				{
					if (num + count > contentLength)
					{
						count = contentLength - num;
					}
					bytes = binaryReader2.ReadBytes(count);
					num += count;
					iString += asciiEncoding.GetString(bytes, 0, bytes.Length);
					flag2 = (num < contentLength);
				}
				if (binaryReader2 != null)
				{
					binaryReader2.Close();
				}
				if (input != null)
				{
					input.Close();
				}
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
				binaryReader2 = null;
				input = null;
				httpWebResponse = null;
				if (iString.Length > 0)
				{
					return this.LoadXMLStrings(iString);
				}
				flag = false;
			}
			catch (Exception ex2)
			{
				Exception exception2 = ex2;
				if (binaryReader2 != null)
				{
					binaryReader2.Close();
				}
				if (input != null)
				{
					input.Close();
				}
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
				binaryReader2 = null;
				input = null;
				httpWebResponse = null;
				this.HideMessage();
				Interaction.MsgBox("An error ocurred while checking for an online update.\r\nURL: " + requestUriString + "\r\nError: " + exception2.Message, MsgBoxStyle.Exclamation, "Update Error");
				flag = false;
			}
			return flag;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00011624 File Offset: 0x0000F824
		private void SetMessage(string messageA, string messageB)
		{
			if (this.sFrm != null)
			{
				this.sFrm.SetText1(messageA);
				this.sFrm.SetText2(messageB);
				this.sFrm.Refresh();
			}
			else if (this.mFrm != null)
			{
				this.mFrm.SetMessage(messageA);
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00011688 File Offset: 0x0000F888
		private void ShowMessage(bool silent, ref IMessager iLoadFrm)
		{
			if (!silent & iLoadFrm == null)
			{
				this.sFrm = new frmZStatus();
				this.sFrm.Show();
				this.sFrm.Refresh();
			}
			else
			{
				this.mFrm = iLoadFrm;
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000116D8 File Offset: 0x0000F8D8
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public clsXMLUpdate.eCheckResponse UpdateCheck(bool silent, ref IMessager iLoadFrm)
		{
			this.mFrm = iLoadFrm;
			this.ShowMessage(silent, ref iLoadFrm);
			this.SetMessage("Checking For Updates...", "");
			clsXMLUpdate.eCheckResponse eCheckResponse;
			if (!this.RequestXMLVersionInfo())
			{
				eCheckResponse = clsXMLUpdate.eCheckResponse.NoUpdates;
			}
			else
			{
				int updateId = -1;
				int num = this.Updates.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					clsXMLUpdate.clsXMLItem update = this.Updates[index];
					if (update.Version > 0f)
					{
						switch (update.nType)
						{
						case clsXMLUpdate.eUpdateType.AppUpdate:
							if (update.Version > 1.962f)
							{
								updateId = index;
								goto IL_E3;
							}
							break;
						case clsXMLUpdate.eUpdateType.DBUpdate:
							if (update.Version > DatabaseAPI.Database.Version)
							{
								updateId = index;
								goto IL_E3;
							}
							break;
						}
					}
				}
				IL_E3:
				if (updateId < 0)
				{
					this.HideMessage();
					eCheckResponse = clsXMLUpdate.eCheckResponse.NoUpdates;
				}
				else
				{
					bool flag = true;
					clsXMLUpdate.clsXMLItem update2 = this.Updates[updateId];
					if (update2.DisplayName == "")
					{
						flag = false;
					}
					if (update2.LocalDest == "")
					{
						flag = false;
					}
					if (update2.Size < 1)
					{
						flag = false;
					}
					if (update2.SourceURI == "")
					{
						flag = false;
					}
					this.HideMessage();
					if (flag)
					{
						string str5 = "An update for the ";
						switch (this.Updates[updateId].nType)
						{
						case clsXMLUpdate.eUpdateType.AppUpdate:
							str5 += "application";
							break;
						case clsXMLUpdate.eUpdateType.DBUpdate:
							str5 += "database";
							break;
						}
						str5 += " is available.\r\n";
						clsXMLUpdate.clsXMLItem update3 = this.Updates[updateId];
						str5 = str5 + "Update: " + update3.DisplayName + "\r\n";
						str5 = string.Concat(new string[]
						{
							str5,
							"Version: ",
							Conversions.ToString(update3.Version),
							" (",
							Strings.Format(update3.VersionDate, "Short Date"),
							")\r\n"
						});
						if (!update3.Manual)
						{
							str5 = str5 + "Size: " + Strings.Format((double)update3.Size / 1024.0, "###,##0") + " KB\r\n";
						}
						str5 = str5 + "Notes: " + update3.Notes + "\r\n";
						if (update3.Restart & !update3.Manual)
						{
							str5 += "\r\nUpdate will require the application to restart.\r\n";
						}
						if (update3.Manual)
						{
							str5 += "\r\nThis update requires you download and re-install fully. You will be directed to the download page.\r\n\r\nDownload this update now?";
						}
						else
						{
							str5 += "\r\nDownload and install this update now?";
						}
						if (Interaction.MsgBox(str5, MsgBoxStyle.YesNo | MsgBoxStyle.Information, "Automatic Update") == MsgBoxResult.Yes)
						{
							if (update3.Manual)
							{
								clsXMLUpdate.LaunchBrowser(update3.SourceURI);
								return clsXMLUpdate.eCheckResponse.Updates;
							}
							this.ShowMessage(silent, ref iLoadFrm);
							if (this.RequestWithProgress(ref updateId))
							{
								this.HideMessage();
								if (!update3.Restart)
								{
									if (this.ApplyUpdate(ref updateId))
									{
										this.ShowMessage(silent, ref iLoadFrm);
										this.SetMessage("Loading updated data...", "");
										frmLoading iFrm = null;
										MainModule.MidsController.LoadData(ref iFrm);
										this.HideMessage();
										Interaction.MsgBox("Update applied!", MsgBoxStyle.Information, "Done.");
										return clsXMLUpdate.eCheckResponse.Updates;
									}
									Interaction.MsgBox("Update not applied! Something didn't work out.", MsgBoxStyle.Information, "Oops.");
									return clsXMLUpdate.eCheckResponse.FailedWithMessage;
								}
								else
								{
									this.RestartNeeded = true;
									str5 = "Update package has been downloaded!\r\nYou need to close all other instances of Mids' Hero Designer, and then allow it to re-start for the automatic update to be applied.";
									if (!silent)
									{
										Interaction.MsgBox(str5, MsgBoxStyle.Information, "Update Downloaded");
										return clsXMLUpdate.eCheckResponse.Updates;
									}
									if (Interaction.MsgBox(str5 + "\r\nQuit now?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, "Update Downloaded") == MsgBoxResult.Yes)
									{
										clsXMLUpdate.LaunchSelfUpdate();
										ProjectData.EndApp();
									}
								}
							}
							this.HideMessage();
							return clsXMLUpdate.eCheckResponse.FailedWithMessage;
						}
					}
					eCheckResponse = clsXMLUpdate.eCheckResponse.NoUpdates;
				}
			}
			return eCheckResponse;
		}

		// Token: 0x04000044 RID: 68
		private const string TempFile = "Autoupdate.tmp";

		// Token: 0x04000045 RID: 69
		private readonly string _uriUpdatePath = "";

		// Token: 0x04000046 RID: 70
		private IMessager mFrm = null;

		// Token: 0x04000047 RID: 71
		public bool RestartNeeded = false;

		// Token: 0x04000048 RID: 72
		private frmZStatus sFrm = null;

		// Token: 0x04000049 RID: 73
		protected clsXMLUpdate.clsXMLItem[] Updates = new clsXMLUpdate.clsXMLItem[0];

		// Token: 0x02000011 RID: 17
		protected class clsXMLItem
		{
			// Token: 0x0400004A RID: 74
			public string DisplayName = "";

			// Token: 0x0400004B RID: 75
			public string LocalDest = "";

			// Token: 0x0400004C RID: 76
			public bool Manual = true;

			// Token: 0x0400004D RID: 77
			public string NodeName = "";

			// Token: 0x0400004E RID: 78
			public string Notes = "";

			// Token: 0x0400004F RID: 79
			public clsXMLUpdate.eUpdateType nType = clsXMLUpdate.eUpdateType.None;

			// Token: 0x04000050 RID: 80
			public bool Restart = false;

			// Token: 0x04000051 RID: 81
			public int Size = 0;

			// Token: 0x04000052 RID: 82
			public string SourceURI = "";

			// Token: 0x04000053 RID: 83
			public float Version = 0f;

			// Token: 0x04000054 RID: 84
			public DateTime VersionDate = new DateTime(1, 1, 1);
		}

		// Token: 0x02000012 RID: 18
		public enum eCheckResponse
		{
			// Token: 0x04000056 RID: 86
			NoUpdates,
			// Token: 0x04000057 RID: 87
			Updates,
			// Token: 0x04000058 RID: 88
			FailedWithMessage
		}

		// Token: 0x02000013 RID: 19
		protected enum eUpdateType
		{
			// Token: 0x0400005A RID: 90
			None,
			// Token: 0x0400005B RID: 91
			AppUpdate,
			// Token: 0x0400005C RID: 92
			DBUpdate
		}

		// Token: 0x02000014 RID: 20
		private struct Keys
		{
			// Token: 0x0400005D RID: 93
			public const string DisplayName = "Name";

			// Token: 0x0400005E RID: 94
			public const string SourceURI = "URI";

			// Token: 0x0400005F RID: 95
			public const string DestFn = "LocalDest";

			// Token: 0x04000060 RID: 96
			public const string Size = "Size";

			// Token: 0x04000061 RID: 97
			public const string Version = "Version";

			// Token: 0x04000062 RID: 98
			public const string VersionDate = "Date";

			// Token: 0x04000063 RID: 99
			public const string Restart = "Restart";

			// Token: 0x04000064 RID: 100
			public const string Manual = "Manual";

			// Token: 0x04000065 RID: 101
			public const string Notes = "Notes";

			// Token: 0x02000015 RID: 21
			public struct Attribs
			{
				// Token: 0x04000066 RID: 102
				public const string Version = "Version";
			}

			// Token: 0x02000016 RID: 22
			public struct Nodes
			{
				// Token: 0x04000067 RID: 103
				public const string Main = "Planner";

				// Token: 0x04000068 RID: 104
				public const string AppUpdate = "Update";

				// Token: 0x04000069 RID: 105
				public const string DBUpdate = "Database";
			}
		}
	}
}
