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
    public class CityController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CityDto>>> Get()
        {
            var city = await _unitOfWork.Cities.GetAllAsync();
            return _mapper.Map<List<CityDto>>(city);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityDto>> Get(int id)
        {
            var cities = await _unitOfWork.Cities.GetByIdAsync(id);
            if (cities == null)
            {
                return NotFound();
            }
            return _mapper.Map<CityDto>(cities);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<CityDto>> Post(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            _unitOfWork.Cities.Add(city);
            await _unitOfWork.SaveAsync();
            if (city == null)
            {
                return BadRequest();
            }
            cityDto.Id = city.Id;
            return CreatedAtAction(nameof(Post), new {id = cityDto.Id}, cityDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CityDto>> Put(int id, CityDto CityDto)
        {
            if (CityDto.Id == 0){
                CityDto.Id = id;
            }
            if (CityDto.Id != id){
                return BadRequest();
            }
            if (CityDto == null){
                return NotFound();
            }
            var cities = _mapper.Map<City>(CityDto);
            _unitOfWork.Cities.Update(cities);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<CityDto>(cities);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            _unitOfWork.Cities.Remove(city);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}