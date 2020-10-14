using ProjetCSharp.GestionCampagne;
using ProjetCSharp.NEf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCSharp.Service
{
    public class ContactService
    {
        private readonly Context context;
        public ContactService(Context context)
        {
            this.context = context;
        }

        //Récupéré un contacte par son id
        public async Task<Contact> GetContactById(int id)
        {
            return await context.Contact.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// Récupérer un contact par son email
        public async Task<Contact> GetContactByEmail(string mail)
        {
            return await context.Contact.FirstOrDefaultAsync(u => u.Mail == mail);
        }

        /// Récupérer la liste des contact d'une campagne
        public async Task<List<Contact>> ContactListByCampagne(int campagneId)
        {
            return (await context.Contact.Where(c => c.CampagneId == campagneId).ToListAsync());
        }

        /// Ajouter un contact dans une campagne
        public async Task AddEmail(Contact contact)
        {
            context.Contact.Add(contact);
            await context.SaveChangesAsync();
        }


        ///Mettre à jour un contact
        public async Task UpdateContact(string newEmail, string oldEmail)
        {
            var contact = await this.GetContactByEmail(oldEmail);
            contact.Mail = newEmail;
            await context.SaveChangesAsync();
        }


        /// Ajouter une liste de contact dans une campagne
        public async Task AddEmails(Campagne campagne, List<string> emailsList)
        {
            emailsList.ForEach(e =>
            {
                if (!String.IsNullOrEmpty(e))
                {
                    var newContact = new Contact();
                    newContact.Mail = e;
                    newContact.CampagneId = campagne.Id;
                    context.Contact.Add(newContact);
                }
            });
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Supprimer un contact par son email
        /// </summary>
        public async Task DeleteContactByEmail(string mail)
        {
            var contact = await this.GetContactByEmail(mail);
            context.Contact.Remove(contact);
            await context.SaveChangesAsync();
        }

        /// Méthode permettant de supprimer un contact
        public async Task DeleteContact(Contact dContact)
        {
            var contact = await this.GetContactById(dContact.Id);
            context.Contact.Remove(contact);
            await context.SaveChangesAsync();
        }

        /// Méthode permettant de surpprimer les doublons de contact dans une campagne
        public async Task button2_Click(Campagne campagne)
        {
            var contacts = await this.ContactListByCampagne(campagne.Id);

            foreach (var c in contacts)
            {
                var SameEmailList = context.Contact.Where(cc => cc.Mail == c.Mail).ToList();
                if (SameEmailList.Count != 1)
                {
                    await this.DeleteContact(c);
                }
            }
        }
    }
    
}
