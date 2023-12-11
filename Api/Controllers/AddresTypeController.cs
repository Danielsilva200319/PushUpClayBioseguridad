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
    public class AddresTypeController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddresTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AddressTypeDto>>> Get()
        {
            var addresstype = await _unitOfWork.AddressTypes.GetAllAsync();
            return _mapper.Map<List<AddressTypeDto>>(addresstype);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressTypeDto>> Get(int id)
        {
            var addresstypes = await _unitOfWork.AddressTypes.GetByIdAsync(id);
            if (addresstypes == null)
            {
                return NotFound();
            }
            return _mapper.Map<AddressTypeDto>(addresstypes);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<AddressTypeDto>> Post(AddressTypeDto addressTypeDto)
        {
            var addresstype = _mapper.Map<Addresstype>(addressTypeDto);
            _unitOfWork.AddressTypes.Add(addresstype);
            await _unitOfWork.SaveAsync();
            if (addresstype == null)
            {
                return BadRequest();
            }
            addressTypeDto.Id = addresstype.Id;
            return CreatedAtAction(nameof(Post), new {id = addressTypeDto.Id}, addressTypeDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AddressTypeDto>> Put(int id, AddressTypeDto addressTypeDto)
        {
            if (addressTypeDto.Id == 0){
                addressTypeDto.Id = id;
            }
            if (addressTypeDto.Id != id){
                return BadRequest();
            }
            if (addressTypeDto == null){
                return NotFound();
            }
            var addresstypes = _mapper.Map<Addresstype>(addressTypeDto);
            _unitOfWork.AddressTypes.Update(addresstypes);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<AddressTypeDto>(addresstypes);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var addresstype = await _unitOfWork.AddressTypes.GetByIdAsync(id);
            if (addresstype == null)
            {
                return NotFound();
            }
            _unitOfWork.AddressTypes.Remove(addresstype);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}