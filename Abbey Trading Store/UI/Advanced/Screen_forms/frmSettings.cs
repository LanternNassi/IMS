using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.DAL.DAL_Properties;
using LoadingIndicator.WinForms;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        public bool edit = false;

        private readonly DbContext _dbContext = new Base2();

        public void changeInputTypes(bool editStatus)
        {
            client_id_txtbx.ReadOnly= editStatus;
            description_txtbx.ReadOnly = editStatus;
            name_txtbx.ReadOnly = editStatus;
            sms_api_txtbx.ReadOnly = editStatus;
            sms_name_txtbx.ReadOnly = editStatus;
            number_txtbx.ReadOnly = editStatus;
        }

        public void updateSettings()
        {
            try
            {

                var businessAccount = _dbContext.Set<BusinessAccount>().FirstOrDefault(a => a.id == 1);

                if (businessAccount != null)
                {
                    businessAccount.Name = name_txtbx.Text.Trim();
                    businessAccount.Description = description_txtbx.Text.Trim();

                    string[] phoneNumbers = number_txtbx.Text.Split(',');
                    businessAccount.Tel_1 = phoneNumbers[0].Trim();
                    businessAccount.Tel_2 = phoneNumbers[1].Trim();
                    businessAccount.Tel_3 = phoneNumbers[2].Trim();


                }

                var setting = _dbContext.Set<Abbey_Trading_Store.Settings>().FirstOrDefault(a => a.id == 1);

                if (setting != null)
                {
                    setting.MessageAPIKey = sms_api_txtbx.Text;
                    setting.MessageUsername = sms_name_txtbx.Text;

                }

                _dbContext.SaveChanges();

                MessageBox.Show("Configuration saved successfully. Restart the application for changes to take effect");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

            changeInputTypes(edit);


            materialButton1.Text = edit ? "Edit Information" : "Save Information";

            if (edit)
            {
                updateSettings();
            }

            edit = !edit;

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private async void frmSettings_Load(object sender, EventArgs e)
        {
            client_id_txtbx.Text = Env.ClientId;
            name_txtbx.Text = Env.BusinessName;
            number_txtbx.Text = Env.Tel_1 + " , " + Env.Tel_2 + " , " + Env.Tel_3;
            description_txtbx.Text = Env.BusinessDescription;
            sms_api_txtbx.Text = Env.MessageAPIKey;
            sms_name_txtbx.Text = Env.MessageFrom;


            //Load backps data from server

            var backups = await SettingsConfig.GetBackupsByClientId(Env.ClientId);

            if (backups == null)
            {
                BoxIndicatorControl loadingControl = new BoxIndicatorControl();
                loadingControl.Location = new Point(panel9.Width/2 - 20 , panel9.Height/2);
                panel9.Controls.Clear();
                panel9.Controls.Add(loadingControl);
                loadingControl.Show();

            }
            else
            {
                BackupsDGV.DataSource = backups;
                BackupsDGV.Columns[3].Visible = false;
                BackupsDGV.Columns[5].Visible = false;



            }



        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This action will start a background task that backs up the system data . Make sure you have an active internet connection , Do you wish to proceed ?", "System Backup Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                SettingsConfig.CreateBackUp(Env.ClientId);
                Cursor = Cursors.Default;
            }
            else
            {
               
            }

            
        }
    }
}
