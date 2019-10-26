using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmallBusinessManagementSystem.Manager;
using SmallBusinessManagementSystem.Model;

namespace SmallBusinessManagementSystem.UI
{
    public partial class StockPeriodicalUI : Form
    {
        public StockPeriodicalUI()
        {
            InitializeComponent();
        }

       
        StockPeriodicalManager _stockPeriodicalManager = new StockPeriodicalManager();
        StockPeriodical stockPeriodical = new StockPeriodical();

        private void searchStockButton_Click(object sender, EventArgs e)
        {
           
            if (!String.IsNullOrEmpty(stockProductTextBox.Text) && !String.IsNullOrEmpty(stockCategoryTextBox.Text) )
            {

                 stockPeriodical.startDate = startDateTimePicker.Text;
                 stockPeriodical.endDate = endDateTimePicker.Text;
                 stockPeriodical.productName = stockProductTextBox.Text;
                 stockPeriodical.productCategory = stockCategoryTextBox.Text;

            }
           
            else
            {
                MessageBox.Show("Product Name and Category Must be Required ");
            }

           

            bool isExist = _stockPeriodicalManager.hasProductExist(stockPeriodical);
            if (isExist)
            {
                stockSearchDataGridView.DataSource = _stockPeriodicalManager.searchStock( stockPeriodical);
            }

            
        }

        private void stockSearchDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            stockSearchDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();

        }

        
    }
}
