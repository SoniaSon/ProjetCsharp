using Microsoft.EntityFrameworkCore;
using ProjetCSharp.GestionCampagne;
using ProjetCSharp.NEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetCSharp.Service
{
    public class CampagneService
    {
        private readonly Context context;

        public CampagneService(Context context)
        {
            this.context = context;
        }

        //Ajouter une campagne 
        public async Task<Campagne> AddCampagne(Campagne newCampagne)
        {
            if (newCampagne == null)
                throw new ArgumentNullException();

            context.Campagne.Add(newCampagne);
            await context.SaveChangesAsync();

            return newCampagne;

        }


        /// la liste des campagnes
        
        public async Task<List<Campagne>> ListeCampagne()
        {
            var campagnes = await context.Campagne.ToListAsync();
            return campagnes;
        }
    }
}
