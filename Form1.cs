using ABC.ModelBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC
{
    public partial class Form1 : Form
    {
        ModelBD.Model1 connect = new ModelBD.Model1();
        private object entity1SetTableAdapter;
        private object masterDataSet;

        public Form1()
        {
            InitializeComponent();
            connect.Client.Load();
            dataGridView1.DataSource = connect.Client.Local.ToBindingList();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)

            {
                Client clientadd = new Client();
                clientadd.FirstName = form.textBox1.Text;
                clientadd.LastName = form.textBox2.Text;
                clientadd.Phone = form.textBox3.Text;
                clientadd.GenderCode = form.comboBox1.Text;

                connect.Client.Add(clientadd);
                connect.SaveChanges();
                MessageBox.Show("Все готово");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)

            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == true) ;
                {
                    Client Clientdel = connect.Client.Find(id);
                    connect.Client.Remove(Clientdel);
                    connect.SaveChanges();
                    string buff = Clientdel.FirstName;
                    MessageBox.Show("Запись " + buff + "удален");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 formedit = new Form2();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = index;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                Client clientedit = connect.Client.Find(id);

                formedit.textBox1.Text = clientedit.FirstName;
                formedit.textBox2.Text = clientedit.LastName;
                formedit.textBox3.Text = clientedit.Phone;
                formedit.comboBox1.Text = clientedit.GenderCode;

                DialogResult resultedit = formedit.ShowDialog(this);
                if (resultedit == DialogResult.OK)
                {
                    clientedit.FirstName = formedit.textBox1.Text;
                    clientedit.LastName = formedit.textBox2.Text;
                    clientedit.Phone = formedit.textBox3.Text;
                    clientedit.GenderCode = formedit.comboBox1.SelectedItem.ToString();

                    connect.SaveChanges();
                    dataGridView1.Refresh();
                    MessageBox.Show("ОБЪЕКТ ОБНОВЛЕН");
                }
            }

        }
    }
}

    

