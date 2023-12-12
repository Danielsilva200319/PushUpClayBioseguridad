using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class PersonContactController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonContactController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonContactDto>>> Get()
        {
            var personContact = await _unitOfWork.PersonContacts.GetAllAsync();
            return _mapper.Map<List<PersonContactDto>>(personContact);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonContactDto>> Get(int id)
        {
            var personContacts = await _unitOfWork.PersonContacts.GetByIdAsync(id);
            if (personContacts == null)
            {
                return NotFound();
            }
            return _mapper.Map<PersonContactDto>(personContacts);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonContactDto>> Post(PersonContactDto personContactDto)
        {
            var personContact = _mapper.Map<Personcontact>(personContactDto);
            _unitOfWork.PersonContacts.Add(personContact);
            await _unitOfWork.SaveAsync();
            if (personContact == null)
            {
                return BadRequest();
            }
            personContactDto.Id = personContact.Id;
            return CreatedAtAction(nameof(Post), new {id = personContactDto.Id}, personContactDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonContactDto>> Put(int id, PersonContactDto personContactDto)
        {
            if (personContactDto.Id == 0){
                personContactDto.Id = id;
            }
            if (personContactDto.Id != id){
                return BadRequest();
            }
            if (personContactDto == null){
                return NotFound();
            }
            var personContacts = _mapper.Map<Personcontact>(personContactDto);
            _unitOfWork.PersonContacts.Update(personContacts);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PersonContactDto>(personContacts);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var personContact = await _unitOfWork.PersonContacts.GetByIdAsync(id);
            if (personContact == null)
            {
                return NotFound();
            }
            _unitOfWork.PersonContacts.Remove(personContact);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}