using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class dashboard : Form
    {
        public static int uptime = 0;
        public dashboard()
        {
            InitializeComponent();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ShowFormInPanel(Form formToShow)
        {
            // Clear any existing controls in the panel
            panel5.Controls.Clear();

            formToShow.Dock = DockStyle.Fill;

            // Set TopLevel property to false to prevent it from being treated as a top-level form
            formToShow.TopLevel = false;

            // Add the form to the Controls collection of the panel
            panel5.Controls.Add(formToShow);

            // Show the form
            formToShow.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            isActive(iconButton2, iconButton3, iconButton4, iconButton5);

            ShowFormInPanel(new dashhome());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            isActive(iconButton3, iconButton2, iconButton4, iconButton5);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            isActive(iconButton4, iconButton3, iconButton2, iconButton5);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            isActive(iconButton5, iconButton3, iconButton4, iconButton2);
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            isActive(iconButton2, iconButton3, iconButton4, iconButton5);
            ShowFormInPanel(new dashhome());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "Up Time: " + FormatTime(uptime);
            uptime += 1;
        }
        public static void isActive(IconButton args, IconButton args1, IconButton args2, IconButton args3)
        {
            args.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            args1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            args2.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            args3.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);

            args.ForeColor = Color.OrangeRed;
            args.IconColor = Color.OrangeRed;
            isNotActive(args1);
            isNotActive(args2);
            isNotActive(args3);
        }
        public static void isNotActive(IconButton args)
        {
            args.ForeColor = Color.Gainsboro;
            args.IconColor = Color.Gainsboro;
        }
        public static string FormatTime(int totalSeconds)
        {
            // Calculate hours, minutes, and seconds
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            // Format the time as "HH:MM:SS"
            string formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            return formattedTime;
        }
    }
}
