using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication19
{
    public partial class home : System.Web.UI.Page
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=DMS-PC\SQLEXPRESS;Initial Catalog=dms2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //string con = ConfigurationManager.ConnectionStrings["dms2ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                Label1.Text = (string)Session["name"];

            }
            else
            {
                Response.Redirect("default.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id from logins_table where username='" + Label1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Label2.Text =dt.Rows[0][0].ToString();
            
            cmd.CommandText = "insert into share (id,shared)values("+Label2.Text+",'"+TextBox1.Text+"')";
            cmd.ExecuteNonQuery();
            GridView1.DataBind();



            con.Close();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["name"] = null;
        }
    }
}