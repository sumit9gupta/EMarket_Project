/*using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetInitialRow();
            }
        }

        private void SetInitialRow()
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
                    drCurrentRow["Column1"] = string.Empty;
                    drCurrentRow["Column2"] = string.Empty;
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

        private void SetPreviousData()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)subyardGrid.Rows[i].Cells[0].FindControl("subyard");
                    TextBox box2 = (TextBox)subyardGrid.Rows[i].Cells[1].FindControl("syCode");

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            SaveDataToDatabase();
        }

        private void SaveDataToDatabase()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                    {
                        con.Open();
                        foreach (GridViewRow row in subyardGrid.Rows)
                        {
                            TextBox txtSubyard = (TextBox)row.Cells[0].FindControl("subyard");
                            TextBox txtSyCode = (TextBox)row.Cells[1].FindControl("syCode");

                            if (txtSubyard != null && txtSyCode != null)
                            {
                                string subyardValue = txtSubyard.Text.Trim();
                                string syCodeValue = txtSyCode.Text.Trim();

                                // Only insert non-empty rows
                                if (!string.IsNullOrEmpty(subyardValue) && !string.IsNullOrEmpty(syCodeValue))
                                {
                                    string query = "INSERT INTO tb (s1, s2) VALUES (@Column1, @Column2)";
                                    using (SqlCommand cmd = new SqlCommand(query, con))
                                    {
                                        cmd.Parameters.AddWithValue("@Column1", subyardValue);
                                        cmd.Parameters.AddWithValue("@Column2", syCodeValue);
                                        cmd.ExecuteNonQuery();
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
    }
}*/