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
    public partial class MenuEditar : Form
    {
        public MenuEditar()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            AddUserControl(new EditarVehiculo());
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PNL_Editar.Controls.Clear();
            PNL_Editar.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void BTN_DatosVehiculo_Click(object sender, EventArgs e)
        {
            AddUserControl(new EditarVehiculo());
        }

        private void BTN_Inicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_DatosPropietario_Click(object sender, EventArgs e)
        {
            AddUserControl(new EditarPropietario());
        }
    }
}
