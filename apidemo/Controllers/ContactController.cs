using apidemo.Data.Repository;
using apidemo.DTOs;
using apidemo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace apidemo.Controllers
{
    [Route("api/[controller]")] //[controller] indica que la ruta es /el nombre del controlador. En //
    //este caso, /contact
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactRepository _contactRepository { get; set; }
        public ContactController(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;

        }

        [HttpGet] 
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_contactRepository.GetAllContacts());
        }
        [HttpGet]
        [Route("GetOne/{Id}")]
        public IActionResult GetOneById(int Id)
        {
            return Ok(_contactRepository.GetAllContacts().Where(x => x.Id == Id).ToList());

        }

        [HttpPost]
        public IActionResult CreateContact(CreateAndUpdateContact createContactDto)
        {
            try
            {
                _contactRepository.Create(createContactDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", createContactDto);
        }

        [HttpPut]
        public IActionResult UpdateContact(CreateAndUpdateContact dto)
        {
            try
            {
                _contactRepository.Update(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteContactById(int id)
        {
            try
            {
                _contactRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }




    }
}
