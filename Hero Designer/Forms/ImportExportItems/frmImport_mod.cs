
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Hero_Designer.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    public partial class frmImport_mod : Form
    {

        public frmImport_mod()
        {
            Load += frmImport_mod_Load;
            InitializeComponent();
            Name = nameof(frmImport_mod);
            var componentResourceManager = new ComponentResourceManager(typeof(frmImport_mod));
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
        }

        void btnAttribIndex_Click(object sender, EventArgs e)
        {
            dlgBrowse.FileName = lblAttribIndex.Text;
            if (dlgBrowse.ShowDialog(this) != DialogResult.OK)
                return;
            lblAttribIndex.Text = dlgBrowse.FileName;
        }

        void btnAttribLoad_Click(object sender, EventArgs e)
        {
            if (lblAttribIndex.Text != "" & lblAttribTables.Text != "")
            {
                if (File.Exists(lblAttribIndex.Text) & File.Exists(lblAttribTables.Text))
                {
                    if (DatabaseAPI.Database.AttribMods.ImportModifierTablefromCSV(lblAttribIndex.Text, lblAttribTables.Text, Convert.ToInt32(udAttribRevision.Value)))
                    {
                        DatabaseAPI.Database.AttribMods.Store(MyApplication.GetSerializer());
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
            DisplayInfo();
        }

        void btnAttribTable_Click(object sender, EventArgs e)
        {
            dlgBrowse.FileName = lblAttribTables.Text;
            if (dlgBrowse.ShowDialog(this) != DialogResult.OK)
                return;
            lblAttribTables.Text = dlgBrowse.FileName;
        }

        void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        void DisplayInfo()
        {
            lblAttribIndex.Text = DatabaseAPI.Database.AttribMods.SourceIndex;
            lblAttribTables.Text = DatabaseAPI.Database.AttribMods.SourceTables;
            lblAttribDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.AttribMods.RevisionDate, "dd/MMM/yy HH:mm:ss");
            udAttribRevision.Value = new Decimal(DatabaseAPI.Database.AttribMods.Revision);
            lblAttribTableCount.Text = "Tables: " + Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length);
        }

        void frmImport_mod_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }
    }
}