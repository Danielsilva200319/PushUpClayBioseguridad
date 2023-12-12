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
    public class PersonCategoryController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonCategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonCategoryDto>>> Get()
        {
            var personCategory = await _unitOfWork.PersonCategories.GetAllAsync();
            return _mapper.Map<List<PersonCategoryDto>>(personCategory);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonCategoryDto>> Get(int id)
        {
            var personCategories = await _unitOfWork.PersonCategories.GetByIdAsync(id);
            if (personCategories == null)
            {
                return NotFound();
            }
            return _mapper.Map<PersonCategoryDto>(personCategories);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonCategoryDto>> Post(PersonCategoryDto personCategoryDto)
        {
            var personCategory = _mapper.Map<Personcategory>(personCategoryDto);
            _unitOfWork.PersonCategories.Add(personCategory);
            await _unitOfWork.SaveAsync();
            if (personCategory == null)
            {
                return BadRequest();
            }
            personCategoryDto.Id = personCategory.Id;
            return CreatedAtAction(nameof(Post), new {id = personCategoryDto.Id}, personCategoryDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonCategoryDto>> Put(int id, PersonCategoryDto personCategoryDto)
        {
            if (personCategoryDto.Id == 0){
                personCategoryDto.Id = id;
            }
            if (personCategoryDto.Id != id){
                return BadRequest();
            }
            if (personCategoryDto == null){
                return NotFound();
            }
            var personCategories = _mapper.Map<Personcategory>(personCategoryDto);
            _unitOfWork.PersonCategories.Update(personCategories);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PersonCategoryDto>(personCategories);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var personCategory = await _unitOfWork.PersonCategories.GetByIdAsync(id);
            if (personCategory == null)
            {
                return NotFound();
            }
            _unitOfWork.PersonCategories.Remove(personCategory);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}