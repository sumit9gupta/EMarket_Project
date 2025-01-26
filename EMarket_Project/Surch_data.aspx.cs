using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EMarket_Project
{
    public partial class Surch_data : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            DropDownList1.Items.Insert(0, "--Select--");
            SqlCommand cmd = new SqlCommand("Select DistrictName from District", con);
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr["DistrictName"].ToString());
            }
            con.Close();
        }

        private void GridViewData()
        {
            con.Open();
            con.Close();
        }
       
    }
}