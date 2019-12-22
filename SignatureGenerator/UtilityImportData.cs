using System.IO;
using System.Text.RegularExpressions;
using System.Data;

/*
 * Title:   UtilityImportData
 * Author:  Paul McKillop
 * Date:    22 December 2019
 * Purpose: Class to return a DataTable from a Text File
 */

namespace SignatureGenerator
{
    public class UtilityImportData
    {
        public static DataTable GetTextFileData(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            // Read the first line only for column headers
            // and use these to create the DataTable columns
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();

            // -- error trap and throw any exceptions
            try
            {
                //- headers
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }

                // Read the reamining data into the DataTable
                // to the EndOfStream
                while (!sr.EndOfStream)
                {
                    // Regex with escape caharacters
                    string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            // return the DataTable from the method
            return dt;
        }
    }
}
