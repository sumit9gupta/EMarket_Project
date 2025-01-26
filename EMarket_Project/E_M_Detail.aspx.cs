using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Data.Odbc;
using System.Runtime.CompilerServices;
using WebGrease.Activities;

namespace EMarket_Project
{
    public partial class E_M_Detail : System.Web.UI.Page
    {
       


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());

        string ThakPatti = "";
        string MarketFee = "";
        string district = "";
        string Serchtext = "";

        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            lblMessage.Text = "";
         
            if (!IsPostBack)
            {
                SetInitialRow_grid();
                District1();
                District2();
                BindGridView();
                GetData();
               
                
            }

        }


        private void District1()
        {
            con.Open();
            DropDownDistrict.Items.Insert(0, "Select");
            SqlCommand cmd = new SqlCommand("select DistrictName from District", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownDistrict.Items.Add(dr["DistrictName"].ToString());
            }

            con.Close();
        }
        private void District2()
        {
            con.Open();
            DropDownListDistictSeartch.Items.Insert(0, "Select");
            SqlCommand cmd = new SqlCommand("select DistrictName from District", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownListDistictSeartch.Items.Add(dr["DistrictName"].ToString());
            }

            con.Close();
        }


        private void ForEmpty()
        {
            txtAccountNo.Text = "";
            txtAddress.Text = "";
            txtBenifecName.Text = "";
            txtCode.Text = "";
            txtEmail.Text = "";
            txtMarketN.Text = "";
            txtIfsc.Text = "";
            DropDownDistrict.SelectedIndex = 0;
            RadioTrader.Checked = false;
            RadioTrader.Checked = false;
            CheckBoxSecretary.Checked = false;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            ForEmpty();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Market1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictName", DropDownDistrict.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@MarketName", txtMarketN.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Code", txtCode.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@AccountNo", txtAccountNo.Text);
                cmd.Parameters.AddWithValue("@IFSCCode", txtIfsc.Text);
                cmd.Parameters.AddWithValue("@BeneficiaryName", txtBenifecName.Text);
                if (CheckBoxSecretary.Checked == true)
                {
                    ThakPatti = "secretary";
                }
                cmd.Parameters.AddWithValue("@ThakPatti", ThakPatti);

                if (RadioTrader.Checked == true)
                {
                    MarketFee = "Trader";
                }
                if (RadioCommissionAgent.Checked == true)
                {
                    MarketFee = "CommisionAgent";
                }

                cmd.Parameters.AddWithValue("@MarketFee", MarketFee);
                SqlParameter output = new SqlParameter("@Mid", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(output); 

                int res = cmd.ExecuteNonQuery();
                int mid=(int)output.Value;
                SaveDataToDatabase(mid);
                BindGridView();
                if (res == 1)
                {
                    lblMessage.Text = "Data Inserted Sucessfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                con.Close();


                ForEmpty();

            }
            catch (SqlException ex)
            {

                lblMessage.Text = ex.Message;
            }
        }

        
        private void SetInitialRow_grid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));

            DataRow dr = dt.NewRow();
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;
            subyardGrid.DataSource = dt;
            subyardGrid.DataBind();

        }
       
        private void AddNewRowToGrid()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)subyardGrid.Rows[i].Cells[0].FindControl("subyard");
                        TextBox box2 = (TextBox)subyardGrid.Rows[i].Cells[1].FindControl("syCode");

                        dtCurrentTable.Rows[i]["Column1"] = box1?.Text;
                        dtCurrentTable.Rows[i]["Column2"] = box2?.Text;
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable"] = dtCurrentTable;

                    subyardGrid.DataSource = dtCurrentTable;
                    subyardGrid.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }

        private void DeleteRow(int rowIndex)
        {
           
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                
                dtCurrentTable.Rows.RemoveAt(rowIndex);

                
                ViewState["CurrentTable"] = dtCurrentTable;
                subyardGrid.DataSource = dtCurrentTable;
                subyardGrid.DataBind();
            }
        }

        protected void subyardGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddRow")
            {
                AddNewRowToGrid();
            }
            else if (e.CommandName == "DeleteRow")
            {
                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                DeleteRow(rowIndex);
            }
        }


        private void SetPreviousData()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)subyardGrid.Rows[i].Cells[0].FindControl("txtsubyardName");
                    TextBox box2 = (TextBox)subyardGrid.Rows[i].Cells[1].FindControl("txtsubyardName");

                    if (box1 != null)
                    {
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                    }

                    if (box2 != null)
                    {
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                    }
                }
            }
        }

        private void SaveDataToDatabase(int id)
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ConnectionString))
                    {
                        con.Open();
                        foreach (GridViewRow row in subyardGrid.Rows)
                        {
                            TextBox txtsubyardName = (TextBox)row.Cells[0].FindControl("txtsubyardName");
                            TextBox txtsubyardCode = (TextBox)row.Cells[1].FindControl("txtsubyardName");

                            if (txtsubyardName != null && txtsubyardCode != null)
                            {
                                string subyardValue = txtsubyardName.Text.Trim();
                                string syCodeValue = txtsubyardCode.Text.Trim();

                                
                                if (!string.IsNullOrEmpty(subyardValue) && !string.IsNullOrEmpty(syCodeValue))
                                {
                                   
                                    using (SqlCommand cmd = new
                                        SqlCommand("insert into SubYard(subyardName,subyardcode,MarketId) values(@subyardName,@subyardcode,@mid)", con))
                                    {
                                        cmd.Parameters.AddWithValue("@subyardName", subyardValue);
                                        cmd.Parameters.AddWithValue("@subyardcode", syCodeValue);
                                        cmd.Parameters.AddWithValue("@mid", id);

                                        int i=cmd.ExecuteNonQuery();
                                        if (i > 0) 
                                            lblMessage.Text = lblMessage.Text + i.ToString();
                                        else lblMessage.Text = "error";
                                    }
                                }
                            }
                        }
                        con.Close();



                    }
                }
            }

        }

        protected void btnAddNewRow_Click1(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        private void ShowData_GridView_sarch()
        {
            con.Open();

            con.Close();
        }

        private DataTable GetData()
        {
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("SubYard");
            dt.Columns.Add("District");
            dt.Columns.Add("MarketName");
            dt.Columns.Add("Code");
            dt.Columns.Add("Address");
            dt.Columns.Add("Email");

            for (int i = 1; i <= 10; i++) 
            {
                dt.Rows.Add("SubYard " + i, "District " + i, "Market " + i, "Code " + i, "Address " + i, "email" + i + "@example.com");
            }
            con.Close();
            return dt;
           
        }



        protected void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
            {
                SqlDataAdapter da = new SqlDataAdapter("gridData", con);
                DataSet ds = new DataSet();

                try
                {
                    con.Open(); 
                    da.Fill(ds, "Market"); 
                    GridView1.DataSource = ds.Tables["Market"]; 
                    GridView1.DataBind(); 
                }
                catch (Exception ex)
                {
                   
                    Response.Write("Error: " + ex.Message);
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex= e.NewPageIndex;    
            BindGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Serchtext = txtSeartch.Text;
           
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            BindGridView();
            txtSeartch.Text = "";
        }

        protected void imgDelete2_Click1(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;

            
            DeleteRow2(rowIndex);
        }

        private void DeleteRow2(int rowIndex)
        {
            
            if (ViewState["CurrentTable"] != null)
            {
               
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

               
                if (dtCurrentTable.Rows.Count > rowIndex)
                {
                    dtCurrentTable.Rows.RemoveAt(rowIndex);
                }

                
                ViewState["CurrentTable"] = dtCurrentTable;

                
                subyardGrid.DataSource = dtCurrentTable;
                subyardGrid.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Market SET DistrictName=@DistrictName, MarketName=@MarketName WHERE MarketId=@MarketId", con);
                
                con.Close();
            }
            catch (SqlException ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

      
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView(); 
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            GridViewRow row = GridView1.Rows[e.RowIndex];

           
            string district = ((TextBox)row.FindControl("txtgridDistNAme")).Text;
            string marketName = ((TextBox)row.FindControl("txtgridMArketName")).Text;
            string code = ((TextBox)row.FindControl("txtgridCode")).Text;
            string address = ((TextBox)row.FindControl("txtgridaddress")).Text;
            string email = ((TextBox)row.FindControl("txtgridemail")).Text;

            
            int marketId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

           
            UpdateMarketDetails(marketId, district, marketName, code, address, email);

            
            GridView1.EditIndex = -1;
            BindGridView(); 
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
            GridView1.EditIndex = -1;
            BindGridView(); 
        }

        

        private void UpdateMarketDetails(int marketId, string district, string marketName, string code, string address, string email)
        {
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateMarketDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictName", district);
                cmd.Parameters.AddWithValue("@MarketName", marketName);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MarketId", marketId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {

        }

        protected void DropDownDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedDistrict = DropDownDistrict.SelectedValue;

            
            if (IsDistrictAlreadyExists(selectedDistrict))
            {
                
                lblError.Text = "This district already exists in the database.";
                lblError.Visible = true;
            }
            else
            {
               
                lblError.Visible = false;
            }
        }

        private bool IsDistrictAlreadyExists(string district)
        {
            bool exists = false;

            
            string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                string query = "SELECT COUNT(1) FROM Market WHERE DistrictName = @District";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@District", district);

                con.Open();
                exists = (int)cmd.ExecuteScalar() > 0; 
                con.Close();
            }

            return exists;
        }

        private bool IsEmailAlreadyExists(string email)
        {
            bool exists = false;

            string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Market WHERE Email = @Email";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);

                con.Open();
                exists = (int)cmd.ExecuteScalar() > 0; 
                con.Close();
            }

            return exists;
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim(); 

           
            if (IsEmailAlreadyExists(email))
            {
                lblEmailError.Text = "This email ID already exists in the database.";
                lblEmailError.Visible = true;
            }
            else
            {
                lblEmailError.Visible = false;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int marketId = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Value);
                GridView subyards = e.Row.FindControl("subyards") as GridView;

                if (subyards != null)
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
                    {
                        SqlCommand cmd = new SqlCommand("sp_BindChildGrid", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mid", marketId);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        try
                        {
                            con.Open();
                            da.Fill(dt);
                            subyards.DataSource = dt;
                            subyards.DataBind();
                        }
                        catch (Exception ex)
                        {

                            lblError.Text = "Error: " + ex.Message;
                        }
                    }
                }
            }
        }
        protected void txtSeartch_TextChanged(object sender, EventArgs e)
        {
           string seartchtxt = txtSeartch.Text;

            if(Serchtext.Length>0 )
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DisticMarket_search", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mname",  Serchtext );
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
        protected void DropDownListDistictSeartch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dropdownDistt= DropDownListDistictSeartch.SelectedValue.ToString();

            if (dropdownDistt.Length > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DisticMarket_search", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mname", Serchtext);
                cmd.Parameters.AddWithValue("@distname", DropDownListDistictSeartch.SelectedValue.ToString() );
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }


       
        
    }
}





