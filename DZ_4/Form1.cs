using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DZ_4
{
    public partial class Form1 : Form 
    {
        public int count = 0;
        DataTable Persons;
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {

            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            using (DataBase db = new DataBase())
            {
                Persons = db.ExecuteSql($"select * from Persons where UserLogin = '{login}' and UserPassword = '{password}'");

                var data = Persons.Rows[0].ItemArray;
                if (Persons.Rows.Count > 0)
                {
                    FormAdmin fa = new FormAdmin();
                    if (data[6].ToString() == "1")
                    {
                        
                        fa.BackColor = Color.Red;
                        
                        //this.OpenNewForm(new FormAdmin(), true);
                    }
                    else
                    {
                        fa.BackColor = Color.Green;
                    }
                    fa.Show();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
        }

        private void FormAdmin(FormAdmin formAdmin, bool v)
        {
            formAdmin.Show();
            //this.OpenNewForm(new FormAdmin(), true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
    }

