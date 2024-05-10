﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paying_Guest_Management_System.Admin
{
    public partial class HostReview : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Paying Guest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public HostReview()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from Host_Registation where Status='Approve'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(comboBox2.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))

                {
                    con.Open();
                    SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM  [Paying Guest].[dbo].[Review] WHERE  HostName='" + textBox1.Text + "' and AdminHostReview is not null ", con);

                    int UserExist = (int)check_User_Name.ExecuteScalar();
                    con.Close();



                    if (UserExist > 0)
                    {
                        MessageBox.Show("Review Already Done ");
                    }

                    else
                    {



                        if (MessageBox.Show("Do You Want To Review This Guest", "Review This Guest", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            con.Open();
                            SqlCommand command = new SqlCommand("UPDATE Review set HostName='"+ textBox1.Text + "',AdminHostReview='"+ comboBox2.Text + "' where AdminHostReview is null ", con);
                          
                  


                            command.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Review Done");


                            comboBox2.Text = "";
                            textBox1.Text = "";





                        }
                        else
                        {
                            MessageBox.Show("Review Not Done", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                }

                else
                {

                    MessageBox.Show("Please Fill Up All The Informaton");
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(comboBox2.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))

                {
                    con.Open();
                    SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM  [Paying Guest].[dbo].[Review] WHERE  HostName='" + textBox1.Text + "' and AdminHostReview is not null ", con);

                    int UserExist = (int)check_User_Name.ExecuteScalar();
                    con.Close();



                    if (UserExist > 0)
                    {
                        MessageBox.Show("Review Found ");
                        if (MessageBox.Show("Do You Want To Review This Guest", "Review This Guest", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            con.Open();
                            SqlCommand command = new SqlCommand("Update Review set AdminHostReview='" + comboBox2.Text + "' where HostName='" + textBox1.Text + "'", con);



                            command.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Update Done");


                            comboBox2.Text = "";
                            textBox1.Text = "";





                        }
                        else
                        {
                            MessageBox.Show("Review Not Done", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    else
                    {


                        MessageBox.Show("Review Not Found ");


                    }
                }

                else
                {

                    MessageBox.Show("Please Fill Up All The Informaton");
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void gunaDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = gunaDataGridView2.SelectedRows[0].Cells[8].Value.ToString();
            comboBox2.Text = gunaDataGridView2.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("  select Host_Registation.Name,Host_Registation.Phone,Host_Registation.Email,Host_Registation.Address,Host_Registation.Gender,Host_Registation.Status,[Review].AdminHostReview,[Review].GuestReview,[Review].HostName AS 'HostUserName' FROM [Paying Guest].[dbo].[Review] inner join [Paying Guest].[dbo].Host_Registation on Review.HostName=Host_Registation.UserName where Host_Registation.Status='Approve' and Review.AdminHostReview is not null", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gunaDataGridView2.DataSource = dt;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
