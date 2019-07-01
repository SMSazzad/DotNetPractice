using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeSalaryAppPractice1
{
    public partial class EmployeeSalaryUi : Form
    {
        Employee anEmployee = new Employee();
        Salary salary = new Salary();
        public EmployeeSalaryUi()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            anEmployee.EmployeeID = IdTextBox.Text;
            anEmployee.EmployeeName = nameTextBox.Text;
            anEmployee.Email = emailTextBox.Text;

           

            anEmployee.Salary = salary;

            anEmployee.Salary.Basic = Convert.ToDouble(basicTextBox.Text);
            anEmployee.Salary.Medical = Convert.ToDouble(medicalTextBox.Text);
            anEmployee.Salary.Conveyance = Convert.ToDouble(conveyanceTextBox.Text);
            //anEmployee.Salary.Increment = Convert.ToDouble(increaseTextBox.Text);
        }

        private void IncrementButton_Click(object sender, EventArgs e)
        {
            anEmployee.Salary = salary;
            anEmployee.Salary.Increment = Convert.ToDouble(increaseTextBox.Text);
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            noOfIncrementsTextBox.Text = anEmployee.Salary.GetIncrement().ToString();
            showBasicTextBox.Text = anEmployee.Salary.GetBasic().ToString();
            showMedicalTextBox.Text = anEmployee.Salary.GetMedical().ToString();
            showConveyanceTextBox.Text = anEmployee.Salary.GetConveyance().ToString();
            showTotalTextBox.Text = anEmployee.Salary.GetTotal().ToString();
        }
    }
}
