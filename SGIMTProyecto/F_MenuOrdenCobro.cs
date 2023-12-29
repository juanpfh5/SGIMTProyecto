using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGIMTProyecto
{
    public partial class F_MenuOrdenCobro : Form
    {
        public F_MenuOrdenCobro()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            BTN_OrdenCobro.BackColor = Color.FromArgb(80, 14, 95);
            BTN_OrdenCobroDiversos.BackColor = Color.FromArgb(103, 24, 122);
            this.StartPosition = FormStartPosition.CenterScreen;
            AddUserControl(new F_OrdenCobro());
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PNL_OrdenC.Controls.Clear();
            PNL_OrdenC.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void BTN_OrdenCobro_Click(object sender, EventArgs e)
        {
            BTN_OrdenCobro.BackColor = Color.FromArgb(80, 14, 95);
            BTN_OrdenCobroDiversos.BackColor = Color.FromArgb(103, 24, 122);
            AddUserControl(new F_OrdenCobro());
        }

        private void BTN_OrdenCobroDiversos_Click(object sender, EventArgs e)
        {
            BTN_OrdenCobro.BackColor = Color.FromArgb(103, 24, 122);
            BTN_OrdenCobroDiversos.BackColor = Color.FromArgb(80, 14, 95);
            AddUserControl(new F_OrdenCobroDiversos());
        }

        private void BTN_Inicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
