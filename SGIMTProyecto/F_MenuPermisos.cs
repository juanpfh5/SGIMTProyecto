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
    public partial class F_MenuPermisos : Form
    {
        public F_MenuPermisos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            BTN_TransporteEscolar.BackColor = Color.FromArgb(80, 14, 95);
            BTN_PasoAnual.BackColor = Color.FromArgb(103, 24, 122);
            BTN_TransportePersonalEmpresas.BackColor = Color.FromArgb(103, 24, 122);
            BTN_EventualFueraRuta.BackColor = Color.FromArgb(103, 24, 122);
            AddUserControl(new F_PermisoTransporteE());
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PNL_Editar.Controls.Clear();
            PNL_Editar.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void BTN_TransporteEscolar_Click(object sender, EventArgs e)
        {
            BTN_TransporteEscolar.BackColor = Color.FromArgb(80, 14, 95);
            BTN_PasoAnual.BackColor = Color.FromArgb(103, 24, 122);
            BTN_TransportePersonalEmpresas.BackColor = Color.FromArgb(103, 24, 122);
            BTN_EventualFueraRuta.BackColor = Color.FromArgb(103, 24, 122);
            AddUserControl(new F_PermisoTransporteE());
        }

        private void BTN_PasoAnual_Click(object sender, EventArgs e)
        {
            BTN_TransporteEscolar.BackColor = Color.FromArgb(103, 24, 122);
            BTN_PasoAnual.BackColor = Color.FromArgb(80, 14, 95);
            BTN_TransportePersonalEmpresas.BackColor = Color.FromArgb(103, 24, 122);
            BTN_EventualFueraRuta.BackColor = Color.FromArgb(103, 24, 122);
            AddUserControl(new F_PermisoPasoAnual());
        }

        private void BTN_TransportePersonalEmpresas_Click(object sender, EventArgs e)
        {
            BTN_TransporteEscolar.BackColor = Color.FromArgb(103, 24, 122);
            BTN_PasoAnual.BackColor = Color.FromArgb(103, 24, 122);
            BTN_TransportePersonalEmpresas.BackColor = Color.FromArgb(80, 14, 95);
            BTN_EventualFueraRuta.BackColor = Color.FromArgb(103, 24, 122);
            AddUserControl(new F_PermisoPersonalEmpresas());
        }

        private void BTN_EventualFueraRuta_Click(object sender, EventArgs e)
        {
            BTN_TransporteEscolar.BackColor = Color.FromArgb(103, 24, 122);
            BTN_PasoAnual.BackColor = Color.FromArgb(103, 24, 122);
            BTN_TransportePersonalEmpresas.BackColor = Color.FromArgb(103, 24, 122);
            BTN_EventualFueraRuta.BackColor = Color.FromArgb(80, 14, 95);
            AddUserControl(new F_PermisoCircularFueraRuta());
        }

        private void BTN_Inicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
