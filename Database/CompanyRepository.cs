using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Enhetsregisteret;
using Difi.Sjalvdeklaration.Shared.Interface;
using Newtonsoft.Json;

namespace Difi.Sjalvdeklaration.Database
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CompanyItem Get(string corporateIdentityNumber)
        {
            return dbContext.CompanyList.SingleOrDefault(x => x.CorporateIdentityNumber == corporateIdentityNumber);
        }

        public IEnumerable<CompanyItem> GetAll()
        {
            return dbContext.CompanyList.Include(x=>x.ContactPersonList).AsNoTracking().ToList();
        }

        public async Task<bool> Add(CompanyItem companyItem)
        {
            if (Get(companyItem.CorporateIdentityNumber) != null)
            {
                return false;
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var responseMessage = await httpClient.GetStringAsync("https://data.brreg.no/enhetsregisteret/enhet/" + companyItem.CorporateIdentityNumber + ".json");

                    var responseData = responseMessage;
                    var deserializeObject = JsonConvert.DeserializeObject<EnhetsregisteretRootObject>(responseData);

                    companyItem.Name = deserializeObject.navn;
                }

                dbContext.CompanyList.Add(companyItem);
                dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Remove(Guid id)
        {
            var dbItem = dbContext.CompanyList.SingleOrDefault(x => x.Id == id);

            if (dbItem == null)
            {
                throw new InvalidOperationException();
            }

            dbContext.CompanyList.Remove(dbItem);

            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}