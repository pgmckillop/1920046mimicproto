using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

/*
 * Title:   UtilityCharacterDb
 * Author:  Paul McKillop
 * Date:    22 December 2019
 * Purpose: Class to Create DataTable object of characters in database file
 */

namespace SignatureGenerator
{
    public class UtilityCharacterDb
    {
        /// <summary>
        /// Get DataTable of all character data
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataTable GetCharacterData(string path)
        {
            string databasePath = path;

            //-- initialise a new DataTable
            //-- This has to be done outside the try .. catch construct to allow scope access
            DataTable characterData = new DataTable();

            //-- try to populatye the DataTable variable
            try
            {
                // -- Populate the DataTable with vakues from the text file
                characterData = UtilityImportData.GetTextFileData(databasePath);
            }
            catch (Exception)
            {
                //-- return the exception if thrown
                throw;
            }

            //-- Return DataTable
            return characterData;
        }
    }
}
