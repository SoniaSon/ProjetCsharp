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
    public partial class Settings : Form
    {
        private readonly Context context;
        private readonly ContactService contactService;
        private readonly MailService mailService;
        public GestionCampagne.Campagne currentCampagne;
        public string to;
        public string obj;
        public string msg;
        public bool allCampagne;
        public Settings(GestionCampagne.Campagne currentCampagne, string to, string obj, string msg, bool allCampagne)
        {
            this.currentCampagne = currentCampagne;
            this.to = to;
            this.obj = obj;
            this.msg = msg;
            this.allCampagne = allCampagne;
            this.context = new Context();
            this.contactService = new ContactService(this.context);
            this.mailService = new MailService(this.context);
            InitializeComponent();
        }


        public async void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textBox1.Text)
                && !String.IsNullOrEmpty(this.textBox2.Text)
                && !String.IsNullOrEmpty(this.textBox3.Text))
            {
                if (this.allCampagne)
                {
                    var contacts = await this.contactService.ContactListByCampagne(this.currentCampagne.Id);
                    contacts.ForEach(c =>
                    {
                        this.mailService.SendMail(this.textBox1.Text, this.textBox2.Text, c.Mail, this.obj, this.msg, this.textBox2.Text, this.textBox3.Text);
                    });
                }
                else
                {
                    this.mailService.SendMail(this.textBox1.Text, this.textBox2.Text, this.to, this.obj, this.msg, this.textBox2.Text, this.textBox3.Text);
                }

                this.Hide();
                var nextForm = new Campagne();
                nextForm.Show();
            }
        }
    }
}
