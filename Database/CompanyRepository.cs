using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Enhetsregisteret;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Database
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CompanyItem Get(Guid id)
        {
            return dbContext.CompanyList.Include(x => x.ContactPersonList).Include(x => x.UserList).SingleOrDefault(x => x.Id == id);
        }

        public CompanyItem GetByCorporateIdentityNumber(string corporateIdentityNumber)
        {
            return dbContext.CompanyList.Include(x => x.ContactPersonList).Include(x => x.UserList).SingleOrDefault(x => x.CorporateIdentityNumber == corporateIdentityNumber);
        }

        public IEnumerable<CompanyItem> GetAll()
        {
            return dbContext.CompanyList.Include(x => x.ContactPersonList).AsNoTracking().ToList();
        }

        public async Task<bool> Add(CompanyItem companyItem)
        {
            if (GetByCorporateIdentityNumber(companyItem.CorporateIdentityNumber) != null)
            {
                return false;
            }

            try
            {
                dbContext.CompanyList.Add(companyItem);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(CompanyItem companyItem)
        {
            try
            {
                var dbItem = Get(companyItem.Id);

                dbItem.Code = companyItem.Code;
                dbItem.Name = companyItem.Name;
                dbItem.CustomName = companyItem.CustomName;
                dbItem.AddressStreet = companyItem.AddressStreet;
                dbItem.AddressZip = companyItem.AddressZip;
                dbItem.AddressCity = companyItem.AddressCity;

                dbContext.ContactPersonList.RemoveRange(dbContext.ContactPersonList.Where(x => x.CompanyItemId == dbItem.Id));

                if (companyItem.ContactPersonList != null && companyItem.ContactPersonList.Any())
                {
                    foreach (var contactPersonItem in companyItem.ContactPersonList)
                    {
                        dbContext.ContactPersonList.Add(new ContactPersonItem {Name = contactPersonItem.Name, Email = contactPersonItem.Email, Phone = contactPersonItem.Phone, CompanyItemId = dbItem.Id});
                    }
                }

                dbContext.CompanyList.Update(dbItem);

                await dbContext.SaveChangesAsync();

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
                    AddressStreet = "Triangelbygget 12",
                    AddressZip = "4200",
                    AddressCity = "SAUDA"
                };

                var company2 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Norwegian",
                    CorporateIdentityNumber = "987654321",
                    Code = "2222",
                    AddressStreet = "Triangelbygget 12",
                    AddressZip = "4200",
                    AddressCity = "SAUDA"
                };

                var company3 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "NSB",
                    CorporateIdentityNumber = "1122334455",
                    Code = "3333",
                    AddressStreet = "Triangelbygget 12",
                    AddressZip = "4200",
                    AddressCity = "SAUDA"
                };

                var company4 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Esso",
                    CorporateIdentityNumber = "1122334455",
                    Code = "4444",
                    AddressStreet = "Triangelbygget 12",
                    AddressZip = "4200",
                    AddressCity = "SAUDA"
                };

                var company5 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "7 - eleven",
                    CorporateIdentityNumber = "1122334455",
                    Code = "5555",
                    AddressStreet = "Triangelbygget 12",
                    AddressZip = "4200",
                    AddressCity = "SAUDA"
                };

                var company6 = new CompanyItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Norske bank",
                    CorporateIdentityNumber = "1122334455",
                    Code = "6666",
                    AddressStreet = "Triangelbygget 12",
                    AddressZip = "4200",
                    AddressCity = "SAUDA"
                };

                var contactPerson1 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "0706017546",
                    CompanyItemId = company1.Id
                };
                var contactPerson2 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "0706017546",
                    CompanyItemId = company2.Id
                };
                var contactPerson3 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "0706017546",
                    CompanyItemId = company3.Id
                };
                var contactPerson4 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "0706017546",
                    CompanyItemId = company4.Id
                };
                var contactPerson5 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "0706017546",
                    CompanyItemId = company5.Id
                };
                var contactPerson6 = new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "0706017546",
                    CompanyItemId = company6.Id
                };

                var declarationItem1 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company1.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400269").Id,
                    Name = "Automat for betaling på Oslo S",
                    CreatedDate = DateTime.Now,
                    Status = DeclarationStatus.Started
                };

                var declarationItem2 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company2.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400269").Id,
                    Name = "Billettautomat Gardemoen",
                    CreatedDate = DateTime.Now,
                    Status = DeclarationStatus.NotStarted
                };

                var declarationItem3 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company3.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400420").Id,
                    Name = "Billettautomat på Oslo S",
                    CreatedDate = DateTime.Now,
                    Status = DeclarationStatus.NotChecked
                };

                var declarationItem4 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company4.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400269").Id,
                    Name = "Betalingsautomat Trondheim",
                    CreatedDate = DateTime.Now,
                    Status = DeclarationStatus.NotChecked
                };

                var declarationItem5 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company5.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400420").Id,
                    Name = "Automat Grensen",
                    CreatedDate = DateTime.Now,
                    Status = DeclarationStatus.MoreInfoNeed
                };

                var declarationItem6 = new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company6.Id,
                    UserItemId = dbContext.UserList.Single(x => x.SocialSecurityNumber == "12089400420").Id,
                    Name = "Billettautomat Kristiansand",
                    CreatedDate = DateTime.Now,
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

        public async Task<bool> AddLink(UserCompany userCompanyItem)
        {
            try
            {
                dbContext.UserCompanyList.Add(userCompanyItem);
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