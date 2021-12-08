using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScnContactApiV2.Models;
using ScnContactApiV2.Repository;

namespace ScnContactApiV2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetContactById(string contactId)
        {
            return Ok(await _repository.GetContactById(contactId));
        }
        
        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _repository.GetAllContact();
        }
        
        [HttpPost]
        public async Task<IActionResult> InsertContact([FromBody]ContactCreateViewModel contactVm)
        {
            if (contactVm == null)
                return BadRequest();

            await _repository.InsertContact(contactVm);
            return Ok(contactVm);
        }
    }
}