using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Text;

/*
 * Title:   Lists
 * Author:  Paul McKillop
 * Date:    23 December 2019
 * Purpose: Make lists for search and validation
 */

namespace SignatureGenerator
{
    public class Lists
    {
        /// <summary>
        /// All character data
        /// </summary>
        /// <returns></returns>
        public static List<Character> Characters()
        {
            string path = (@"E:\ascii.txt");

            List<Character> characters = new List<Character>();

            DataTable characterData = new DataTable();

            characterData = UtilityCharacterDb.GetCharacterData(path);

            foreach (DataRow row in characterData.Rows)
            {
                var currentCharacter = new Character
                {
                    Code = row.Field<string>(0),
                    Score = row.Field<string>(1)
                };

                characters.Add(currentCharacter);
            }
            //-- Return the list of codes
            return characters;
        }

        #region ValidCharacters as Characters
        /// <summary>
        /// ValidCharacters as list<Character></Character>
        /// </summary>
        /// <returns></returns>
        public static List<Character> ValidCharacters()
        {
            string path = (@"E:\ascii.txt");

            List<Character> characters = new List<Character>();

            DataTable characterData = new DataTable();

            characterData = UtilityCharacterDb.GetCharacterData(path);

            foreach (DataRow row in characterData.Rows)
            {
                var currentCharacter = new Character
                {
                    Code = row.Field<string>(0),
                    Score = row.Field<string>(1)
                };

                if (currentCharacter.Score != "9")
                {
                    characters.Add(currentCharacter);
                }

            }
            //-- Return the list of codes
            return characters;
        } 
        #endregion

        #region ValidCharacterCodes (Codes only)
        /// <summary>
        /// Valid codes as List<string></string>
        /// </summary>
        /// <returns></returns>
        public static List<string> ValidCharacterCodes()
        {
            string path = (@"E:\ascii.txt");


            List<string> codes = new List<string>();
            //-- Implement using statement to provide memory management
            using (StreamReader reader = new StreamReader(path))
            {
                //-- Loop through all and harvest first column into the list
                while (true)
                {
                    //-- read line
                    string line = reader.ReadLine();
                    //-- Drop if no line data
                    if (line == null)
                    {
                        break;
                    }

                    //-- split fields with comma separator
                    string[] fields = line.Split(',');

                    //-- Initialise a Character oblject to hold data
                    //-- Could use a simple string but demo of OOP process
                    Character character = new Character();

                    if (fields[1] != "9")
                    {
                        //-- Read code field
                        character.Code = fields[0];
                        //-- Add the code to the list
                        codes.Add(character.Code);
                    }
                }
            }

            //-- Return the list of codes
            return codes;
        } 
        #endregion

        /// <summary>
        /// Just Character codes
        /// </summary>
        /// <returns></returns>
        public static List<string> CharacterCodes()
        {
            string path = (@"E:\ascii.txt");


            List<string> codes = new List<string>();
            //-- Implement using statement to provide memory management
            using (StreamReader reader = new StreamReader(path))
            {
                //-- Loop through all and harvest first column into the list
                while (true)
                {
                    //-- read line
                    string line = reader.ReadLine();
                    //-- Drop if no line data
                    if (line == null)
                    {
                        break;
                    }

                    //-- split fields with comma separator
                    string[] fields = line.Split(',');

                    //-- Initialise a Character oblject to hold data
                    //-- Could use a simple string but demo of OOP process
                    Character character = new Character();
                    //-- Read code field
                    character.Code = fields[0];
                    //-- Add the code to the list
                    codes.Add(character.Code);
                }
            }

            //-- Return the list of codes
            return codes;
        }


        #region String is found in list

        /// <summary>
        /// Check if a string is already in a list
        /// </summary>
        /// <param name="listToSearch"></param>
        /// <param name="stringToFind"></param>
        /// <returns>Boolean</returns>
        public static bool StringFound(List<string> listToSearch, string stringToFind)
        {
            //-- tracker variable
            bool stringFound = false;
            //-- Loop through all
            foreach (string value in listToSearch)
            {
                if (value == stringToFind)
                {
                    stringFound = true;
                    return stringFound;
                }
            }

            //-- return true or false: in list, or not
            return stringFound;
        }

        #endregion
    }
}
