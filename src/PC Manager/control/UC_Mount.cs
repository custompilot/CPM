using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomPilot.core;
using CustomPilot.Language;

namespace CustomPilot.control
{
    public partial class UC_Mount : UserControl
    {
        public UC_Mount()
        {
            InitializeComponent();
        }

        public event EventHandler OnSettingChanged;

        bool skip_event = false;

        public void Decode_EEPROM()
        {
            skip_event = true;
            if (Communication.EEPROM.mpu.mount.backward == false)
                __backword_comboBox.SelectedIndex = 0;
            else
                __backword_comboBox.SelectedIndex = 1;

            if (Communication.EEPROM.mpu.mount.reversed == false)
                __reverse_comboBox.SelectedIndex = 0;
            else
                __reverse_comboBox.SelectedIndex = 1;

            load_currentimage();

            skip_event = false;
        }
        
        private void __backword_comboBox_TextChanged(object sender, EventArgs e)
        {
            if (skip_event)
                return;

            if (__backword_comboBox.SelectedIndex == 0)
                Communication.EEPROM.mpu.mount.backward = false;
            else
                Communication.EEPROM.mpu.mount.backward = true;

            if (__reverse_comboBox.SelectedIndex == 0)
                Communication.EEPROM.mpu.mount.reversed = false;
            else
                Communication.EEPROM.mpu.mount.reversed = true;

            load_currentimage();

            if (OnSettingChanged != null)
                OnSettingChanged(sender, e);
        }
        
        private void UC_Mount_Load(object sender, EventArgs e)
        {
            load_currentimage();
        }

        private void load_currentimage()
        {
            if (__backword_comboBox.SelectedIndex == 0 && __reverse_comboBox.SelectedIndex == 0)
            {
                __picture.Image = Bitmap.FromFile(Application.StartupPath + "/images/image1.jpg");
            }else if (__backword_comboBox.SelectedIndex == 1 && __reverse_comboBox.SelectedIndex == 0)
            {
                __picture.Image = Bitmap.FromFile(Application.StartupPath + "/images/image2.jpg");
            }else if (__backword_comboBox.SelectedIndex == 0 && __reverse_comboBox.SelectedIndex == 1)
            {
                __picture.Image = Bitmap.FromFile(Application.StartupPath + "/images/image3.jpg");
            }else if (__backword_comboBox.SelectedIndex == 1 && __reverse_comboBox.SelectedIndex == 1)
            {
                __picture.Image = Bitmap.FromFile(Application.StartupPath + "/images/image4.jpg");
            }
        }

        public void set_language()
        {
            __install_groupBox.Text = CLanguages.GetTranslate("PAGE_MOUNT_NAME");
            __fb_groupBox.Text = CLanguages.GetTranslate("PAGE_MOUNT_FRONTBACK");
            __tb_groupBox.Text = CLanguages.GetTranslate("PAGE_MOUNT_TOPBOTTOM");
            __backword_comboBox.Items.Clear();
            __backword_comboBox.Items.Add(CLanguages.GetTranslate("PAGE_MOUNT_FRONT"));
            __backword_comboBox.Items.Add(CLanguages.GetTranslate("PAGE_MOUNT_BACK"));
            __reverse_comboBox.Items.Clear();
            __reverse_comboBox.Items.Add(CLanguages.GetTranslate("PAGE_MOUNT_TOP"));
            __reverse_comboBox.Items.Add(CLanguages.GetTranslate("PAGE_MOUNT_BOTTOM"));

        }

        private void __install_groupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
