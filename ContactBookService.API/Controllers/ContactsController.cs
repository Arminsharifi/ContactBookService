using ContactBookService.API.Data_Transfer_Objects;
using ContactBookService.API.Models;
using ContactBookService.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository _contactRepository)
        {
            this._contactRepository = _contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new JsonResult(_contactRepository.GetAll().Select(x => new ContactDTO(x.Id, x.FullName, x.PhoneNumber)).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Contact contact = _contactRepository.Get(id);
            if (contact == null) return NotFound();
            else
            {
                return new JsonResult(new ContactDTO(contact.Id, contact.FullName, contact.PhoneNumber));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactDTO contact)
        {
            if (_contactRepository.Add(new Contact(contact.FullName, contact.PhoneNumber)))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ContactDTO contact)
        {
            if (_contactRepository.Update(new Contact(contact.Id, contact.FullName, contact.PhoneNumber)))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_contactRepository.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}