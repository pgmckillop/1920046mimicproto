﻿using System;
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
        

        public static string SummaryDataDisplay(UserData user)
        {
            var sb = new StringBuilder();

            sb.Append("The user data is as follows: ").AppendLine().AppendLine();
            sb.Append("Forename: ").Append(user.Forename).AppendLine();
            sb.Append("Surname: ").Append(user.Surname).AppendLine();
            sb.Append("Username: ").Append(user.Username).AppendLine();
            sb.AppendLine();
            sb.Append("Original Key: ").Append(user.UserStringOriginal).AppendLine();
            sb.Append("Encrypted: ").Append(user.UserStringReversed).AppendLine();
            sb.AppendLine();
            sb.Append("Key strength: ").Append(user.Score.ToString()).AppendLine();
            sb.Append("Strength Grade: ").Append(user.StrengthGradeLong).AppendLine();
            sb.AppendLine().AppendLine();

            return sb.ToString();

        }

    }
}
