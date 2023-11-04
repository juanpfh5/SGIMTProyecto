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
            SDP_menuEditar.Height = BTN_transporteE.Height;
            SDP_menuEditar.Top = BTN_transporteE.Top;
            AddUserControl(new PermisoTransporteE());
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PUC_menuEditar.Controls.Clear();
            PUC_menuEditar.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void BTN_transporteE_Click(object sender, EventArgs e)
        {
            SDP_menuEditar.Height = BTN_transporteE.Height;
            SDP_menuEditar.Top = BTN_transporteE.Top;
            AddUserControl(new PermisoTransporteE());
        }

        private void BTN_pasoAnual_Click(object sender, EventArgs e)
        {
            SDP_menuEditar.Height = BTN_pasoAnual.Height;
            SDP_menuEditar.Top = BTN_pasoAnual.Top;
            AddUserControl(new PermisoPasoAnual());
        }

        private void BTN_transportePE_Click(object sender, EventArgs e)
        {
            SDP_menuEditar.Height = BTN_transportePE.Height;
            SDP_menuEditar.Top = BTN_transportePE.Top;
            AddUserControl(new PermisoPersonalEmpresas());
        }

        private void BTN_eventualFR_Click(object sender, EventArgs e)
        {
            SDP_menuEditar.Height = BTN_eventualFR.Height;
            SDP_menuEditar.Top = BTN_eventualFR.Top;
            AddUserControl(new PermisoCircularFueraRuta());
        }

        private void BTN_inicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
