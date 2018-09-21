using System;
using System.Threading.Tasks;
using Contact.Contracts;
using Contact.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Web.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly PeopleRepository _repository = new PeopleRepository();

        [HttpGet]
        [Route("api/[controller]/Ping")]
        public string Ping()
        {
            return "you have reached the data controller at " + DateTime.Now.ToLongTimeString();
        }

        [HttpGet]
        [Route("api/[controller]/GetPeople")]
        public async Task<GetPeopleResponse> GetPeople()
        {
            var request = new GetPeopleRequest();
            return await _repository.GetPeople(request);
        }

        [HttpGet]
        [Route("api/[controller]/GetPersonById")]
        //api/data/GetPersonById?Id=5FC99CFB-52E6-4ECF-B77A-FE927F325C18
        public async Task<GetPersonByIdResponse> GetPersonById([FromQuery] GetPersonByIdRequest request)
        {
            return await _repository.GetPersonById(request);
        }

        [HttpPost]
        [Route("api/[controller]/SavePerson")]
        //api/data/SavePerson/ + body
        public async Task<SavePersonResponse> SavePerson([FromBody] SavePersonRequest request)
        {
            return await _repository.SavePerson(request);
        }

        [HttpPost]
        [Route("api/[controller]/DeletePersonById")]
        //api/data/DeletePersonById?Id=5FC99CFB-52E6-4ECF-B77A-FE927F325C18
        public async Task<DeletePersonByIdResponse> DeletePersonById([FromQuery] DeletePersonByIdRequest request)
        {
            return await _repository.DeletePersonById(request);
        }

    }
}