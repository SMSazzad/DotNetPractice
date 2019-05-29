using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayFiveBankAccountApp
{
    public partial class Form1 : Form
    {
        List<string> users = new List<string>();
        List<string> firstNames = new List<string>();
        List<string> LastNames = new List<string>();
        List<string> contactNumbers = new List<string>();
        List<string> emails = new List<string>();
        List<string> addresses = new List<string>();
        List<string> accountNumbers = new List<string>();
        bool valid;
        double amount;
        double balance = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string user;
            string firstName;
            string lastName;
            string contactNo;
            string email;
            string address;
            string accountNo;
            

            userNameLabel.Text = "";
            firstNameLabel.Text = "";
            lastNameLabel.Text = "";
            contactNoLabel.Text = "";
            emailLabel.Text = "";
            addressLabel.Text = "";
            accountNoLabel.Text = "";

            try
            {
                if(String.IsNullOrEmpty(userNameTextBox.Text))
                {
                    userNameLabel.Text = "Must provided field";
                    return;
                }
               
                user = userNameTextBox.Text;
                if (UserExists(user))
                {
                    userNameLabel.Text = "User exists with this name";
                    return;
                }

                if (String.IsNullOrEmpty(firstNameTextBox.Text))
                {
                    firstNameLabel.Text = "First name can not be empty";
                    return;
                }
                firstName = firstNameTextBox.Text;
                lastName = lastNameTextBox.Text;

                if (String.IsNullOrEmpty(contactNoTextBox.Text))
                {
                    contactNoLabel.Text = "Must provided field";
                    return;
                }

               
              
                long Num;
                bool isNum = long.TryParse(contactNoTextBox.Text, out Num);
                if (!isNum)
                {
                    contactNoLabel.Text = "Contact no should be numeric digit";
                    return;
                }
                if(contactNoTextBox.Text.Length != 11)
                {
                    contactNoLabel.Text = "Contact no should be 11 numeric digits";
                    return;
                }
                contactNo = contactNoTextBox.Text;
                if(ContactNoExists(contactNo))
                {
                    contactNoLabel.Text = "Same contact no exixts";
                    return;
                }

                if(String.IsNullOrEmpty(emailTextBox.Text))
                {
                    emailLabel.Text = "Must provided field";
                    return;
                }

                email = emailTextBox.Text;
                IsEmailValid(email);
                if(!valid)
                {
                    emailLabel.Text = "Email is not valid";
                    return;
                }
                if(EmailExists(email))
                {
                    emailLabel.Text = "This email already exists";
                    return;
                }

                if(String.IsNullOrEmpty(addressTextBox.Text))
                {
                    addressLabel.Text = "Must provided field";
                    return;
                }
                address = addressTextBox.Text;

                if (String.IsNullOrEmpty(accountTextBox.Text))
                {
                    accountNoLabel.Text = "Must provided field";
                    return;
                }


                isNum = long.TryParse(accountTextBox.Text, out Num);
                if (!isNum)
                {
                    accountNoLabel.Text = "Account no should be numeric digit";
                    return;
                }
                if (accountTextBox.Text.Length != 9)
                {
                    accountNoLabel.Text = "Account no should be 9 numeric digits";
                    return;
                }
                accountNo = accountTextBox.Text;

                if(AccountExists(accountNo))
                {
                    accountNoLabel.Text = "This account no exists";
                    return;
                }


                users.Add(user);
                firstNames.Add(firstName);
                LastNames.Add(lastName);
                contactNumbers.Add(contactNo);
                emails.Add(email);
                addresses.Add(address);
                accountNumbers.Add(accountNo);

         
            }


            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void IsEmailValid(string email)
        {
            valid = false;
            try
            {
                MailAddress eMailAddress = new MailAddress(email);
                valid = true;
            }
            catch (FormatException)
            {
                
            }
           
        }

        private string Display()
        {
            string message = "\nSl\tAccount No\tUser Name\tFirst Name" +
                "\tLast Name\tContact No\tEmail\t\t\tAddress";
            int count = 0;

            for(int index = 0; index<users.Count; index++)
            {
                message = message + "\n" + (++count) + "\t" + accountNumbers[index]
                    + "\t" + users[index] + "\t\t" + firstNames[index] + "\t\t" +
                    LastNames[index] + "\t\t" + contactNumbers[index] + "\t" +
                    emails[index] + "\t" + addresses[index];

            }
            return message;

        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Text = Display(); 
        }

        bool UserExists(string uName)
        {
            bool valid = false;
            foreach(string chkUser in users)
            {
                if (chkUser == uName)
                    valid = true;
            }

            return valid;
        }

        bool ContactNoExists(string contactNo)
        {
            bool valid = false;
            foreach (string chkContacts in contactNumbers)
            {
                if (chkContacts == contactNo)
                    valid = true;
            }

            return valid;
        }

        bool EmailExists(string mail)
        {
            bool valid = false;
            foreach (string chkMail in emails)
            {
                if (chkMail == mail)
                    valid = true;
            }

            return valid;
        }

        bool AccountExists(string accNo)
        {
            bool valid = false;
            foreach (string chkAcc in accountNumbers)
            {
                if (chkAcc == accNo)
                    valid = true;
            }

            return valid;
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            string acc = checkAccountTextBox.Text;
            
            if(String.IsNullOrEmpty(amountTextBox.Text))
            {
                MessageBox.Show("Enter ammount");
                return;
            }
            amount = Convert.ToDouble(amountTextBox.Text);
            if (AccountExists(acc))
            {
                balance = balance + amount;
                MessageBox.Show("Balance added");
            }
            else
                MessageBox.Show("Accounts does not exist");

            
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            string acc = checkAccountTextBox.Text;

            if (String.IsNullOrEmpty(amountTextBox.Text))
            {
                MessageBox.Show("Enter ammount");
                return;
            }
            amount = Convert.ToDouble(amountTextBox.Text);
            if (AccountExists(acc)) 
            {
                if (amount <= balance)
                {
                    balance = balance - amount;
                    MessageBox.Show("Balance withdrawn");
                }
                else
                    MessageBox.Show("insufficient balance");
            }
            if (!AccountExists(acc))
                MessageBox.Show("Account does not exist");
            
        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Current balance is : " + balance + " taka");
        }
    }
}
