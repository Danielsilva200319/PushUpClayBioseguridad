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
    public class ContactTypeController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactTypeDto>>> Get()
        {
            var contacttype = await _unitOfWork.ContactTypes.GetAllAsync();
            return _mapper.Map<List<ContactTypeDto>>(contacttype);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactTypeDto>> Get(int id)
        {
            var contacttypes = await _unitOfWork.ContactTypes.GetByIdAsync(id);
            if (contacttypes == null)
            {
                return NotFound();
            }
            return _mapper.Map<ContactTypeDto>(contacttypes);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ContactTypeDto>> Post(ContactTypeDto contactTypeDto)
        {
            var contactType = _mapper.Map<Contacttype>(contactTypeDto);
            _unitOfWork.ContactTypes.Add(contactType);
            await _unitOfWork.SaveAsync();
            if (contactType == null)
            {
                return BadRequest();
            }
            contactTypeDto.Id = contactType.Id;
            return CreatedAtAction(nameof(Post), new {id = contactTypeDto.Id}, contactTypeDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ContactTypeDto>> Put(int id, ContactTypeDto contactTypeDto)
        {
            if (contactTypeDto.Id == 0){
                contactTypeDto.Id = id;
            }
            if (contactTypeDto.Id != id){
                return BadRequest();
            }
            if (contactTypeDto == null){
                return NotFound();
            }
            var contactTypes = _mapper.Map<Contacttype>(contactTypeDto);
            _unitOfWork.ContactTypes.Update(contactTypes);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ContactTypeDto>(contactTypes);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var contactType = await _unitOfWork.ContactTypes.GetByIdAsync(id);
            if (contactType == null)
            {
                return NotFound();
            }
            _unitOfWork.ContactTypes.Remove(contactType);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}