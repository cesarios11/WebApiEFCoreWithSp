using EntityFrameworkCore_WithSP_Demo.Data;
using EntityFrameworkCore_WithSP_Demo.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace EntityFrameworkCore_WithSP_Demo.Repositories
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext dbContext;
        public PersonService(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<List<Person>> GetPersonListAsync()
        {
            var personList = await this.dbContext.Person.ToListAsync();
            return personList;
        }

        public async Task<IEnumerable<Person>> GetPersonByIdAsync(int id)
        {
            var person = await this.dbContext.Person.Where(x => x.PersonId == id).ToListAsync();
            return person;
        }

        public async Task<string> AddPersonAsync(Person person)
        {
            string resultMessage = null;

            var resultMessageSQLParam = new SqlParameter("@resultMessage", SqlDbType.VarChar, int.MaxValue) { Direction = ParameterDirection.Output };

            var paratemers = new List<SqlParameter>();
            paratemers.Add(new SqlParameter("@personDNI", person.PersonDNI));
            paratemers.Add(new SqlParameter("@personFirstName", person.PersonFirstName));
            paratemers.Add(new SqlParameter("@personLastName", person.PersonLastName));
            paratemers.Add(new SqlParameter("@personDOB", person.PersonDOB));
            paratemers.Add(new SqlParameter("@isActive", person.IsActive));
            paratemers.Add(resultMessageSQLParam);

            await this.dbContext.Database.ExecuteSqlRawAsync("exec dbo.spCreatePerson @personDNI={0}, @personFirstName={1}, @personLastName={2}, @personDOB={3}, @isActive={4}, @resultMessage={5} out", paratemers.ToArray());

            if (resultMessageSQLParam.Value != DBNull.Value)
            {
                resultMessage = (string)resultMessageSQLParam.Value;              
            }

            return resultMessage;
        }

        public async Task<string> UpdatePersonAsync(Person person)
        {
            string resultMessage = null;

            var resultMessageSQLParam = new SqlParameter("@resultMessage", SqlDbType.VarChar, int.MaxValue) { Direction = ParameterDirection.Output };

            var paratemers = new List<SqlParameter>();
            paratemers.Add(new SqlParameter("@personId", person.PersonId));
            paratemers.Add(new SqlParameter("@personDNI", person.PersonDNI));
            paratemers.Add(new SqlParameter("@personFirstName", person.PersonFirstName));
            paratemers.Add(new SqlParameter("@personLastName", person.PersonLastName));
            paratemers.Add(new SqlParameter("@personDOB", person.PersonDOB));
            paratemers.Add(new SqlParameter("@isActive", person.IsActive));
            paratemers.Add(resultMessageSQLParam);

            await this.dbContext.Database.ExecuteSqlRawAsync("exec dbo.spUpdatePerson @personId={0}, @personDNI={1}, @personFirstName={2}, @personLastName={3}, @personDOB={4}, @isActive={5}, @resultMessage={6} out", paratemers.ToArray());

            if (resultMessageSQLParam.Value != DBNull.Value)
            {
                resultMessage = (string)resultMessageSQLParam.Value;
            }

            return resultMessage;
        }

        public async Task<string> DeletePersonAsync(int id)
        {
            string resultMessage = null;

            var personIdSQLParam = new SqlParameter("@personId", id);
            var resultMessageSQLParam = new SqlParameter("@resultMessage", SqlDbType.VarChar, int.MaxValue) { Direction = ParameterDirection.Output };
            
            await this.dbContext.Database.ExecuteSqlRawAsync("exec dbo.spDeletePerson @personId={0}, @resultMessage={1} out", personIdSQLParam, resultMessageSQLParam);

            if (resultMessageSQLParam.Value != DBNull.Value)
            {
                resultMessage = (string)resultMessageSQLParam.Value;
            }

            return resultMessage;
        }       
    }
}
