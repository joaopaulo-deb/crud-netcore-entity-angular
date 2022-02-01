using System.Linq;
using Entities;
using Infra.Context;
using Infra.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class LegalPersonInfra : DefaultInfra, ILegalPersonInfra
    {
        private readonly DataContext _context;
        public LegalPersonInfra(DataContext context) : base(context)
        {
            _context = context;
        }

        public LegalPerson[] GetAllLegalPerson()
        {
            IQueryable<LegalPerson> query = _context.LegalPersons.Include(legalPerson => legalPerson.Telephones);

            query = query.AsNoTracking().OrderBy(client => client.FantasyName);

            return query.ToArray();
        }

         public LegalPerson GetLegalPersonById(int LegalPersonId)
        {
            IQueryable<LegalPerson> query = _context.LegalPersons
                .Include(legalPerson => legalPerson.Telephones);

            query = query.AsNoTracking().OrderBy(client => client.FantasyName)
                         .Where(legalPerson => legalPerson.Id == LegalPersonId);

            return query.FirstOrDefault();
        }
    }
}