using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechicleAppPractice2
{
    class Vehicle
    {
        List<int> vehicleSpeed = new List<int>();
        public Vehicle() { }

        public Vehicle(string name, string regNo)
        {
            this.Name = name;
            this.RegNo = regNo;
        }
        public string Name { get; set; }
        public string RegNo { get; set; }

        public void AddSpeed(int speed)
        {
            vehicleSpeed.Add(speed);
        }

        public int ShowMinSpeed()
        {
            int min = vehicleSpeed[0];
            for(int index = 1; index <vehicleSpeed.Count; index++ )
            {
                if (vehicleSpeed[index] < min)
                    min = vehicleSpeed[index];
            }
            return min;
        }

        public int ShowMaxSpeed()
        {
            int max = 0;
            foreach(int speed in vehicleSpeed)
            {
                if (max < speed)
                    max = speed;
            }
            return max;
        }

        public int ShowAvgSpeed()
        {
            int avg = 0;
            foreach (int speed in vehicleSpeed)
                avg = avg + speed;

            return avg / vehicleSpeed.Count;
        }

    }
}
