using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication19
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DMS-PC\SQLEXPRESS;Initial Catalog=dms2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            i = 0;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from logins_table where username= '" + TextBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32( dt.Rows.Count);
            if (i == 1)
            {
                Response.Write(" username exist try outher username");
            }
            else
            {
                cmd.CommandText = "INSERT INTO logins_table(username, password) VALUES ('"+TextBox1.Text+"','"+TextBox2.Text+"')";
                cmd.ExecuteNonQuery();
                Response.Write("done");
                GridView1.DataBind();
            }
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            i = 0;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from logins_table where username= '" + TextBox3.Text + "' and password='"+TextBox4.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //string one = dt.Rows[0][2].ToString();
            //string two = dt.Rows[0][3].ToString();
            //Label1.Text = one;
            //Label2.Text = two;
            i = Convert.ToInt32(dt.Rows.Count);
            if (i==1)
            {
                
                Session["name"] = TextBox3.Text;
                Response.Redirect("home.aspx");

            }
            else
            {
                Response.Write("invalid username or password");
            }
            con.Close();
        }
    }
}