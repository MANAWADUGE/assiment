﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Code";
            label2.Text = "Initials";
            label3.Text = "First Name";
            label4.Text = "Surename";
            label5.Text = "Address 1";
            label6.Text = "Address 2";
            label7.Text = "Date of birth";
            label8.Text = "Status";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
