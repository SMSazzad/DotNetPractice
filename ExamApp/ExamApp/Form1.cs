using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamApp
{
    public partial class Form1 : Form
    {

        List<string> soldierNumbers = new List<string>();
        List<string> soldierNames = new List<string>();
        List<int> targetOnes = new List<int>();
        List<int> targetTwos = new List<int>();
        List<int> targetThrees = new List<int>();
        List<int> targetFourths = new List<int>();

        List<int> totalScores = new List<int>();
        List<double> totalAverages = new List<double>();

        public Form1()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string soldierNumber;
            string soldierName;
            int targetOne;
            int targetTwo;
            int targetThree;
            int targetFour;

            try
            {
                soldierNumber = soldierNoTextBox.Text;
                if (SoldierExists(soldierNumber))
                {
                    MessageBox.Show("Soldier already exists!");
                    return;
                }
                soldierNumbers.Add(soldierNumber);
               
                soldierName = soldierNameTextBox.Text;

                targetOne = Convert.ToInt32(targetOneTextBox.Text);
                targetTwo = Convert.ToInt32(targetTwoTextBox.Text);
                targetThree = Convert.ToInt32(targetThreeTextBox.Text);
                targetFour = Convert.ToInt32(targetFourTextBox.Text);

               
                soldierNames.Add(soldierName);
                targetOnes.Add(targetOne);
                targetTwos.Add(targetTwo);
                targetThrees.Add(targetThree);
                targetFourths.Add(targetFour);

                int score = targetOne + targetTwo + targetThree + targetFour;
                totalScores.Add(score);

                totalAverages.Add(Convert.ToDouble(score) / 4);
            }

            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private bool SoldierExists(string soldierNo)
        {
            bool exist = false;
           
            for(int index = 0; index < soldierNumbers.Count; index++ )
           
            {
               if (soldierNo == soldierNumbers[index])
                    exist = true;
            }
            return exist;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            string message = "\nSoldier No\tSoldier Name\tAgerage Score\tTotal Score";
            int totalScore;
            double averageScore;

            for(int index = 0; index<soldierNumbers.Count; index++)
            {
                message = message + "\n" + soldierNumbers[index] + "\t\t" + soldierNames[index] + "\t\t"
                    +totalAverages[index]+ "\t\t"+totalScores[index];
              
            }


            showRichTextBox.Text = message;
            Top();
        }

        void Top()
        {
            int topTotal = 0;
            double topAverage = 0;
            int avIndex = 0, tsIndex = 0, count = 0;
            
            foreach(double average in totalAverages)
            {
                if(average > topAverage)
                {
                    topAverage = average;
                    avIndex = count;
                }
                if(totalScores[count] > topTotal)
                {
                    topTotal = totalScores[count];
                    tsIndex = count;
                }
                count++;

            }

            topAverageTextBox.Text = soldierNames[avIndex];
            topTotalTextBox.Text = soldierNames[tsIndex];
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Validate();
        }

        void Validate()
        {
           
            string chk = searchComboBox.Text;
            if (String.IsNullOrEmpty(chk))
            {
                MessageBox.Show("Please select search criteria");
                return;
            }

            string searchSoldier = searchSoldierTextBox.Text;
            if (String.IsNullOrEmpty(searchSoldier))
            {
                if (chk == "Soldier No")
                {
                    MessageBox.Show("Please enter soldier number");
                    return;
                }
                else
                {
                    MessageBox.Show("Please enter soldier name");
                    return;
                }
                    
                
            }

            string message = "\nSoldier No\tSoldier Name\tAgerage Score\tTotal Score";


            if (chk == "Soldier No")
            {
                int count = 0, index = 0;
                foreach (string soldier in soldierNumbers)
                {
                    if (searchSoldier == soldier)
                    {
                        message = message + "\n" + soldierNumbers[index] + "\t\t" + soldierNames[index] + "\t\t"
                    + totalAverages[index] + "\t\t" + totalScores[index];
                        count = 1;
                    }
                    index++;
                }

                if (count == 1)
                {
                    showRichTextBox.Text = message;
                    topTotalTextBox.Text = "";
                    topAverageTextBox.Text = "";
                }
                else
                    MessageBox.Show("There is no soldier with this number");
            }

            if (chk == "Soldier Name")
            {
                int count = 0, index = 0;
                foreach (string soldier in soldierNames)
                {
                    if (searchSoldier == soldier)
                    {
                        message = message + "\n" + soldierNumbers[index] + "\t\t" + soldierNames[index] + "\t\t"
                    + totalAverages[index] + "\t\t" + totalScores[index];
                        count = 1;
                    }
                    index++;
                }
                if (count == 1)
                {
                    showRichTextBox.Text = message;
                    topTotalTextBox.Text = "";
                    topAverageTextBox.Text = "";
                }
                    
                else
                    MessageBox.Show("There is no soldier with this name");
            }
        }


    }
}
