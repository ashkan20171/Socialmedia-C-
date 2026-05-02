using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    public partial class SessionListItem : UserControl
    {
        public SessionListItem()
        {
            InitializeComponent();
        }
        public string Session_Code { get; set; }
        public string OS { get { return lbl_OS.Text; } set { lbl_OS.Text = value; } }
        public string IP
        {
            get { return lbl_ip.Text.Split(',')[0]; }
            set { lbl_ip.Text = value + "," + lbl_ip.Text.Split(',')[1]; }
        }
        public string Time { get { return lbl_Time.Text; } set { lbl_Time.Text = value; } }
        public string Date { get { return lbl_ip.Text.Split(',')[1]; } set { lbl_ip.Text = lbl_ip.Text.Split(',')[0] + "," + value; } }
        public event EventHandler DeleteSessionClicked;
        public bool DeleteVisible { get { return pictureBox1.Visible; } set { pictureBox1.Visible = value; } }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (DeleteSessionClicked != null)
                DeleteSessionClicked(this, e);
        }
    }
}
