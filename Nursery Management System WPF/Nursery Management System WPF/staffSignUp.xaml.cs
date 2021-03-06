﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nursery_Management_System_WPF
{
    /// <summary>
    /// Interaction logic for staffSignUp.xaml
    /// </summary>
    public partial class staffSignUp : Window
    {
        public staffSignUp()
        {
            InitializeComponent();

            firstName.LostFocus += FirstName_LostFocus;
            firstName.GotFocus += FirstName_GotFocus;

            lastName.LostFocus += LastName_LostFocus;
            lastName.GotFocus += LastName_GotFocus;

            ID.LostFocus += ID_LostFocus;
            ID.GotFocus += ID_GotFocus;

            email.LostFocus += Email_LostFocus;
            email.GotFocus += Email_GotFocus;

            phoneNumber.LostFocus += PhoneNumber_LostFocus;
            phoneNumber.GotFocus += PhoneNumber_GotFocus;

            username.LostFocus += Username_LostFocus;
            username.GotFocus += Username_GotFocus;

        }
        
        private void Username_GotFocus(object sender, RoutedEventArgs e)
        {
            username.Text = "";
        }

        private void Username_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username.Text))
                username.Text = "Enter Username Here";
        }

        private void PhoneNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            phoneNumber.Text = "";
        }

        private void PhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber.Text))
                phoneNumber.Text = "Enter Phone Number Here";
        }

        private void Email_GotFocus(object sender, RoutedEventArgs e)
        {
            email.Text = "";
        }

        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email.Text))
                email.Text = "Enter Email Here";
        }

        private void ID_GotFocus(object sender, RoutedEventArgs e)
        {
            ID.Text = "";
        }

        private void ID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ID.Text))
                ID.Text = "Enter National Number Here";
        }

        private void LastName_GotFocus(object sender, RoutedEventArgs e)
        {
            lastName.Text = "";
        }

        private void LastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lastName.Text))
                lastName.Text = "Enter lastName Here";
        }

        private void FirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            firstName.Text = "";
        }

        private void FirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstName.Text))
                firstName.Text = "Enter firstName Here";
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkEnteredData())
            {
                SQLQuery mSQLQuery = new SQLQuery();
                Staff staff = new Staff(Convert.ToInt64(ID.Text), firstName.Text, lastName.Text, phoneNumber.Text, email.Text, -1, 1, "Staff");
                mSQLQuery.insertStaffData(staff, "Staff");

                mSQLQuery.insertUser(username.Text, password.Password, "Staff", staff.id);
                MessageBox.Show("Requset has been sent", "Request sent", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }

        public bool checkEnteredData()
        {
            bool ans = true;
            ValidateData validator = new ValidateData();
            SQLQuery mSql = new SQLQuery();

            if(!validator.verifyField(firstName.Text) || firstName.Text.Equals("Enter First Name Here"))
            {
                ans = false;
                firstNameError.Visibility = Visibility;
            }
            else
            {
                firstNameError.Visibility = Visibility.Hidden;
            }

            if (!validator.verifyField(lastName.Text) || lastName.Text.Equals("Enter Last Name Here"))
            {
                ans = false;
                lastNameError.Visibility = Visibility;
            }
            else
            {
                lastNameError.Visibility = Visibility.Hidden;
            }

            if (!validator.checkNationalID(ID.Text))
            {
                ans = false;
                IDError.Visibility = Visibility;
            }
            else
            {
                IDError.Visibility = Visibility.Hidden;
            }

            if (!validator.checkMails(email.Text))
            {
                ans = false;
                emailError.Visibility = Visibility;
            }
            else
            {
                emailError.Visibility = Visibility.Hidden;
            }

            if (!validator.checkPhoneNum(phoneNumber.Text))
            {
                ans = false;
                phoneError.Visibility = Visibility;
            }
            else
            {
                phoneError.Visibility = Visibility.Hidden;
            }
            
            if(mSql.checkForUsername(username.Text) || username.Text.Equals("Enter Username Here"))
            {
                ans = false;
                usernameError.Visibility = Visibility.Visible;
            }
            else
            {
                usernameError.Visibility = Visibility.Hidden;
            }

            if (validator.verifyField(password.Password))
            {
                ans = false;
                passwordError.Visibility = Visibility.Visible;
            }
            else
            {
                passwordError.Visibility = Visibility.Hidden;
            }

            return ans;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            signUp signUpForm = new signUp();
            signUpForm.Show();
            this.Close();
        }
    }
}
