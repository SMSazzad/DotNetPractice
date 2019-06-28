using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VechicleAppPractice2
{
    public partial class VehicleUi : Form
    {
        public VehicleUi()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string vehicleName = vehicleNameTextBox.Text;
            string regNo = regNoTextBox.Text;

            Vehicle vehicle = new Vehicle(vehicleName, regNo);
            MessageBox.Show("Saved");
        }

        Vehicle vehicle = new Vehicle();

        private void EnterButton_Click(object sender, EventArgs e)
        {
            int speed = Convert.ToInt32(speedTextBox.Text);
            vehicle.AddSpeed(speed);
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            minSpeedTextBox.Text = Convert.ToString(vehicle.ShowMinSpeed());
            maxSpeedTextBox.Text = Convert.ToString(vehicle.ShowMaxSpeed());
            averageSpeedTextBox.Text = Convert.ToString(vehicle.ShowAvgSpeed());
        }
    }
}
