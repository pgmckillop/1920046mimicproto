using System;
using System.Collections.Generic;
using System.Text;
/*
 * Title:   Person
 * Author:  Paul McKillop
 * Date:    22 December 2019
 * Purpose: Hold pasrent class data for Person
 */

namespace SignatureGenerator
{
    public class Person
    {
        // -- Forename
        private string forename;

        public string Forename
        {
            get { return forename; }
            set { forename = value; }
        }

        // -- Surname
        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
    }
}
