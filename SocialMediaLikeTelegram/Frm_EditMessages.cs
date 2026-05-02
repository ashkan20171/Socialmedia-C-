using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram
{
    public partial class Frm_EditMessages : Form
    {
        public static bool IsEdited = false;
        public static string MessageText = "";
        public Frm_EditMessages()
        {
            InitializeComponent();
        }

        private void Frm_EditMessages_Load(object sender, EventArgs e)
        {
            txt_Message.Text = MessageText;
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            IsEdited = false;
            this.Close();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            MessageText = txt_Message.Text;
            IsEdited = true;
            this.Close();
        }
    }
}
