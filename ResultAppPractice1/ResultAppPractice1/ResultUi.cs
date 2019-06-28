﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultAppPractice1
{
    public partial class ResultUi : Form
    {
        public ResultUi()
        {
            InitializeComponent();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            double physics = Convert.ToDouble(physicsTextBox.Text);
            double chemestry = Convert.ToDouble(chemistryTextBox.Text);
            double math = Convert.ToDouble(mathTextBox.Text);

            Result result = new Result(physics, chemestry, math);
            averageTextBox.Text = Convert.ToString( result.GetAverage());
            gradeLetterTextBox.Text = result.GetGrade();
        }
    }
}
