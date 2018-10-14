using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TestProgrammerSesi2
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Programming\Dekstop Aplication\TestProgrammerSesi2\TestProgrammerSesi2\Akademik.accdb");
        int count = 0;
        int hitung = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into mahasiswa values ('"+txtNim.Text+"', '"+txtNama.Text+"', '"+txtAlamat.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            txtNim.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            MessageBox.Show("Data Berhasil Diinputkan");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from mahasiswa";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from mahasiswa where nim = '"+txtNim.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Berhasil Dihapus");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update mahasiswa set nama = '"+txtNama.Text+"', alamat = '"+txtAlamat.Text+"' where nim = '"+txtNim.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Berhasil DiUpdate");
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            count = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from mahasiswa where nim = '"+txtNim.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView1.DataSource = dt;
            con.Close();
            txtNim.Text = "";

            if (count == 0)
            {
                MessageBox.Show("Data Tidak Ditemukan");
            }
        }

        private void btnCariNama_Click(object sender, EventArgs e)
        {
            count = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from mahasiswa where nama = '" + txtCariNama.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView1.DataSource = dt;
            con.Close();
            txtCariNama.Text = "";

            if (count == 0)
            {
                MessageBox.Show("Data Tidak Ditemukan");
            }
        }
    }
}
