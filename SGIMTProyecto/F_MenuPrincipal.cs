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
    public partial class F_MenuPrincipal : Form
    {
        private F_Revista formRevista;
        private F_TarjetaCirculacion formTC;
        private F_MenuPermisos formMpermisos;
        private F_MenuOrdenCobro formOrdenCobro;
        private F_MenuEditar formMenuEditar;
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PNL_MenuPrincipal.Controls.Clear();
            PNL_MenuPrincipal.Controls.Add(userControl);
            userControl.BringToFront();
        }
        public F_MenuPrincipal()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;//centrar el formulario al crearse
            BTN_Revista.BackColor = Color.FromArgb(135, 20, 62);
            BTN_TarjetaCirculacion.BackColor = Color.FromArgb(135, 20, 62);
            BTN_Permisos.BackColor = Color.FromArgb(135, 20, 62);
            BTN_OrdenCobro.BackColor = Color.FromArgb(135, 20, 62);
            BTN_LiberacionPublicoPrivado.BackColor = Color.FromArgb(135, 20, 62);
            F_MenuPrincipalUC menuPrincipalUC = new F_MenuPrincipalUC();
            AddUserControl(menuPrincipalUC);
        }

        private void BTN_Revista_Click(object sender, EventArgs e)
        {
            /*
             *  BOTON REVISTA
             */
            if (formRevista == null || formRevista.IsDisposed)
            {
                formRevista = new F_Revista();
            }
            this.Hide();
            formRevista.ShowDialog();
            BTN_Revista.BackColor = Color.FromArgb(106, 16, 49);
            BTN_TarjetaCirculacion.BackColor = Color.FromArgb(135, 20, 62);
            BTN_Permisos.BackColor = Color.FromArgb(135, 20, 62);
            BTN_OrdenCobro.BackColor = Color.FromArgb(135, 20, 62);
            BTN_LiberacionPublicoPrivado.BackColor = Color.FromArgb(135, 20, 62);
            this.Show();
            AddUserControl(new F_MenuPrincipalUC());
        }

        private void BTN_TarjetaCirculacion_Click(object sender, EventArgs e)
        {
            if (formTC == null || formTC.IsDisposed)
            {
                formTC = new F_TarjetaCirculacion();
            }
            this.Hide();
            formTC.ShowDialog();
            this.Show();
            BTN_Revista.BackColor = Color.FromArgb(135, 20, 62);
            BTN_TarjetaCirculacion.BackColor = Color.FromArgb(106, 16, 49);
            BTN_Permisos.BackColor = Color.FromArgb(135, 20, 62);
            BTN_OrdenCobro.BackColor = Color.FromArgb(135, 20, 62);
            BTN_LiberacionPublicoPrivado.BackColor = Color.FromArgb(135, 20, 62);
            AddUserControl(new F_MenuPrincipalUC());
        }

        private void BTN_Permisos_Click(object sender, EventArgs e)
        {
            if (formMpermisos == null || formMpermisos.IsDisposed)
            {
                formMpermisos = new F_MenuPermisos();
            }
            this.Hide();
            formMpermisos.ShowDialog();
            this.Show();
            BTN_Revista.BackColor = Color.FromArgb(135, 20, 62);
            BTN_TarjetaCirculacion.BackColor = Color.FromArgb(135, 20, 62);
            BTN_Permisos.BackColor = Color.FromArgb(106, 16, 49);
            BTN_OrdenCobro.BackColor = Color.FromArgb(135, 20, 62);
            BTN_LiberacionPublicoPrivado.BackColor = Color.FromArgb(135, 20, 62);
            AddUserControl(new F_MenuPrincipalUC());
        }

        private void BTN_OrdenCobro_Click(object sender, EventArgs e)
        {
            if (formOrdenCobro == null || formOrdenCobro.IsDisposed)
            {
                formOrdenCobro = new F_MenuOrdenCobro();
            }
            this.Hide();
            formOrdenCobro.ShowDialog();
            this.Show();
            BTN_Revista.BackColor = Color.FromArgb(135, 20, 62);
            BTN_TarjetaCirculacion.BackColor = Color.FromArgb(135, 20, 62);
            BTN_Permisos.BackColor = Color.FromArgb(135, 20, 62);
            BTN_OrdenCobro.BackColor = Color.FromArgb(106, 16, 49);
            BTN_LiberacionPublicoPrivado.BackColor = Color.FromArgb(135, 20, 62);
            AddUserControl(new F_MenuPrincipalUC());
        }

        private void BTN_LiberacionPublicoPrivado_Click(object sender, EventArgs e)
        {
            BTN_Revista.BackColor = Color.FromArgb(135, 20, 62);
            BTN_TarjetaCirculacion.BackColor = Color.FromArgb(135, 20, 62);
            BTN_Permisos.BackColor = Color.FromArgb(135, 20, 62);
            BTN_OrdenCobro.BackColor = Color.FromArgb(135, 20, 62);
            BTN_LiberacionPublicoPrivado.BackColor = Color.FromArgb(106, 16, 49);
            AddUserControl(new F_LiberacionPublicoPrivado());
        }

        private void BTN_Editar_Click(object sender, EventArgs e)
        {
            if (formMenuEditar == null  || formMenuEditar.IsDisposed)
            {
                formMenuEditar = new F_MenuEditar();
            }
            this.Hide();
            formMenuEditar.ShowDialog();
            this.Show();
            
        }
    }
}
