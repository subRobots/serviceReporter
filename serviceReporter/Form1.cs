using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Net.Mail;

namespace serviceReporter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool exists(string servName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(servName));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (exists(txtTargetService.Text))
            {
                txtService.Text = "Service exists";
            }
            else
            {
                txtService.Text = "Service doesn't exists" ;
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt16(txtMinutes.Text) * 1000;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtStopCount.Text = "0";
        }

        private void cbSMTP_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if cbSMTP.
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void txtTargetService_TextChanged(object sender, EventArgs e)
        {
            if (exists(txtTargetService.Text))
            {
                txtService.Text = "Service exists";
            }
            else
            {
                txtService.Text = "Service doesn't exists";
            }

             txtSubject.Text = txtTargetService.Text + " Service has stopped [Timestamp]";
            txtBody.Text= txtTargetService.Text + " Service has stopped [Timestamp]";
        }
    }
}
