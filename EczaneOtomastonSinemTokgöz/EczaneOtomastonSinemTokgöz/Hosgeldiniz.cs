using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomastonSinemTokgöz
{
    public partial class Hosgeldiniz : Form
    {
        public Hosgeldiniz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KullaniciBilgiler form1 = new KullaniciBilgiler();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IlacBilgi formilac = new IlacBilgi();
            formilac.Show();
            this.Hide();
        }
    }
}
