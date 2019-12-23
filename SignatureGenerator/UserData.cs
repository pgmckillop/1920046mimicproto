using System;
using System.Collections.Generic;
using System.Text;

/*
 * Title:   UserData
 * Author:  Paul McKillop
 * Date:    23 December 2019
 * Purpose: Summary of all user information post propcessing
 *          Ready for display in PageSummary
 */

namespace SignatureGenerator
{
    public class UserData
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string UserStringOriginal { get; set; }
        public string UserStringReversed { get; set; }public int Length { get; set; }
        public int Score { get; set; }
        public string StrengthGradeLong { get; set; }
        

    }
}
