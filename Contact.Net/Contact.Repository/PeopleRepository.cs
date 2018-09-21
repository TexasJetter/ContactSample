using Contact.Contracts;
using Contact.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Repository
{
    //https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/repository-pattern/samples/2.x/RepositoryPatternSample

    public class PeopleRepository : IPeopleRepository
    {
        private readonly ContactSampleContext _dbContext = new ContactSampleContext();

        public async Task<GetPeopleResponse> GetPeople(GetPeopleRequest request)
        {
            const string userMessage = "Unable to get People";
            var response = new GetPeopleResponse();
            try
            {
                var people = await _dbContext.People.OrderBy(p => p.FirstName).ToListAsync();
                response.People = people.Select(p =>
                    new PersonInformation
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Email = p.Email,
                        Photo = p.Photo
                    });

                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                //log the exception..
                //In production we wouldn't return the exception detail
                return new GetPeopleResponse
                {
                    Success = false,
                    FailureInformation = userMessage + " | " + ex.Message
                };
            }
        }

        public async Task<GetPersonByIdResponse> GetPersonById(GetPersonByIdRequest request)
        {
            const string userMessage = "Unable to get Person";
            var response = new GetPersonByIdResponse();
            try
            {
                var p = await _dbContext.People.FindAsync(request.Id);
                if(p == null)
                {
                    response.Success = false;
                    response.FailureInformation = "Unable to find requested person";
                }
                else
                {
                    response.Success = true;
                    response.Person = new PersonInformation
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Email = p.Email,
                        Photo = p.Photo
                    };
                }
                return response;
            }
            catch (Exception ex)
            {
                //log the exception..
                //In production we wouldn't return the exception detail
                return new GetPersonByIdResponse
                {
                    Success = false,
                    FailureInformation = userMessage + " | " + ex.Message
                };
            }
        }

        public async Task<SavePersonResponse> SavePerson(SavePersonRequest request)
        {
            const string userMessage = "Unable to save Person";
            var response = new SavePersonResponse();
            try
            {
                var p = await _dbContext.People.FindAsync(request.Person.Id);
                if (p == null)
                {
                    p = new People { Id = Guid.NewGuid() };
                    _dbContext.People.Add(p);
                }
                else
                {
                    _dbContext.Entry(p).State = EntityState.Modified;
                }
                p.FirstName = request.Person.FirstName;
                p.LastName = request.Person.LastName;
                p.Email = request.Person.Email;
                p.Photo = request.Person.Photo;
                await _dbContext.SaveChangesAsync();
                response.Success = true;
                response.Id = p.Id;
                return response;
            }
            catch (Exception ex)
            {
                //log the exception..
                //In production we wouldn't return the exception detail
                return new SavePersonResponse
                {
                    Success = false,
                    FailureInformation = userMessage + " | " + ex.Message
                };
            }
        }

        public async Task<DeletePersonByIdResponse> DeletePersonById(DeletePersonByIdRequest request)
        {
            const string userMessage = "Unable to delete Person";
            var response = new DeletePersonByIdResponse();
            try
            {
                var p = await _dbContext.People.FindAsync(request.Id);
                if (p == null)
                {
                    response.Success = false;
                    response.FailureInformation = "Unable to find requested person";
                }
                else
                {
                    response.Success = true;
                    _dbContext.People.Remove(p);
                    await _dbContext.SaveChangesAsync();
                }
                return response;
            }
            catch (Exception ex)
            {
                //log the exception..
                //In production we wouldn't return the exception detail
                return new DeletePersonByIdResponse
                {
                    Success = false,
                    FailureInformation = userMessage + " | " + ex.Message
                };
            }
        }
    }
}
