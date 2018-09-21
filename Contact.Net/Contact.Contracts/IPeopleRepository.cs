using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Contracts
{
    public interface IPeopleRepository
    {
        Task<GetPeopleResponse> GetPeople(GetPeopleRequest request);
        Task<GetPersonByIdResponse> GetPersonById(GetPersonByIdRequest request);
        Task<SavePersonResponse> SavePerson(SavePersonRequest request);
        Task<DeletePersonByIdResponse> DeletePersonById(DeletePersonByIdRequest request);

    }
   

}
