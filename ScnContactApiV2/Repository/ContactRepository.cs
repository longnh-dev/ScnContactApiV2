using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ScnContactApiV2.Models;

namespace ScnContactApiV2.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly MongoDbContext _context;
        
        public ContactRepository(IOptions<Settings> settings)
        {
            _context = new MongoDbContext(settings);
        }
        public async Task InsertContact(ContactCreateViewModel contactVm)
        {
            try
            {
                var contact = new Contact()
                {
                    Name =  contactVm.Name,
                    Email = contactVm.Email,
                    Phone = contactVm.Phone,
                    Opinion = contactVm.Opinion,
                    DateCreated = DateTime.Now
                };
                
                await _context.Contacts.InsertOneAsync(contact);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<IEnumerable<Contact>> GetAllContact()
        {
            return await _context.Contacts.Find(_ => true).ToListAsync();
            
        }
        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
        public async Task<Contact> GetContactById(string id)
        {
            ObjectId Id = GetInternalId(id);
            return await _context.Contacts
                .Find(contact => contact.Id == Id)
                .FirstOrDefaultAsync();
        }

    }
}