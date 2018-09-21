using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Contracts
{
    public class GetPeopleRequest : BaseRequest
    {

    }
    public class GetPeopleResponse : BaseResponse
    {
        public IEnumerable<PersonInformation> People { get; set; }
    }

    public class GetPersonByIdRequest : BaseRequest
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
    public class GetPersonByIdResponse : BaseResponse
    {
        public PersonInformation Person { get; set; } = new PersonInformation();
    }

    public class SavePersonRequest : BaseRequest
    {
        public PersonInformation Person { get; set; } = new PersonInformation();
    }
    public class SavePersonResponse : BaseResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
    }

    public class DeletePersonByIdRequest : BaseRequest
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
    public class DeletePersonByIdResponse : BaseResponse
    {
    }

    public class PersonInformation
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] Photo { get; set; } = null;
    }
}
