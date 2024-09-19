using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=model;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
        }
        private void LoadProductSalesData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"
                SELECT
                    p.ProductName AS ÜrünAdı,
                    YEAR(s.SaleDate) AS SatışYılı,
                    SUM(s.Quantity) AS ToplamSatışMiktarı,
                    SUM(s.Quantity * p.Price) AS ToplamSatışTutarı
                FROM
                    Sales s
                    JOIN Products p ON s.ProductID = p.ProductID
                GROUP BY
                    p.ProductName,
                    YEAR(s.SaleDate)
                ORDER BY
                    p.ProductName,
                    SatışYılı;", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void LoadTopSellingProduct()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"
                SELECT TOP 1
                    p.ProductName AS ÜrünAdı,
                    SUM(s.Quantity * p.Price) AS ToplamSatışTutarı
                FROM
                    Sales s
                    JOIN Products p ON s.ProductID = p.ProductID
                GROUP BY
                    p.ProductName
                ORDER BY
                    ToplamSatışTutarı DESC;", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProductSalesData();
            LoadTopSellingProduct();// vey
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
