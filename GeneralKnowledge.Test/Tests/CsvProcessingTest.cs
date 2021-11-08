using System.Data;
using System.Data.SqlClient;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    { 
        public void Run()
        {
            // TODO
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted

            //create database Asset;
            // create table AssetProcess(id int primary key identity(1,1),country varchar(150),
            // asset varchar(150), mimeType varchar(150))


            // CREATE TYPE[dbo].[AssetType] AS TABLE(
            // [Asset][varchar](100) NULL,
            // [country][varchar](50) NULL,
            // [mimeType][varchar](150) NULL
            // )

            // CREATE PROCEDURE[dbo].[Insert_Asset]
            // @tblAsset AssetType READONLY
            // AS
            // BEGIN
            // SET NOCOUNT ON;

            //            --INSERT INTO AssetProcess(asset, mimeType, Country)
            //--SELECT Asset, mimeType, country FROM @tblAsset
            //--END
          
            var csvFile = Resources.AssetImport;
            string[] values = csvFile.Split('\n');
            DataTable dt = new DataTable();
            dt.Columns.Add("Asset");
            dt.Columns.Add("country");
            dt.Columns.Add("mimeType");
            for (int iCount = 0; iCount < values.Length - 1; iCount++)
            {
                if (iCount > 0)
                {
                    string[] dataSpt = values[iCount].Split(',');
                    string assetName = dataSpt[0];
                    string country = dataSpt[5];
                    string mimeType = dataSpt[2];
                    dt.Rows.Add(assetName, country, mimeType);
                }
            }
            string connection = "connection string";
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert_Asset"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblAsset", dt);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }

}
