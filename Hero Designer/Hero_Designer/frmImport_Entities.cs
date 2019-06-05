using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x0200003C RID: 60
	
	public partial class frmImport_Entities : Form
	{
		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000B4B RID: 2891 RVA: 0x000727F8 File Offset: 0x000709F8
		// (set) Token: 0x06000B4C RID: 2892 RVA: 0x00072810 File Offset: 0x00070A10
		internal virtual Button btnClose
		{
			get
			{
				return this._btnClose;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnClose_Click);
				if (this._btnClose != null)
				{
					this._btnClose.Click -= eventHandler;
				}
				this._btnClose = value;
				if (this._btnClose != null)
				{
					this._btnClose.Click += eventHandler;
				}
			}
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x0007286C File Offset: 0x00070A6C
		// (set) Token: 0x06000B4E RID: 2894 RVA: 0x00072884 File Offset: 0x00070A84
		internal virtual Button btnFile
		{
			get
			{
				return this._btnFile;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnFile_Click);
				if (this._btnFile != null)
				{
					this._btnFile.Click -= eventHandler;
				}
				this._btnFile = value;
				if (this._btnFile != null)
				{
					this._btnFile.Click += eventHandler;
				}
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x000728E0 File Offset: 0x00070AE0
		// (set) Token: 0x06000B50 RID: 2896 RVA: 0x000728F8 File Offset: 0x00070AF8
		internal virtual Button btnImport
		{
			get
			{
				return this._btnImport;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnImport_Click);
				if (this._btnImport != null)
				{
					this._btnImport.Click -= eventHandler;
				}
				this._btnImport = value;
				if (this._btnImport != null)
				{
					this._btnImport.Click += eventHandler;
				}
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x00072954 File Offset: 0x00070B54
		// (set) Token: 0x06000B52 RID: 2898 RVA: 0x0007296C File Offset: 0x00070B6C
		internal virtual OpenFileDialog dlgBrowse
		{
			get
			{
				return this._dlgBrowse;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._dlgBrowse = value;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x00072978 File Offset: 0x00070B78
		// (set) Token: 0x06000B54 RID: 2900 RVA: 0x00072990 File Offset: 0x00070B90
		internal virtual Label Label8
		{
			get
			{
				return this._Label8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label8 = value;
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000B55 RID: 2901 RVA: 0x0007299C File Offset: 0x00070B9C
		// (set) Token: 0x06000B56 RID: 2902 RVA: 0x000729B4 File Offset: 0x00070BB4
		internal virtual Label lblDate
		{
			get
			{
				return this._lblDate;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDate = value;
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x000729C0 File Offset: 0x00070BC0
		// (set) Token: 0x06000B58 RID: 2904 RVA: 0x000729D8 File Offset: 0x00070BD8
		internal virtual Label lblFile
		{
			get
			{
				return this._lblFile;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblFile = value;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000B59 RID: 2905 RVA: 0x000729E4 File Offset: 0x00070BE4
		// (set) Token: 0x06000B5A RID: 2906 RVA: 0x000729FC File Offset: 0x00070BFC
		internal virtual NumericUpDown udRevision
		{
			get
			{
				return this._udRevision;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._udRevision = value;
			}
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x00072A06 File Offset: 0x00070C06
		public frmImport_Entities()
		{
			base.Load += this.frmImport_Entities_Load;
			this.FullFileName = "";
			this.InitializeComponent();
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x00072A36 File Offset: 0x00070C36
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x00072A40 File Offset: 0x00070C40
		private void btnFile_Click(object sender, EventArgs e)
		{
			this.dlgBrowse.FileName = this.FullFileName;
			if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
			{
				this.FullFileName = this.dlgBrowse.FileName;
			}
			this.BusyHide();
			this.DisplayInfo();
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x00072A97 File Offset: 0x00070C97
		private void btnImport_Click(object sender, EventArgs e)
		{
			this.ParseClasses(this.FullFileName);
			this.BusyHide();
			this.DisplayInfo();
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x00072AB8 File Offset: 0x00070CB8
		private void BusyHide()
		{
			if (this.bFrm != null)
			{
				this.bFrm.Close();
				this.bFrm = null;
			}
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x00072AE8 File Offset: 0x00070CE8
		private void BusyMsg(string sMessage)
		{
			if (this.bFrm == null)
			{
				this.bFrm = new frmBusy();
				this.bFrm.Show(this);
			}
			this.bFrm.SetMessage(sMessage);
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x00072B30 File Offset: 0x00070D30
		public void DisplayInfo()
		{
			this.lblFile.Text = FileIO.StripPath(this.FullFileName);
			this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.IOAssignmentVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.udRevision.Value = new decimal(DatabaseAPI.Database.IOAssignmentVersion.Revision);
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x00072BFC File Offset: 0x00070DFC
		private void frmImport_Entities_Load(object sender, EventArgs e)
		{
			this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
			this.DisplayInfo();
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x00073100 File Offset: 0x00071300
		private bool ParseClasses(string iFileName)
		{
			int num = 0;
			StreamReader iStream;
			try
			{
				iStream = new StreamReader(iFileName);
			}
			catch (Exception ex)
			{
				Exception ex3 = ex;
				Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "IO CSV Not Opened");
				return false;
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			try
			{
				string iLine;
				do
				{
					iLine = FileIO.ReadLineUnlimited(iStream, '\0');
					if (iLine != null)
					{
						if (!iLine.StartsWith("#"))
						{
							num4++;
							if (num4 >= 9)
							{
								this.BusyMsg(Strings.Format(num2, "###,##0") + " records parsed.");
								num4 = 0;
							}
							string[] array = CSV.ToArray(iLine);
							string uidEntity = "";
							if (array.Length > 1)
							{
								int index = -2;
								if (array[0].StartsWith("Pets."))
								{
									uidEntity = "Pets_" + array[1];
									index = DatabaseAPI.NidFromUidEntity(uidEntity);
								}
								else if (array[0].StartsWith("Villain_Pets."))
								{
									uidEntity = "Pets_" + array[1];
									index = DatabaseAPI.NidFromUidEntity(uidEntity);
								}
								if (index > -2)
								{
									if (index < 0)
									{
										IDatabase database = DatabaseAPI.Database;
										SummonedEntity[] summonedEntityArray = (SummonedEntity[])Utils.CopyArray(database.Entities, new SummonedEntity[DatabaseAPI.Database.Entities.Length + 1]);
										database.Entities = summonedEntityArray;
										DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1] = new SummonedEntity();
										SummonedEntity entity = DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1];
										entity.UID = uidEntity;
										entity.nID = DatabaseAPI.Database.Entities.Length - 1;
										index = entity.nID;
									}
									SummonedEntity entity2 = DatabaseAPI.Database.Entities[index];
									entity2.DisplayName = array[2];
									entity2.ClassName = "Class_Minion_Pets";
									entity2.nClassID = DatabaseAPI.NidFromUidClass(entity2.ClassName);
									entity2.EntityType = Enums.eSummonEntity.Pet;
									entity2.PowersetFullName = new string[1];
									entity2.nPowerset = new int[1];
									entity2.PowersetFullName[0] = array[0];
									entity2.nPowerset[0] = DatabaseAPI.NidFromUidPowerset(entity2.PowersetFullName[0]);
									entity2.UpgradePowerFullName = new string[0];
									entity2.nUpgradePower = new int[0];
									num++;
								}
								else
								{
									num3++;
								}
							}
						}
						num2++;
					}
				}
				while (iLine != null);
			}
			catch (Exception ex2)
			{
				Exception exception = ex2;
				iStream.Close();
				Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Entity CSV Parse Error");
				return false;
			}
			iStream.Close();
			DatabaseAPI.SaveMainDatabase();
			this.DisplayInfo();
			Interaction.MsgBox(string.Concat(new string[]
			{
				"Parse Completed!\r\nTotal Records: ",
				Conversions.ToString(num2),
				"\r\nGood: ",
				Conversions.ToString(num),
				"\r\nRejected: ",
				Conversions.ToString(num3)
			}), MsgBoxStyle.Information, "File Parsed");
			return true;
		}

		// Token: 0x040004A8 RID: 1192
		[AccessedThroughProperty("btnClose")]
		private Button _btnClose;

		// Token: 0x040004A9 RID: 1193
		[AccessedThroughProperty("btnFile")]
		private Button _btnFile;

		// Token: 0x040004AA RID: 1194
		[AccessedThroughProperty("btnImport")]
		private Button _btnImport;

		// Token: 0x040004AB RID: 1195
		[AccessedThroughProperty("dlgBrowse")]
		private OpenFileDialog _dlgBrowse;

		// Token: 0x040004AC RID: 1196
		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		// Token: 0x040004AD RID: 1197
		[AccessedThroughProperty("lblDate")]
		private Label _lblDate;

		// Token: 0x040004AE RID: 1198
		[AccessedThroughProperty("lblFile")]
		private Label _lblFile;

		// Token: 0x040004AF RID: 1199
		[AccessedThroughProperty("udRevision")]
		private NumericUpDown _udRevision;

		// Token: 0x040004B0 RID: 1200
		private frmBusy bFrm;

		// Token: 0x040004B2 RID: 1202
		private string FullFileName;
	}
}
