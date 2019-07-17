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
    public partial class Delete : Form
    {
        private DataGridView _dgv;
        private Pharmacy _pharmacy;
        public Delete(Pharmacy pharmacy,DataGridView d)
        {
            InitializeComponent();
            _dgv = d;
            _pharmacy = pharmacy;
            cmbDelete.DataSource = _pharmacy.GetMedicine();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(cmbDelete.SelectedValue.ToString().Substring(0, 2).Trim());
                _pharmacy.RemoveMedicine(id);

                cmbDelete.DataSource = null;
                cmbDelete.DataSource = _pharmacy.GetMedicine();

                _dgv.DataSource = null;
                _dgv.DataSource = _pharmacy.GetMedicine();
            
        }
    }
}
