using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   UtilityZGlobvals
 * Author:  Paul McKillop
 * Date:    23 December 2019
 * Purpose: Mimic of service provision. Not for production deployment
 *          Single place for references to rules and resources
 */

namespace SignatureGenerator
{
    public class UtilityZGlobals
    {

        /// <summary>
        /// Get the path to the text file database
        /// </summary>
        /// <returns></returns>
        public static string DatabasePath()
        {
            return "E:\ascii.txt";
        }

        /// <summary>
        /// Get the rule for string length
        /// </summary>
        /// <returns></returns>
        public static int LengthRule()
        {
            return  8;
        }
    }
}
