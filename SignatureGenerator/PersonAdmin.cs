using System;
using System.Collections.Generic;
using System.Text;
/*
 * Title:   PersonAdmin
 * Author:  Paul McKillop
 * Date:    22 December 2019
 * Purpose: Class to hold data child of Person, Admin user
 */

namespace SignatureGenerator
{
    public class PersonAdmin
    {
        // -- Security level as an integer
        private int securityLevel;

        public int SecurityLevel
        {
            get { return securityLevel; }
            set { securityLevel = value; }
        }
    }
}
