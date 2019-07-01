using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryAppPractice1
{
    class Salary
    {
        public double Basic { get; set; }
        public double Medical { get; set; }
        public double Conveyance { get; set; }

        public double Increment
        {
            set
            {
                increment = value;
                increment = (Basic * increment) / 100;
                Basic = Basic + increment;
                incrementNumber++;
            }
        }

        private double total;
        private double medical;
        private double conveyance;
        public double increment;
        private int incrementNumber = 0;
        public double GetTotal()
        {
            total = Basic + medical + conveyance;
            return total;
            
        }

        public double GetBasic()
        {
            return Basic;
        }

        public double GetMedical()
        {
            medical = (Basic * Medical) / 100;
            return medical;
        }
        public double GetConveyance()
        {
            conveyance = (Basic * Medical) / 100;
            return conveyance;
        }
        public int GetIncrement()
        {
           

            return incrementNumber;
        }


    }
}
