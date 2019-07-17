using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pharmacy
{
    public partial class Pharmacy : Form
    {
        private Login login;
        private DataGridView _dgv;
        private static int _id = 0;
        public int ID { get; set; }
        public string Name { get; set; }

        private List<Medicine> medicines;

        public Pharmacy(Login l)
        {

            login = l;
            l.Hide();
            InitializeComponent();
            _id++;
            ID = _id;
            _dgv = dgvMedicine;
           
            medicines = new List<Medicine>()
            {
                new Medicine{Name="Analgin",Price="15"},
                new Medicine{Name="Baralgin",Price="25"},
                new Medicine{Name="Stramon",Price="12"},
                new Medicine{Name="Nimesil",Price="18"}
            };

            dgvMedicine.DataSource = GetMedicine();
        }


        //method get medicines
        public List<Medicine> GetMedicine()
        {
            return medicines;
        }

        //method add medicines
        public void AddMedicine(Medicine med)
        {
            medicines.Add(med);
        }
        
        //method remove medicines
        public void RemoveMedicine(int id)
        {
            for (int i = 0; i < medicines.Count; i++)
            {
                if (id == medicines[i].ID)
                {
                    medicines.RemoveAt(i);
                    return;
                }
                
            }
           
            
        }

        public Medicine GetMedicineFromCell(int id)
        {
            Medicine result = null;
            for (int i = 0; i < medicines.Count; i++)
            {
                if (id == medicines[i].ID)
                {
                    result = medicines[i];
                }
            }
            return result;
        }

        public void UpdateMedicine(int id,string name,string price)
        {
            Medicine updatemedicine = GetMedicineFromCell(id);
            updatemedicine.Name = name;
            updatemedicine.Price = price;
            
           
        }

        public void RefreshData()
        {
            dgvMedicine.DataSource = null;
            dgvMedicine.DataSource = GetMedicine();

            txtNameMed.Text = null;
            txtPriceMed.Text = null;
        }
        public void CheckDataSource()
        {
            txtNameMed.Text.Trim();
            txtPriceMed.Text.Trim();
            int a = 0;
            if (txtNameMed.Text == "" || !int.TryParse(txtPriceMed.Text, out a))
            {
                MessageBox.Show("Please,enter the name or price !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CheckDataSource();
           
                Medicine medicine = new Medicine
                {
                    Name = txtNameMed.Text,
                    Price = txtPriceMed.Text
                };
                AddMedicine(medicine);
                RefreshData();
        }
        
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete(this,_dgv);
            delete.Show();
        }
        private int Id;
        private void DgvMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Visible = true;
            btnCreate.Visible = false;
            int id = (int)dgvMedicine.Rows[e.RowIndex].Cells[0].Value;
            Id = id;
            Medicine medicine = GetMedicineFromCell(id);
            txtNameMed.Text = medicine.Name;
            txtPriceMed.Text = medicine.Price;

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

            CheckDataSource();

            UpdateMedicine(ID, txtNameMed.Text, txtPriceMed.Text);

            RefreshData();
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnCreate.Visible = true;
        }

        private void Pharmacy_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }
    }
}
