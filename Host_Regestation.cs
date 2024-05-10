﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paying_Guest_Management_System
{
    public partial class Host_Regestation : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Paying Guest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Host_Regestation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Host_Regestation_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
                {

                    string name = textBox2.Text.ToString();
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (name[0] == 'H')
                        {
                            if (name[1] == 'o')
                            {
                                if (name[2] == '-')
                                {

                                    errorProvider2.Clear();
                                    button2.Enabled = true;
                                    button2.BackColor = Color.White;
                                    con.Open();

                                    if (MessageBox.Show("Do You Want To Insert This Data", "Insert Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {


                                        SqlCommand command = new SqlCommand("insert into Host_Registation values (@Name,@Email,@Phone,@Address,@Gender,@UserName,@Password,@Status)", con);
                                        command.Parameters.AddWithValue("@Name", textBox6.Text);
                                        command.Parameters.AddWithValue("@Email", textBox3.Text);
                                        command.Parameters.AddWithValue("@Phone", textBox4.Text);
                                        command.Parameters.AddWithValue("@Address", textBox5.Text);
                                        command.Parameters.AddWithValue("@Gender", comboBox1.Text);
                                        command.Parameters.AddWithValue("@UserName", textBox2.Text);
                                        command.Parameters.AddWithValue("@Password", textBox1.Text);
                                        command.Parameters.AddWithValue("@Status", "pending");

                                        command.ExecuteNonQuery();


                                        textBox1.Text = "";
                                        textBox3.Text = "";
                                        textBox4.Text = "";
                                        textBox5.Text = "";
                                        textBox6.Text = "";
                                        comboBox1.Text = "";
                                        Login log = new Login();
                                        log.Show();
                                        this.Hide();

                                        ;
                                        con.Close();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Data Not Inserted", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }

                                    return;
                                }

                            }

                        }
                        else
                        {
                            errorProvider2.SetError(this.textBox2, " User Name Must contain Ho-");
                            button2.Enabled = false;
                            button2.BackColor = Color.Red;

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM  [Paying Guest].[dbo].[Host_Registation] WHERE ([UserName] = @UserName)", con);
            check_User_Name.Parameters.AddWithValue("@UserName", textBox2.Text);
            int UserExist = (int)check_User_Name.ExecuteScalar();
            con.Close();
            if (UserExist > 0)
            {
                errorProvider2.SetError(this.textBox2, " User Name Already Inserted");
                button2.Enabled = false;
                button2.BackColor = Color.Red;
        
                return;

            }
            else
            {
                errorProvider2.Clear();
                button2.Enabled = true;
                button2.BackColor = Color.White;
            }

           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]{11}$");
            if (regex.IsMatch(textBox4.Text))
            {
                errorProvider2.Clear();
                button2.Enabled = true;
                button2.BackColor = Color.White;


            }
            else
            {
                errorProvider2.SetError(this.textBox4, " Provide only 11 Digite");
                button2.Enabled = false;
                button2.BackColor = Color.Red;

                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^([0-9a-zA-Z]([-.\\w\\+]*[0-9a-zA-Z\\+])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");

            if (regex.IsMatch(textBox3.Text))
            {
                errorProvider1.Clear();
                button2.Enabled = true;
                button2.BackColor = Color.White;


            }
            else
            {
                errorProvider1.SetError(this.textBox3, " Provide valid Mail address");
                button2.Enabled = false;
                button2.BackColor = Color.Red;
                return;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM  [Paying Guest].[dbo].[Host_Registation] WHERE ([UserName] = @UserName)", con);
            check_User_Name.Parameters.AddWithValue("@UserName", textBox2.Text);
            int UserExist = (int)check_User_Name.ExecuteScalar();
            con.Close();
            if (UserExist > 0)
            {
                errorProvider2.SetError(this.textBox2, " User Name Already Inserted");
                button2.Enabled = false;
                button2.BackColor = Color.Red;

                return;

            }
            else
            {
                errorProvider2.Clear();
                button2.Enabled = true;
                button2.BackColor = Color.White;

            }
           
        }
    }
}
