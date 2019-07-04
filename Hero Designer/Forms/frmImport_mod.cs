
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmImport_mod : Form
    {

        public frmImport_mod()
        {
            this.Load += new EventHandler(this.frmImport_mod_Load);
            this.InitializeComponent();
            this.Name = nameof(frmImport_mod);
            var componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmImport_mod));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
        }

        void btnAttribIndex_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribIndex.Text;
            if (this.dlgBrowse.ShowDialog(this) != DialogResult.OK)
                return;
            this.lblAttribIndex.Text = this.dlgBrowse.FileName;
        }

        void btnAttribLoad_Click(object sender, EventArgs e)
        {
            if (this.lblAttribIndex.Text != "" & this.lblAttribTables.Text != "")
            {
                if (File.Exists(this.lblAttribIndex.Text) & File.Exists(this.lblAttribTables.Text))
                {
                    if (DatabaseAPI.Database.AttribMods.ImportModifierTablefromCSV(this.lblAttribIndex.Text, this.lblAttribTables.Text, Convert.ToInt32(this.udAttribRevision.Value)))
                    {
                        DatabaseAPI.Database.AttribMods.Store(My.MyApplication.GetSerializer());
                        Interaction.MsgBox((Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length) + " modifier tables imported and saved."), MsgBoxStyle.Information, "Done.");
                    }
                    else
                    {
                        Interaction.MsgBox("Import failed. attempting reload of binary data file.", MsgBoxStyle.Information, "Error.");
                        if (DatabaseAPI.Database.AttribMods.Load())
                        {
                            Interaction.MsgBox("Binary reload successful.", MsgBoxStyle.Information, "Done.");
                        }
                    }
                }
                else
                {
                    Interaction.MsgBox("Files cannot be found!", MsgBoxStyle.Exclamation, "No Can Do");
                }
            }
            else
            {
                Interaction.MsgBox("Files not selected!", MsgBoxStyle.Exclamation, "No Can Do");
            }
            this.DisplayInfo();
        }

        void btnAttribTable_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribTables.Text;
            if (this.dlgBrowse.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            this.lblAttribTables.Text = this.dlgBrowse.FileName;
        }

        void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void DisplayInfo()
        {
            this.lblAttribIndex.Text = DatabaseAPI.Database.AttribMods.SourceIndex;
            this.lblAttribTables.Text = DatabaseAPI.Database.AttribMods.SourceTables;
            this.lblAttribDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.AttribMods.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udAttribRevision.Value = new Decimal(DatabaseAPI.Database.AttribMods.Revision);
            this.lblAttribTableCount.Text = "Tables: " + Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length);
        }

        void frmImport_mod_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }
    }
}