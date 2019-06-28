using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultAppPractice1
{
    class Result
    {
        private double physics;
        private double chemestry;
        private double math;
        private double average;

        public Result(double physics, double chemestry, double math)
        {
            this.physics = physics;
            this.chemestry = chemestry;
            this.math = math;
        }

        public double GetAverage()
        {
            average = (physics + chemestry + math) / 3;
            return average;
        }

        public string GetGrade()
        {
            if (average >= 80)
                return "A+";
            else if (average >= 70)
                return "B+";
            else if (average >= 60)
                return "C+";
            else if (average >= 50)
                return "D+";
            else
                return "F";

        }


    }
}
