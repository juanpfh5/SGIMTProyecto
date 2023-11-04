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
            PUC_menuPrincipal.Controls.Clear();
            PUC_menuPrincipal.Controls.Add(userControl);
            userControl.BringToFront();
        }
        public MenuPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//centrar el formulario al crearse
            SDP_menuPrincipal.Height = BTN_revista.Height;//alinear el side panel con el boton
            SDP_menuPrincipal.Top = BTN_revista.Top;
            MenuPrincipalUC menuPrincipalUC = new MenuPrincipalUC();
            AddUserControl(menuPrincipalUC);
        }

        private void BTN_revista_Click(object sender, EventArgs e)
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

        private void BTN_tarjetaCirculacion_Click(object sender, EventArgs e)
        {
            if (formTC == null || formTC.IsDisposed)
            {
                formTC = new TarjetaCirculacion();
            }
            this.Hide();
            formTC.ShowDialog();
            this.Show();
            SDP_menuPrincipal.Height = BTN_tarjetaCirculacion.Height;
            SDP_menuPrincipal.Top = BTN_tarjetaCirculacion.Top;
        }

        private void BTN_permisos_Click(object sender, EventArgs e)
        {
            if (formMpermisos == null || formMpermisos.IsDisposed)
            {
                formMpermisos = new MenuPermisos();
            }
            this.Hide();
            formMpermisos.ShowDialog();
            this.Show();
            SDP_menuPrincipal.Height = BTN_permisos.Height;
            SDP_menuPrincipal.Top = BTN_permisos.Top;
        }

        private void BTN_ordenCobro_Click(object sender, EventArgs e)
        {
            if (formOrdenCobro == null || formOrdenCobro.IsDisposed)
            {
                formOrdenCobro = new MenuOrdenCobro();
            }
            this.Hide();
            formOrdenCobro.ShowDialog();
            this.Show();
            SDP_menuPrincipal.Height = BTN_ordenCobro.Height;
            SDP_menuPrincipal.Top = BTN_ordenCobro.Top;
        }

        private void BTN_liberacion_Click(object sender, EventArgs e)
        {
            SDP_menuPrincipal.Height = BTN_liberacion.Height;
            SDP_menuPrincipal.Top = BTN_liberacion.Top;
            AddUserControl(new LiberacionPublicoPrivado());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (formMenuEditar == null  || formMenuEditar.IsDisposed)
            {
                formMenuEditar = new MenuEditar();
            }
            this.Hide();
            formMenuEditar.ShowDialog();
            this.Show();
            SDP_menuPrincipal.Height = BTN_editar.Height;
            SDP_menuPrincipal.Top = BTN_editar.Top;
        }
    }
}
