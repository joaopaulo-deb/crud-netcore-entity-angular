using System;
using Application.interfaces;
using Entities;
using Infra.interfaces;

namespace Application
{
    public class LegalPersonService : ILegalPersonService
    {
        private readonly IDefaultInfra _defaultInfra;
        private readonly ILegalPersonInfra _LegalPersonInfra;
        //private readonly IMapper _mapper;

        public LegalPersonService(IDefaultInfra DefaultInfra,
                            ILegalPersonInfra LegalPersonInfra)
        {
            _defaultInfra = DefaultInfra;
            _LegalPersonInfra = LegalPersonInfra;
        }

        public LegalPerson AddLegalPerson(LegalPerson model)
        {
            try
            {               
                _defaultInfra.Add<LegalPerson>(model);

                if (_defaultInfra.SaveChanges())
                {
                    var result = _LegalPersonInfra.GetLegalPersonById(model.Id);

                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LegalPerson UpdateLegalPerson(int legalPersonId, LegalPerson model)
        {
            try
            {               
                var legalPerson = _LegalPersonInfra.GetLegalPersonById(legalPersonId);
                if(legalPerson == null) return null;

                model.Id = legalPerson.Id;

                _defaultInfra.Update(model);

                if (_defaultInfra.SaveChanges())
                {
                    return _LegalPersonInfra.GetLegalPersonById(model.Id);

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteLegalPerson(int legalPersonId)
        {
           try
            {               
                var legalPerson = _LegalPersonInfra.GetLegalPersonById(legalPersonId);
                if(legalPerson == null) throw new Exception("Error delete");


                _defaultInfra.Delete<LegalPerson>(legalPerson);

                return (_defaultInfra.SaveChanges());
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LegalPerson[] GetAllLegalPersons()
        {
            try
            {
                var LegalPersons = _LegalPersonInfra.GetAllLegalPerson();
                if (LegalPersons == null) return null;

                return LegalPersons;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LegalPerson GetLegalPersonById(int LegalPersonId)
        {
           try
            {
                var LegalPersons = _LegalPersonInfra.GetLegalPersonById(LegalPersonId);
                if (LegalPersons == null) return null;

                return LegalPersons;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}