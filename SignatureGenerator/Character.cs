using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   Character
 * Author:  Paul McKillop
 * Date:    22 December 2019
 * Purpose: Ascii character data fields
 */

namespace SignatureGenerator
{
    public class Character
    {
        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string score;

        public string Score
        {
            get { return score; }
            set { score = value; }
        }


    }
}
