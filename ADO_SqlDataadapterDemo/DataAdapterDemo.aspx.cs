using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADO_SqlDataadapterDemo
{
    public partial class DataAdapterDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;


            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("GETTWOTABLE", connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dataSetds = new DataSet();
                dataAdapter.Fill(dataSetds);

                dataSetds.Tables[0].TableName = "Product";
                dataSetds.Tables[1].TableName = "ProductDetails";

                GridView1.DataSource = dataSetds.Tables["Product"];
                GridView1.DataBind();

                GridView2.DataSource = dataSetds.Tables["ProductDetails"];
                GridView2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;


            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Sp_GETALLById", connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerId", TextBox1.Text);
                DataSet dataSetds = new DataSet();
                dataAdapter.Fill(dataSetds);

                GridView1.DataSource = dataSetds;
                GridView1.DataBind();

               
            }

        }

       
    }
}