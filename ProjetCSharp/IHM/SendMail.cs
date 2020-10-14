using ProjetCSharp.NEf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetCSharp.IHM
{
    public partial class expInput : Form
    {
        private readonly Context context;

        public GestionCampagne.Campagne currentCampagne;
        public expInput(GestionCampagne.Campagne campagneSelected, string emailSelected)
        {
            //Définition du context
            this.context = new Context();
            InitializeComponent();

            this.currentCampagne = campagneSelected;
            this.textBox1.Text = emailSelected;
        }

        public expInput(GestionCampagne.Campagne campagneSelected)
        {
            this.currentCampagne = campagneSelected;
            this.context = new Context();
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                if (!String.IsNullOrEmpty(this.textBox3.Text)
                    && !String.IsNullOrEmpty(this.textBox2.Text))
                {
                    var nextForm = new Settings(this.currentCampagne, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.checkBox1.Checked);
                    nextForm.Show();

                }
            }
            else
            {
                if (!String.IsNullOrEmpty(this.textBox3.Text)
               && !String.IsNullOrEmpty(this.textBox2.Text)
               && !String.IsNullOrEmpty(this.textBox1.Text))
                {
                    var nextForm = new Settings(this.currentCampagne, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.checkBox1.Checked);
                    nextForm.Show();
                }
            }
            this.Hide();
        }
        public void Checkbox_Click(object sender, EventArgs e)
        {
            this.checkBox1.Text = null;
            this.checkBox1.Enabled = !this.checkBox1.Enabled;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

        private void expInput_Load(object sender, EventArgs e)
        {

        }
    }
}
