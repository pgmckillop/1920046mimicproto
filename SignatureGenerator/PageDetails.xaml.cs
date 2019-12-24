using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
 * Title:   PageDetails.cs
 * Author:  Paul McKillop
 * Date:    22 December 2019
 * Purpose: Validate screen data and harvest for processing
 */

namespace SignatureGenerator
{
    
    /// <summary>
    /// Interaction logic for PageDetails.xaml
    /// </summary>
    public partial class PageDetails : Page
    {
        
        //-- Handler variables. Global in the module
        internal string forename = string.Empty;
        internal string surname = string.Empty;
        internal string userstring = string.Empty;
        
        //-- Validity tracking
        internal bool forenameData;
        internal bool surnameData;
        internal bool userStringData;
        internal bool stringValid = false;
        
        //-- Demo of the use of inherited child class
        private PersonUser personUser = new PersonUser();
        
        //-- Page constructor default
        public PageDetails()
        {
            InitializeComponent();
        }

        #region ClearButton click
        //-- Clear text controls: Calls local method
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }

        #endregion


        #region SummaryButton Click: Process
        /// <summary>
        /// Harvest data and validate
        /// If valid, process for required use
        /// Go to summary page passing all the data in the navigation method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SummaryButton_Click(object sender, RoutedEventArgs e)
        {
            //-- DEBUG MessageBox.Show("Summary button clicked");
            //-- DEBUG MessageBox.Show(HarvestData().ToString());

            forenameData = false;

            if (HarvestData())
            {

                //-- Implementation of child class inherited from Person
                personUser.Forename = forename;
                personUser.Surname = surname;
                personUser.KeyLowerLimit = UtilityZGlobals.LengthRule();

                var userData = new UserData();

                if (UtilityValidator.CharactersAllValid(userstring))
                {
                    stringValid = true;

                    MessageBox.Show("Characters are all valid");
                    //-- The userstring can be processed

                    userData = new UserData
                    {
                        Forename = forename,
                        Surname = surname,
                        Username = UtilityString.MakeUsername(forename, surname),
                        UserStringOriginal = userstring,
                        UserStringReversed = UtilityString.ReverseString(userstring),
                        Score = UtilityValidator.WholeStringScore(userstring),
                        StrengthGradeLong = UtilityValidator.StrengthGradeLong(UtilityValidator.WholeStringScore(userstring))
                    };

                    MessageBox.Show(UserData.SummaryDataDisplay(userData));
                }
                else
                {
                    stringValid = false;

                    var invalidCharacter = UtilityValidator.GetInvalidCharacter(userstring);
                    MessageBox.Show("Invalid character " + invalidCharacter.Character + " at position " + invalidCharacter.Position);
                    //-- DEBUG MessageBox.Show("Invalid characters");
                }
            }
            else
            {
                MessageBox.Show("There was a problem with the data. Follow message instructions");
            }

            var userDataToPass = new UserData
            {
                Forename = forename,
                Surname = surname,
                Username = UtilityString.MakeUsername(forename, surname),
                UserStringOriginal = userstring,
                UserStringReversed = UtilityString.ReverseString(userstring),
                Score = UtilityValidator.WholeStringScore(userstring),
                StrengthGradeLong = UtilityValidator.StrengthGradeLong(UtilityValidator.WholeStringScore(userstring))
            };

            if (stringValid)
            {
                var pageSummary = new PageSummary(userDataToPass);
                this.NavigationService.Navigate(pageSummary);
            }
            else
            {
                MessageBox.Show("Cannot show summary with invalid data");
            }


        } 
        #endregion


        #region ClearControls: clear text controls
        /// <summary>
        /// Clear controls and set focus to ForenameTextBox
        /// </summary>
        private void ClearControls()
        {
            ForenameTextBox.Text = "";
            SurnameTextBox.Text = "";
            UserStringTextBox.Text = "";

            ForenameTextBox.Focus();
        } 
        #endregion


        #region Harvest form data
        /// <summary>
        /// Get data from controls
        /// </summary>
        private bool HarvestData()
        {
            forenameData = false;

            //-- Object to hold data
            FormData formData = new FormData();
            int dataPresent = 0;
            bool allData = false;

            // Forename
            if (ForenameTextBox.Text != "")
            {
                formData.Forename = ForenameTextBox.Text;
                forenameData = true;
                dataPresent++;
            }
            else
            {
                MessageBox.Show("You must enter a Forename");
                forenameData = false;
            }

            // Surname
            if (SurnameTextBox.Text != "")
            {
                formData.Surname = SurnameTextBox.Text;
                surnameData = true;
                dataPresent++;
            }
            else
            {
                MessageBox.Show("You must enter a Surname");
                surnameData = false;
            }

            // User string
            if (UserStringTextBox.Text != "")
            {
                //-- get what's in the text box
                formData.UserString = UserStringTextBox.Text;
                //-- Length check
                if (formData.UserString.Length >= UtilityZGlobals.LengthRule())
                {
                    userStringData = true;
                    dataPresent++;
                }
                else
                {
                    //-- report length error
                    MessageBox.Show("The user entered string does not meet length rule");
                    userStringData = false;
                }

            }
            else
            {
                MessageBox.Show("You must enter a Key String");
                userStringData = false;
            }

            if (dataPresent == 3)
            {
                //-- All is wonderful
                forename = formData.Forename;
                surname = formData.Surname;
                userstring = formData.UserString;

                allData = true;
            }
            else
            {
                //-- There are data missing
                allData = false;
            }

            return allData;
        } 
        #endregion


        #region FormData class
        /// <summary>
        /// Private class for data manipulation during validation and harvest
        /// </summary>
        private class FormData
        {
            public string Forename { get; set; }
            public string Surname { get; set; }
            public string UserString { get; set; }
        } 
        #endregion

    }
}
