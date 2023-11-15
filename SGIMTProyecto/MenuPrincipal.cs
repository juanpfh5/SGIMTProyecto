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
    public partial class MenuPrincipal : Form
    {
        private Revista formRevista;
        private TarjetaCirculacion formTC;
        private MenuPermisos formMpermisos;
        private MenuOrdenCobro formOrdenCobro;
        private MenuEditar formMenuEditar;
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PNL_MenuPrincipal.Controls.Clear();
            PNL_MenuPrincipal.Controls.Add(userControl);
            userControl.BringToFront();
        }
        public MenuPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//centrar el formulario al crearse
            SDP_MenuPrincipal.Height = BTN_Revista.Height;//alinear el side panel con el boton
            SDP_MenuPrincipal.Top = BTN_Revista.Top;
            MenuPrincipalUC menuPrincipalUC = new MenuPrincipalUC();
            AddUserControl(menuPrincipalUC);
        }

        private void BTN_Revista_Click(object sender, EventArgs e)
        {
            /*
             *  BOTON REVISTA
             */
            if (formRevista == null || formRevista.IsDisposed)
            {
                formRevista = new Revista();
            }
            this.Hide();
            formRevista.ShowDialog();

            this.Show();
        }

        private void BTN_TarjetaCirculacion_Click(object sender, EventArgs e)
        {
            if (formTC == null || formTC.IsDisposed)
            {
                formTC = new TarjetaCirculacion();
            }
            this.Hide();
            formTC.ShowDialog();
            this.Show();
            SDP_MenuPrincipal.Height = BTN_TarjetaCirculacion.Height;
            SDP_MenuPrincipal.Top = BTN_TarjetaCirculacion.Top;
        }

        private void BTN_Permisos_Click(object sender, EventArgs e)
        {
            if (formMpermisos == null || formMpermisos.IsDisposed)
            {
                formMpermisos = new MenuPermisos();
            }
            this.Hide();
            formMpermisos.ShowDialog();
            this.Show();
            SDP_MenuPrincipal.Height = BTN_Permisos.Height;
            SDP_MenuPrincipal.Top = BTN_Permisos.Top;
        }

        private void BTN_OrdenCobro_Click(object sender, EventArgs e)
        {
            if (formOrdenCobro == null || formOrdenCobro.IsDisposed)
            {
                formOrdenCobro = new MenuOrdenCobro();
            }
            this.Hide();
            formOrdenCobro.ShowDialog();
            this.Show();
            SDP_MenuPrincipal.Height = BTN_OrdenCobro.Height;
            SDP_MenuPrincipal.Top = BTN_OrdenCobro.Top;
        }

        private void BTN_LiberacionPublicoPrivado_Click(object sender, EventArgs e)
        {
            SDP_MenuPrincipal.Height = BTN_LiberacionPublicoPrivado.Height;
            SDP_MenuPrincipal.Top = BTN_LiberacionPublicoPrivado.Top;
            AddUserControl(new LiberacionPublicoPrivado());
        }

        private void BTN_Editar_Click(object sender, EventArgs e)
        {
            if (formMenuEditar == null  || formMenuEditar.IsDisposed)
            {
                formMenuEditar = new MenuEditar();
            }
            this.Hide();
            formMenuEditar.ShowDialog();
            this.Show();
            SDP_MenuPrincipal.Height = BTN_Editar.Height;
            SDP_MenuPrincipal.Top = BTN_Editar.Top;
        }
    }
}
