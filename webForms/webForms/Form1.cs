using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webForms
{
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Admin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            if(txtid.Text==string.Empty)
            {
                errorProvider1.SetError(txtid, "can't insert");
                txtid.Focus();
            }
            else
            {
                String qry = "insert into login (id,uname,password)values('" + txtid.Text + "','" + txtuname.Text + "','" + txtpass.Text + "')";
                cmd = new SqlCommand(qry, con);
                int exe = cmd.ExecuteNonQuery();
                if (exe > 0)
                {
                    MessageBox.Show("Inserted sucessfully");
                    da = new SqlDataAdapter("select * from login", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            String qry="update login set uname=" + txtid.Text + "','" + txtuname.Text + "' where id='"+txtid.Text+"'";
            cmd = new SqlCommand(qry, con);
            int exe = cmd.ExecuteNonQuery();
            if(exe>0)
            {
                MessageBox.Show("Data Updated sucessfully");
                da = new SqlDataAdapter("select * from login", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            String qry = "delete * from login";
            cmd = new SqlCommand(qry, con);
            int exe = cmd.ExecuteNonQuery();
            if(exe>0)
            {
                MessageBox.Show("Data deleted sucessfully");
                da = new SqlDataAdapter("select * from login", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btndisp_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select*from login", con);
            DataSet ds = new DataSet();
            da.Fill();
            con.Close();
            DataGridView dv = new DataGridView();

        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtuname.Text = "";
            txtpass.Text = "";
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
