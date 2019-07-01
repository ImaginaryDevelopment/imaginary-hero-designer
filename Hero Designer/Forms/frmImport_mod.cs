
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmImport_mod : Form
    {
        Button btnAttribIndex;

        Button btnAttribLoad;

        Button btnAttribTable;

        Button Button1;
        OpenFileDialog dlgBrowse;
        Label Label1;
        Label Label3;
        Label Label4;
        Label lblAttribDate;
        Label lblAttribIndex;
        Label lblAttribTableCount;
        Label lblAttribTables;
        NumericUpDown udAttribRevision;

        public frmImport_mod()
        {
            this.Load += new EventHandler(this.frmImport_mod_Load);
            this.InitializeComponent();
        }

        void btnAttribIndex_Click(object sender, EventArgs e)

        {
            this.dlgBrowse.FileName = this.lblAttribIndex.Text;
            if (this.dlgBrowse.ShowDialog((IWin32Window)this) != DialogResult.OK)
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
                        DatabaseAPI.Database.AttribMods.Store();
                        int num = (int)Interaction.MsgBox((object)(Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length) + " modifier tables imported and saved."), MsgBoxStyle.Information, (object)"Done.");
                    }
                    else
                    {
                        int num1 = (int)Interaction.MsgBox((object)"Import failed. attempting reload of binary data file.", MsgBoxStyle.Information, (object)"Error.");
                        if (DatabaseAPI.Database.AttribMods.Load())
                        {
                            int num2 = (int)Interaction.MsgBox((object)"Binary reload successful.", MsgBoxStyle.Information, (object)"Done.");
                        }
                    }
                }
                else
                {
                    int num3 = (int)Interaction.MsgBox((object)"Files cannot be found!", MsgBoxStyle.Exclamation, (object)"No Can Do");
                }
            }
            else
            {
                int num4 = (int)Interaction.MsgBox((object)"Files not selected!", MsgBoxStyle.Exclamation, (object)"No Can Do");
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
            this.lblAttribDate.Text = "Date: " + Strings.Format((object)DatabaseAPI.Database.AttribMods.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udAttribRevision.Value = new Decimal(DatabaseAPI.Database.AttribMods.Revision);
            this.lblAttribTableCount.Text = "Tables: " + Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length);
        }

        void frmImport_mod_Load(object sender, EventArgs e)

        {
            this.DisplayInfo();
        }
    }
}