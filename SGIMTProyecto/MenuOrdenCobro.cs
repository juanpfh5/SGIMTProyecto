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
    public partial class MenuOrdenCobro : Form
    {
        public MenuOrdenCobro()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            AddUserControl(new OrdenCobro());
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PUC_menuOrdenC.Controls.Clear();
            PUC_menuOrdenC.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void BTN_ordenCobro_Click(object sender, EventArgs e)
        {
            
            AddUserControl(new OrdenCobro());
        }

        private void BTN_ordenCobroD_Click(object sender, EventArgs e)
        {
            
            AddUserControl(new OrdenCobroDiversos());
        }

        private void BTN_inicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
