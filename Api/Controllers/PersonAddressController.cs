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
    public class PersonAddressController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonAddressController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonAddressDto>>> Get()
        {
            var personAddress = await _unitOfWork.Cities.GetAllAsync();
            return _mapper.Map<List<PersonAddressDto>>(personAddress);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonAddressDto>> Get(int id)
        {
            var personAddresses = await _unitOfWork.PersonAddresses.GetByIdAsync(id);
            if (personAddresses == null)
            {
                return NotFound();
            }
            return _mapper.Map<PersonAddressDto>(personAddresses);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonAddressDto>> Post(PersonAddressDto personAddressDto)
        {
            var personAddress = _mapper.Map<Personaddress>(personAddressDto);
            _unitOfWork.PersonAddresses.Add(personAddress);
            await _unitOfWork.SaveAsync();
            if (personAddress == null)
            {
                return BadRequest();
            }
            personAddressDto.Id = personAddress.Id;
            return CreatedAtAction(nameof(Post), new {id = personAddressDto.Id}, personAddressDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonAddressDto>> Put(int id, PersonAddressDto personAddressDto)
        {
            if (personAddressDto.Id == 0){
                personAddressDto.Id = id;
            }
            if (personAddressDto.Id != id){
                return BadRequest();
            }
            if (personAddressDto == null){
                return NotFound();
            }
            var personAddresses = _mapper.Map<Personaddress>(personAddressDto);
            _unitOfWork.PersonAddresses.Update(personAddresses);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PersonAddressDto>(personAddresses);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var personAddress = await _unitOfWork.PersonAddresses.GetByIdAsync(id);
            if (personAddress == null)
            {
                return NotFound();
            }
            _unitOfWork.PersonAddresses.Remove(personAddress);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}