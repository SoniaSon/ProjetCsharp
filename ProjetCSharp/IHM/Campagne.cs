using ProjetCSharp.NEf;
using ProjetCSharp.Service;
using ProjetCSharp.GestionCampagne;
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
    public partial class Campagne : Form
    {
        private readonly Context context;
        private readonly CampagneService campagneService;
        public List<GestionCampagne.Campagne> listeCampagne;
        public Campagne()
        {
            this.context = new Context();
            this.campagneService = new CampagneService(this.context);
            InitializeComponent();
            this.Campagne_Load();
        }

        //Ajouter une campagne ( boutton ajouter campagne)
        public async void button1_Click(object sender, EventArgs e)
        {
            var newCampagne = new GestionCampagne.Campagne();
            newCampagne.NomCampagne = this.textBox1.Text;
            await this.campagneService.AddCampagne(newCampagne);
            this.textBox1.Text = null;
            this.Campagne_Load();
        }
        public void OpenIHMCampagne_Click(object sender, EventArgs e)
        {
            this.Hide();
            var index = this.listBox1.SelectedIndex;
            var campagneSelected = this.listeCampagne[index];
            var nextForm = new DetailsCampagne(campagneSelected);
            nextForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Charger toutes les campagnes ajoutées 
        private async void Campagne_Load()
        {
            this.listBox1.Items.Clear();
            this.listeCampagne = await this.campagneService.ListeCampagne();
            listeCampagne.ForEach(c =>
            {
                this.listBox1.Items.Add(c.NomCampagne);
            });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        
    }
}