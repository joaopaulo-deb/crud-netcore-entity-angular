using Entities;

namespace Infra.interfaces
{
    public interface ILegalPersonInfra : IDefaultInfra
    {
         LegalPerson[] GetAllLegalPerson(); 
         LegalPerson GetLegalPersonById(int clientId);
    }
}