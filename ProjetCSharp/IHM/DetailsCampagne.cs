﻿using ProjetCSharp.NEf;
using ProjetCSharp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetCSharp.IHM
{
    public partial class DetailsCampagne : Form
    {
        private readonly Context context;
        private readonly ContactService contactService;
        public GestionCampagne.Campagne currentCampagne;
        public List<GestionCampagne.Contact> contacts;

        public DetailsCampagne(GestionCampagne.Campagne campagneSelected)
        {
            this.context = new Context();
            this.contactService = new ContactService(this.context);
            InitializeComponent();
            this.currentCampagne = campagneSelected;
            this.NomCampagneNom.Text = this.currentCampagne.NomCampagne;
            this.LoadEmails();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Ajouter des emails
        public async void button1_Click(object sender, EventArgs e)
        {
            var newContact = new GestionCampagne.Contact();
            newContact.Mail = this.inputMail.Text;
            newContact.CampagneId = this.currentCampagne.Id;
            //Appel au service permettant de créer un contact
            await this.contactService.AddEmail(newContact);
            //Le champs de saisie est remit à null
            this.inputMail.Text = null;
            //On charge de nouveau les emails
            this.LoadEmails();
        }
        public async void LoadEmails()
        {
            //On vide la liste des emails de la listBox "listEmailBox"
            this.listBox1.Items.Clear();
            //On réupère les contacts de la campagne en passant l'id de la campagne en paramètre
            this.contacts = await this.contactService.ContactListByCampagne(this.currentCampagne.Id);
            //On boucle sur la liste des contacts précédemment récupéré
            contacts.ForEach(c =>
            {
                //On ajoute l'adresse mail du contact à la liste
                this.listBox1.Items.Add(c.Mail);
            });
        }


        //Supprimer des emails
        public async void button2_Click(object sender, EventArgs e)
        {
            await this.contactService.button2_Click(this.currentCampagne);
            this.LoadEmails();
        }

        //Importer la liste des emails
        public void button3_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(fileDialog.FileName);
                    ReadFile(sr.ReadToEnd());
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        /// Lire le fichier 
        public async void ReadFile(string text)
        {
            var data = text;
            var emailList = data.Split("\r\n");
            await this.contactService.AddEmails(this.currentCampagne, emailList.ToList());
            this.LoadEmails();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Envoyer un email
        private void button4_Click(object sender, EventArgs e)
        {

        }

        public void button4_Click_1(object sender, EventArgs e)
        {
            var index = this.listBox1.SelectedIndex;
            var nextForm = new SendMail(this.currentCampagne);
            if (index != -1)
                nextForm = new SendMail(this.currentCampagne, this.contacts[index].Mail);
            nextForm.Show();
            this.Hide();
        }

        //Modifier l'email
        public async void button5_Click(object sender, EventArgs e)
        {
            await this.contactService.UpdateContact(this.infoContact.Text, this.listBox1.SelectedItem.ToString());
            //On rafraichit la liste des emails
            this.LoadEmails();
            //On met la textBox à null
            this.infoContact.Text = null;


        }

        //Supprimer un email
        public async void button6_Click(object sender, EventArgs e)
        {
            await this.contactService.DeleteContactByEmail(this.listBox1.SelectedItem.ToString());
            this.infoContact.Text = null;
            this.LoadEmails();
        }
    }
}
