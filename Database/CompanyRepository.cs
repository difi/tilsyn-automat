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
            return dbContext.CompanyList.Include(x => x.ContactPersonList).AsNoTracking().ToList();
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

        public async Task<bool> ExcelImport()
        {
            try
            {
                var company1 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Narvesen",
                    CorporateIdentityNumber = "123456789",
                    Code = "1111",
                };

                var company2 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Norwegian",
                    CorporateIdentityNumber = "987654321",
                    Code = "2222"
                };

                var company3 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "NSB",
                    CorporateIdentityNumber = "1122334455",
                    Code = "3333"
                };

                var company4 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Esso",
                    CorporateIdentityNumber = "1122334455",
                    Code = "4444"
                };

                var company5 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "7 - eleven",
                    CorporateIdentityNumber = "1122334455",
                    Code = "5555"
                };

                var company6 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Norske bank",
                    CorporateIdentityNumber = "1122334455",
                    Code = "6666"
                };

                var contactPerson1 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company1.Id
                };
                var contactPerson2 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company2.Id
                };
                var contactPerson3 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company3.Id
                };
                var contactPerson4 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company4.Id
                };
                var contactPerson5 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company5.Id
                };
                var contactPerson6 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company6.Id
                };

                var declarationItem1 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company1.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400269").Id,
                    Name = "Automat for betaling på Oslo S",
                    CreatedDate = DateTime.Today.AddDays(-10),
                    Status = DeclarationStatus.Started
                };

                var declarationItem2 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company2.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400269").Id,
                    Name = "Billettautomat Gardemoen",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    Status = DeclarationStatus.NotStarted
                };

                var declarationItem3 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company3.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400420").Id,
                    Name = "Billettautomat på Oslo S",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    Status = DeclarationStatus.NotChecked
                };


                var declarationItem4 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company4.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400269").Id,
                    Name = "Betalingsautomat Trondheim",
                    CreatedDate = DateTime.Today.AddDays(-3),
                    Status = DeclarationStatus.NotChecked
                };


                var declarationItem5 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company5.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400420").Id,
                    Name = "Automat Grensen",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    Status = DeclarationStatus.MoreInfoNeed
                };


                var declarationItem6 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company6.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400420").Id,
                    Name = "Billettautomat Kristiansand",
                    CreatedDate = DateTime.Today.AddDays(-3),
                    Status = DeclarationStatus.Done
                };

                dbContext.CompanyList.Add(company1);
                dbContext.CompanyList.Add(company2);
                dbContext.CompanyList.Add(company3);
                dbContext.CompanyList.Add(company4);
                dbContext.CompanyList.Add(company5);
                dbContext.CompanyList.Add(company6);

                dbContext.ContactPersonList.Add(contactPerson1);
                dbContext.ContactPersonList.Add(contactPerson2);
                dbContext.ContactPersonList.Add(contactPerson3);
                dbContext.ContactPersonList.Add(contactPerson4);
                dbContext.ContactPersonList.Add(contactPerson5);
                dbContext.ContactPersonList.Add(contactPerson6);

                dbContext.DeclarationList.Add(declarationItem1);
                dbContext.DeclarationList.Add(declarationItem2);
                dbContext.DeclarationList.Add(declarationItem3);
                dbContext.DeclarationList.Add(declarationItem4);
                dbContext.DeclarationList.Add(declarationItem5);
                dbContext.DeclarationList.Add(declarationItem6);

                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}