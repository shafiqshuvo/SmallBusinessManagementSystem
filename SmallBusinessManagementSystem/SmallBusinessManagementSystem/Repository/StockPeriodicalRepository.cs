using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementSystem.Model;
using SmallBusinessManagementSystem.Repository;

namespace SmallBusinessManagementSystem.Repository
{
    public class StockPeriodicalRepository
    {
       

        public List <StockPeriodical> searchStock(StockPeriodical stockPeriodical)
        {
            string connectionString = @"Server=FATEMA;DataBase=Project1DB;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"SELECT * FROM StockPeriodical WHERE StartDate  >= '"  + stockPeriodical.startDate + "' AND EndDate <= '" + stockPeriodical.endDate + "' AND Name = '"+stockPeriodical.productName+"' ";
           // SELECT* FROM Product_sales WHERE From_date >= '03-Jan-2013' AND To_date <= '09-Jan-2013'

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();

            List <StockPeriodical> searchPeriodicalStocks = new List <StockPeriodical>();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                StockPeriodical _stockPeriodical = new StockPeriodical();

                _stockPeriodical.Code = Convert.ToString(sqlDataReader["Code"]);
                _stockPeriodical.productName = Convert.ToString(sqlDataReader["Name"]);
                _stockPeriodical.productCategory = Convert.ToString(sqlDataReader["Category"]);
                _stockPeriodical.Reorderlavel = Convert.ToInt32(sqlDataReader["ReorederLevel"]);
                _stockPeriodical.ExpiredDate = Convert.ToString(sqlDataReader["Expired Date"]);              
                _stockPeriodical.OpeningBalance = Convert.ToInt32(sqlDataReader["Openning Balance"]);
                _stockPeriodical.In = Convert.ToInt32(sqlDataReader["In"]);
                _stockPeriodical.Out = Convert.ToInt32(sqlDataReader["Out"]);
                _stockPeriodical.ClosingBalance = Convert.ToInt32(sqlDataReader["Closing Balance"]);
               

                searchPeriodicalStocks.Add(_stockPeriodical);
            }

            sqlConnection.Close();


            return searchPeriodicalStocks;
        }


        public bool hasProductExist(StockPeriodical stockPeriodical)
        {
            bool Exist = false;

            try
            {

                string connectionString = @"Server=FATEMA; DataBase=Project1DB ; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Comand establish
                string commandString = @"SELECT * FROM StockPeriodical WHERE Name  = '" + stockPeriodical.productName + "' ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                //Sql command Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                //Ckeck for uniqueness
                if (dataTable.Rows.Count > 0)
                {
                    Exist = true;

                }


                sqlConnection.Close();
            }

            catch (Exception exception)
            {
                // MessageBox.Show(exception.Message);
            }

            return Exist;
        }

        public List<StockPeriodical> searchByLosearchBwerreorderLevelStock(StockPeriodical stockPeriodical)
        {
            string connectionString = @"Server=FATEMA;DataBase=Project1DB;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"SELECT * FROM StockPeriodical WHERE StartDate  >= '" + stockPeriodical.startDate + "' AND EndDate <= '" + stockPeriodical.endDate + "' ";
            // SELECT* FROM Product_sales WHERE From_date >= '03-Jan-2013' AND To_date <= '09-Jan-2013'

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();

            List<StockPeriodical> searchPeriodicalStocks = new List<StockPeriodical>();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                StockPeriodical _stockPeriodical = new StockPeriodical();

                _stockPeriodical.Code = Convert.ToString(sqlDataReader["Code"]);
                _stockPeriodical.productName = Convert.ToString(sqlDataReader["Name"]);
                _stockPeriodical.productCategory = Convert.ToString(sqlDataReader["Category"]);
                _stockPeriodical.Reorderlavel = Convert.ToInt32(sqlDataReader["ReorederLevel"]);
                _stockPeriodical.ExpiredDate = Convert.ToString(sqlDataReader["Expired Date"]);
                _stockPeriodical.OpeningBalance = Convert.ToInt32(sqlDataReader["Openning Balance"]);
                _stockPeriodical.In = Convert.ToInt32(sqlDataReader["In"]);
                _stockPeriodical.Out = Convert.ToInt32(sqlDataReader["Out"]);
                _stockPeriodical.ClosingBalance = Convert.ToInt32(sqlDataReader["Closing Balance"]);


                searchPeriodicalStocks.Add(_stockPeriodical);
            }

            sqlConnection.Close();


            return searchPeriodicalStocks;
        }
    }
}
