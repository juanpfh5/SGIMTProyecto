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
        private void addUserControl(UserControl userControl)
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
            addUserControl(menuPrincipalUC);
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
    }
}
