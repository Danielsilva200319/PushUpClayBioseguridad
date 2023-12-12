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
    public class PersonTypeController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonTypeDto>>> Get()
        {
            var personType = await _unitOfWork.PersonTypes.GetAllAsync();
            return _mapper.Map<List<PersonTypeDto>>(personType);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonTypeDto>> Get(int id)
        {
            var personTypes = await _unitOfWork.PersonTypes.GetByIdAsync(id);
            if (personTypes == null)
            {
                return NotFound();
            }
            return _mapper.Map<PersonTypeDto>(personTypes);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonTypeDto>> Post(PersonTypeDto personTypeDto)
        {
            var personType = _mapper.Map<Persontype>(personTypeDto);
            _unitOfWork.PersonTypes.Add(personType);
            await _unitOfWork.SaveAsync();
            if (personType == null)
            {
                return BadRequest();
            }
            personTypeDto.Id = personType.Id;
            return CreatedAtAction(nameof(Post), new {id = personTypeDto.Id}, personTypeDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonTypeDto>> Put(int id, PersonTypeDto personTypeDto)
        {
            if (personTypeDto.Id == 0){
                personTypeDto.Id = id;
            }
            if (personTypeDto.Id != id){
                return BadRequest();
            }
            if (personTypeDto == null){
                return NotFound();
            }
            var personTypes = _mapper.Map<Persontype>(personTypeDto);
            _unitOfWork.PersonTypes.Update(personTypes);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PersonTypeDto>(personTypes);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var personType = await _unitOfWork.PersonTypes.GetByIdAsync(id);
            if (personType == null)
            {
                return NotFound();
            }
            _unitOfWork.PersonTypes.Remove(personType);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}