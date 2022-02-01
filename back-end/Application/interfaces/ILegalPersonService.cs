using Entities;

namespace Application.interfaces
{
    public interface ILegalPersonService
    {
         LegalPerson AddLegalPerson(LegalPerson legalPerson);
         LegalPerson UpdateLegalPerson(int legalPersonId, LegalPerson newLegalPerson);
         bool DeleteLegalPerson(int legalPersonId);
         LegalPerson[] GetAllLegalPersons();
         LegalPerson GetLegalPersonById(int legalPersonId);
    }
}