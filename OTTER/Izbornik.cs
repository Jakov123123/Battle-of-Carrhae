using System;
using System.Windows.Forms;

namespace OTTER
{
    public partial class Izbornik : Form
    {
        public Izbornik()
        {
            InitializeComponent();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            BGL igra = new BGL();
            igra.ShowDialog();
        }

        private void btnIzadi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
