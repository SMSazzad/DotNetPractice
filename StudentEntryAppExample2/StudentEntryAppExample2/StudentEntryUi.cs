using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentEntryAppExample2
{
    public partial class StudentEntryUi : Form
    {
        public StudentEntryUi()
        {
            InitializeComponent();
        }

        Department department;
        private void DepartmentSaveButton_Click(object sender, EventArgs e)
        {
            department = new Department();
            department.Code = codeTextBox.Text;
            department.Name = departmentNameTextBox.Text;
            MessageBox.Show("Saved successfully!");
        }

        private void StudentSaveButton_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.RegNo = regNoTextBox.Text;
            student.Name = studentNameTextBox.Text;
            student.Email = emailTextBox.Text;

            bool isAdded = department.AddStudents(student);
            if (isAdded)
            {
                studentNameTextBox.Text = "";
                regNoTextBox.Text = "";
                emailTextBox.Text = "";
            }
            else
                MessageBox.Show("student capacity full");
        }

        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            string message = department.GetStudentDetails();
            MessageBox.Show(message);
        }
    }
}
