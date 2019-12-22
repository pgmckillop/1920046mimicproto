using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   PersonUser
 * Author:  Paul McKillop
 * Date:    22 December 2019
 * Purpose: Class to hold data child of Person, user of system
 */

namespace SignatureGenerator
{
    public class PersonUser
    {
        // -- Key length requirement as an integer
        private int keyLowerLimit;

        public int KeyLowerLimit
        {
            get { return keyLowerLimit; }
            set { keyLowerLimit = value; }
        }
    }
}
