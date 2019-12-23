using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

/*
 * Title:   UtilityString
 * Author:  Paul McKillop
 * Date:    22 December 2019
 * Purpose: Class to work with strings, Username etc.
 */

namespace SignatureGenerator
{
    public class UtilityString
    {
        /// <summary>
        /// Get a random integer and covert to string
        /// for concatenation to built user name
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string RandomNumberAsString(int lower, int upper)
        {

            // -- set up random integer object
            Random random = new Random();
            int n = random.Next(lower, upper);

            return n.ToString();
        }

        /// <summary>
        /// Remove leading and trailing and convert to lower
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string TrimAndLower(string myString)
        {
            string st = string.Empty;

            //-- Trim
            st = myString.Trim();

            //-- To Lower Case
            st = st.ToLower();

            return st;
        }

        /// <summary>
        /// Function to reverse a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns>reversed string</returns>
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        /// <summary>
        /// Create the username from initial letters of forename and surname
        /// </summary>
        /// <param name="forename"></param>
        /// <param name="surname"></param>
        /// <returns>string of 2 characters</returns>
        public static string MakeUsername(string forename, string surname, int lower, int upper)
        {
            //-- holding variable
            string s = string.Empty;

            try
            {
                //-- range for random
                lower = 1000;
                upper = 9999;

                //-- string for Trim()
                string st = forename.Trim();

                //-- add forename first initial
                s = s + st.Substring(0, 1);

                //-- same with surname
                st = surname.Trim();
                s = s + st.Substring(0, 1);

                //-- add the random suffix 1000 to 9999
                s = s + RandomNumberAsString(lower, upper);
            }
            catch (Exception ex)
            {
                // -- show error message
                MessageBox.Show(ex.Message);
            }

            return s;
        }

    }
}
