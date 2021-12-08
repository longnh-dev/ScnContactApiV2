using System.Collections.Generic;
using System.Threading.Tasks;
using ScnContactApiV2.Models;

namespace ScnContactApiV2.Repository
{
    public interface IContactRepository
    {
        Task InsertContact(ContactCreateViewModel contactVm);
        // List<Contact> GetAllContacts(string search);
        Task<IEnumerable<Contact>> GetAllContact();
        Task<Contact> GetContactById(string id);

    }
}