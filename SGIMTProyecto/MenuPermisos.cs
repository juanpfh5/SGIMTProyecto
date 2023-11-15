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
    public partial class MenuPermisos : Form
    {
        public MenuPermisos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SDP_MenuEditar.Height = BTN_TransporteEscolar.Height;
            SDP_MenuEditar.Top = BTN_TransporteEscolar.Top;
            AddUserControl(new PermisoTransporteE());
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
            SDP_MenuEditar.Height = BTN_TransporteEscolar.Height;
            SDP_MenuEditar.Top = BTN_TransporteEscolar.Top;
            AddUserControl(new PermisoTransporteE());
        }

        private void BTN_PasoAnual_Click(object sender, EventArgs e)
        {
            SDP_MenuEditar.Height = BTN_PasoAnual.Height;
            SDP_MenuEditar.Top = BTN_PasoAnual.Top;
            AddUserControl(new PermisoPasoAnual());
        }

        private void BTN_TransportePersonalEmpresas_Click(object sender, EventArgs e)
        {
            SDP_MenuEditar.Height = BTN_TransportePersonalEmpresas.Height;
            SDP_MenuEditar.Top = BTN_TransportePersonalEmpresas.Top;
            AddUserControl(new PermisoPersonalEmpresas());
        }

        private void BTN_EventualFueraRuta_Click(object sender, EventArgs e)
        {
            SDP_MenuEditar.Height = BTN_EventualFueraRuta.Height;
            SDP_MenuEditar.Top = BTN_EventualFueraRuta.Top;
            AddUserControl(new PermisoCircularFueraRuta());
        }

        private void BTN_Inicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
