using ProjetCSharp.NEf;
using ProjetCSharp.Service;
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
    public partial class SendMail : Form
    {
        private readonly Context context;
        private readonly ContactService contactService;
        private readonly MailService mailService;
        public GestionCampagne.Campagne currentCampagne;
        public string to;
        public string obj;
        public string msg;
        public bool allCampagne;
        public SendMail(GestionCampagne.Campagne campagneSelected, string emailSelected, string to, string obj, string msg, bool allCampagne)
        {
            this.context = new Context();
            InitializeComponent();
            this.currentCampagne = campagneSelected;
            this.checkBox1.Text = emailSelected;
            this.to = to;
            this.obj = obj;
            this.msg = msg;
            this.allCampagne = allCampagne;
            this.context = new Context();
            this.contactService = new ContactService(this.context);
            this.mailService = new MailService(this.context);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public async void button1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                //On vérifie que les champs ne soit pas vide
                if (!String.IsNullOrEmpty(this.textBox1.Text)
               && !String.IsNullOrEmpty(this.textBox2.Text)
               && !String.IsNullOrEmpty(this.textBox3.Text)
               && !String.IsNullOrEmpty(this.textBox4.Text)
               && !String.IsNullOrEmpty(this.textBox5.Text)
               && !String.IsNullOrEmpty(this.textBox6.Text))
                {
                    var contacts = await this.contactService.ContactListByCampagne(this.currentCampagne.Id);
                    contacts.ForEach(c =>
                    {
                        this.mailService.SendMail(this.textBox4.Text, this.textBox5.Text, c.Mail, this.obj, this.msg, this.textBox5.Text, this.textBox6.Text);
                    });
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(this.textBox1.Text)
                               && !String.IsNullOrEmpty(this.textBox2.Text)
                               && !String.IsNullOrEmpty(this.textBox3.Text)
                               && !String.IsNullOrEmpty(this.textBox4.Text)
                               && !String.IsNullOrEmpty(this.textBox5.Text)
                               && !String.IsNullOrEmpty(this.textBox6.Text))
                {
                    this.mailService.SendMail(this.textBox4.Text, this.textBox5.Text, this.to, this.obj, this.msg, this.textBox5.Text, this.textBox6.Text);

                }
            }
            //On ferme la fenêtre courrante
            this.Hide();
            var nextForm = new Campagne();
            nextForm.Show();
        }

        private void SendMail_Load(object sender, EventArgs e)
        {

        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox1.Text = null;
            //On active ou non le champs selon l'état de la checkbox (true/false)
            this.checkBox1.Enabled = !this.checkBox1.Enabled;
        }
    }
}
