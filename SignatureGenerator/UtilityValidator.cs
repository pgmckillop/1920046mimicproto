using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

/*
 * Title:   UtilityValidator
 * Author:  Paul McKillop
 * Date:    23 December 2019
 * Purpose: Checking and scoring outcomes
 */

namespace SignatureGenerator
{   
    class UtilityValidator
    {
        //-- Rules as module-wide variables
        static int strengthRuleMinimum = UtilityZGlobals.LengthRule();

        /// <summary>
        /// Check meets length standard
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static bool LengthRuleCheck(string myString)
        {
            return myString.Length >= strengthRuleMinimum;
        }


        #region CharactersAllValid
        /// <summary>
        /// Check if the characters in user string are all valid
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        public static bool CharactersAllValid(string stringToCheck)
        {
            bool tempBool = true;

            List<string> validCharacterCodes = Lists.ValidCharacterCodes();

            stringToCheck.ToCharArray();

            int stringLength = stringToCheck.Length;

            for (int i = 0; i < stringLength; i++)
            {
                if (!Lists.StringFound(validCharacterCodes, ((int)stringToCheck[i]).ToString()))
                {
                    tempBool = false;
                }
            }

            return tempBool;
        }
        #endregion

        #region GetInvalidCharacter
        /// <summary>
        /// Error infomation of invalid character userstring data
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        public static InvalidCharacter GetInvalidCharacter(string stringToCheck)
        {

            var invalidCharacter = new InvalidCharacter();

            List<string> validCharacterCodes = Lists.ValidCharacterCodes();

            stringToCheck.ToCharArray();

            int stringLength = stringToCheck.Length;

            for (int i = 0; i < stringLength; i++)
            {
                if (!Lists.StringFound(validCharacterCodes, ((int)stringToCheck[i]).ToString()))
                {
                    invalidCharacter.Character = stringToCheck[i].ToString();
                    invalidCharacter.Position = i + 1;
                    break;
                }
            }

            return invalidCharacter;
        }
        #endregion


        
        public static int CurrentLetterScore(string letterToCheck)
        {
            string path = (@"E:\ascii.txt");
            var tempScore = 0;

            DataTable characterData = new DataTable();

            characterData = UtilityCharacterDb.GetCharacterData(path);

            foreach (DataRow row in characterData.Rows)
            {
                var currentCharacter = new Character
                {
                    Code = row.Field<string>(0),
                    Score = row.Field<string>(1)
                };

                if (currentCharacter.Code == letterToCheck)
                {
                    tempScore = Int32.Parse(currentCharacter.Score);
                }

            }

            return tempScore;

        }
        
        
        public static int WholeStringScore(string userstring)
        {
            var tempScore = 0;
            var stringLength = userstring.Length;

            userstring.ToCharArray();

            for (int i = 0; i < stringLength; i++)
            {
                tempScore += UtilityValidator.CurrentLetterScore(((int)userstring[i]).ToString());
            }

            return tempScore;
        }

        /// <summary>
        /// Grade of string as full string
        /// </summary>
        /// <param name="strengthScore"></param>
        /// <returns></returns>
        public static string StrengthGradeLong(int strengthScore)
        {
            string outcome;

            switch (strengthScore)
            {
                case int n when (n <= 7):
                    outcome = "Unnacceptable";
                    break;
                case int n when (n >= 8 && n <= 10):
                    outcome = "Weak";
                    break;
                case int n when (n >= 11 && n <= 16):
                    outcome = "Medium";
                    break;
                case int n when (n >= 17):
                    outcome = "Strong";
                    break;
                default:
                    outcome = "Invalid";
                    break;
            }


            return outcome;
        }


        /// <summary>
        /// Individual character score
        /// </summary>
        /// <param name="characterCode"></param>
        /// <returns></returns>
        public static int CharacterScore(string characterCode)
        {
            int charScore = 0;

            List<Character> characters = Lists.Characters();
            foreach(Character character in characters)
            {
                if(character.Code == characterCode)
                {
                    charScore = Int32.Parse(character.Score);
                    return charScore;
                }
            }

            return charScore;
        }


    }
}
