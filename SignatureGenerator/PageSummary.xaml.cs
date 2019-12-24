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
 * Title:   PageSummary.cs
 * Author:  Paul McKillop
 * Date:    22 December 2019
 * Purpose: Display outcome of processing   
 */

namespace SignatureGenerator
{
    #region Page constructor
    /// <summary>
    /// Interaction logic for PageSummary.xaml
    /// </summary>
    public partial class PageSummary : Page
    {
        UserData summary = new UserData();

        /// <summary>
        /// Page constructor with data passed from PageDetails
        /// </summary>
        /// <param name="summaryPassed"></param>
        public PageSummary(UserData summaryPassed)
        {
            InitializeComponent();
            summary = summaryPassed;

            var sb = new StringBuilder();

            sb.AppendLine("Data summary").AppendLine();
            sb.Append("Forename: ").Append("\t").AppendLine(summary.Forename);
            sb.Append("Surname: ").Append("\t").AppendLine(summary.Surname);
            sb.Append("Username: ").Append("\t").AppendLine(summary.Username);
            sb.AppendLine();
            sb.Append("Original: ").Append("\t").Append("\t").AppendLine(summary.UserStringOriginal);
            sb.Append("Encrypted: ").Append("\t").AppendLine(summary.UserStringReversed);
            sb.AppendLine();
            sb.Append("Score: ").Append("\t").Append("\t").AppendLine(summary.Score.ToString());
            sb.Append("Strength: ").Append("\t").Append("\t").AppendLine(summary.StrengthGradeLong);

            var showString = sb.ToString();

            SummaryTextBlock.Text = showString;

        }
        #endregion

        #region Page Navigation and app exit

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var pageDetails = new PageDetails();
            this.NavigationService.Navigate(pageDetails);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        } 
        #endregion
    }
}
