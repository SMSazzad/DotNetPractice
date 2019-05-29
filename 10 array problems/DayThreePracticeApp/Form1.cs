using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayThreePracticeApp
{
    public partial class Form1 : Form
    {
        const int size = 5;
        int [] number = new int [size];
        int index = 0, uniqueNumber;
        string message = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            if (index < size)
            {
                number[index] = Convert.ToInt32(inputTextBox.Text);
                message = message + "Element [ " + index + " ] is " + number[index] + "\n";
                showRichTextBox.Text = "\n" + message;
                inputTextBox.Clear();
                index++;
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            message = "";
            foreach(int showNumber in number)
            {
                message = message + showNumber+ " ";
            }
            showRichTextBox.Text = "\nArray elements are : " + message;

        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            message = "";
            int newSize = size-1;
            int[] reverseArray = new int[size];
            foreach(int showNumber in number)
            {
                message = message + showNumber + " ";
                reverseArray[newSize] = showNumber;
                newSize--;
            }

            //message = message + "\n";
            string newMessage = "\nArray elements are : " + message ;
            message = "";
            foreach(int reverseNumber in reverseArray)
            {
                message = message + reverseNumber + " ";
            }
            showRichTextBox.Text = newMessage +"\n"+ "Elements in reverse : " + message;
        }

        private void SumButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int sum = 0;
            foreach(int sumNumber in number)
            {
                sum += sumNumber;
            }
            showRichTextBox.Text = "\nSum of the Array is : " + sum;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int[] copyArray = new int[size];
            int index = 0;
            string showOriginal = "";
            string showCopy = "";
            foreach(int newArray in number)
            {
                copyArray[index] = newArray;
                showOriginal = showOriginal + " " + newArray;
                showCopy = showCopy + " " + copyArray[index];
                index++;
            }
            showRichTextBox.Text = "\nElements stored in first array are : \n" + showOriginal +
                "\nElements copied into second array are : \n" + showCopy;
        }

        private void ChecDuplicatekButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int count = 0;
            int newIndex,location;
            for (newIndex = 0; newIndex < size; newIndex++)
            {
                for (location = newIndex + 1; location < size; location++)
                {
                    if (number[newIndex] == number[location])
                    {
                        count++;
                    }
                    break;
                }
            }
            showRichTextBox.Text = "\nNumber of duplicate value is : " + count;
        }

        private void UniqueButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int i,j,count = 0;
            string message = "";

            for (i = 0; i < size; i++)
            {
                for (j = 1; j < size; j++)
                {
                    uniqueNumber = 0;
                    if (i == j)
                        continue;
                    else if (number[i] == number[j])
                    {
                        uniqueNumber = 1;
                        count += uniqueNumber;
                        break;
                    }
                }

                if ( uniqueNumber == 0)
                    message = message +" "+ number[i];
                    
            }

            if (count==size)
                showRichTextBox.Text = "\nThere is no unique number";
            else if (count == size-1)
                showRichTextBox.Text = "\nThe unique element is : " + message;
            else
                showRichTextBox.Text = "\nThe unique elements are : " + message;

        }

        private void MinimumButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int minimumNumber = number[0], index;

            for (index = 1; index < size; index++)
            {
                if (number[index] < minimumNumber)
                    minimumNumber = number[index];

            }
            showRichTextBox.Text = "\nThe minimum element is: " + minimumNumber;
        }

        private void OddButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int i,j,count = 0;
            int [] oddNumber = new int[size];
            string message = "";

            for(i = 0; i<size; i++)
            {
                if(number[i]%2 != 0)
                {
                    oddNumber[count] = number[i];
                    message = message + " " + oddNumber[count];
                    count++;
                }

            }
            if(count == 0)
            showRichTextBox.Text = "\nThere are no odd elements";
            else if (count == 1)
                showRichTextBox.Text = "\nThe odd element is : " +message;
            else
                showRichTextBox.Text = "\nThe odd elements are : " + message;

        }

        private void EvenButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int i, j, count = 0;
            int[] evenNumber = new int[size];
            string message = "";

            for (i = 0; i < size; i++)
            {
                if (number[i] % 2 == 0)
                {
                    evenNumber[count] = number[i];
                    message = message + " " + evenNumber[count];
                    count++;
                }

            }
            if (count == 0)
                showRichTextBox.Text = "\nThere are no even elements";
            else if (count == 1)
                showRichTextBox.Text = "\nThe even element is : " + message;
            else
                showRichTextBox.Text = "\nThe even elements are : " + message;

        }

        private void AscendingButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int i, j, temp,index = 0;
            int [] ascending = new int[size];
            string message = "";
            foreach(int sort in number)
            {
                ascending[index] = sort;
                index++;
            }

            for(i=0; i<size; i++)
            {
                for (j = i+1; j < size; j++)
                {
                    if (ascending[j] < ascending[i])
                    {
                        temp = ascending[j];
                        ascending[j] = ascending[i];
                        ascending[i] = temp;
                    }
                }
                message = message + " " + ascending[i];
            }
            showRichTextBox.Text = "\nElements are in ascending order : \n" + message;
                
        }

        private void DescendingButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int i, j, temp, index = 0;
            int[] descending = new int[size];
            string message = "";
            foreach (int sort in number)
            {
                descending[index] = sort;
                index++;
            }

            for (i = 0; i < size; i++)
            {
                for (j = i + 1; j < size; j++)
                {
                    if (descending[j] > descending[i])
                    {
                        temp = descending[j];
                        descending[j] = descending[i];
                        descending[i] = temp;
                    }
                }
                message = message + " " + descending[i];
            }
            showRichTextBox.Text = "\nElements are in descending order : \n" + message;

        }

        private void AddNumberButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int newSize = size + 1;
            int [] addNumber = new int[newSize];           
            int i, j, temp, index = 0;
            string message = "";
            string newMessage = "";
            foreach (int sort in number)
            {
                if (index == size)
                    break;
                addNumber[index] = sort;
                message = message + " " + addNumber[index];
                index++;
            }

            addNumber[newSize - 1] = Convert.ToInt32(inputTextBox.Text);

            for (i = 0; i < newSize; i++)
            {
                for (j = i + 1; j < newSize; j++)
                {
                    if (addNumber[j] < addNumber[i])
                    {
                        temp = addNumber[j];
                        addNumber[j] = addNumber[i];
                        addNumber[i] = temp;
                    }
                }
                newMessage = newMessage + " " + addNumber[i];
            }
            showRichTextBox.Text = "\nThe exist array is : \n" + message+
                "\nAfter insert the list is : " +newMessage;
            //addNumber[size - 1] = Convert.ToInt32(inputTextBox.Text);
            // showRichTextBox.Text = Convert.ToString( addNumber[size - 1]);

        }

        private void MaximumButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Clear();
            int maximumNumber = number [0],index;

            for( index = 1; index<size; index++)
            {
                if (number[index] > maximumNumber)
                    maximumNumber = number[index];

            }
            showRichTextBox.Text = "\nThe maximum element is: " + maximumNumber;
        }


    }
}
