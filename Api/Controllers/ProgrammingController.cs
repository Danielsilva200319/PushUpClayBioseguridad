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
    public class ProgrammingController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProgrammingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProgramingDto>>> Get()
        {
            var programing = await _unitOfWork.Programmings.GetAllAsync();
            return _mapper.Map<List<ProgramingDto>>(programing);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProgramingDto>> Get(int id)
        {
            var programings = await _unitOfWork.Programmings.GetByIdAsync(id);
            if (programings == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProgramingDto>(programings);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ProgramingDto>> Post(ProgramingDto programingDto)
        {
            var programing = _mapper.Map<Programming>(programingDto);
            _unitOfWork.Programmings.Add(programing);
            await _unitOfWork.SaveAsync();
            if (programing == null)
            {
                return BadRequest();
            }
            programingDto.Id = programing.Id;
            return CreatedAtAction(nameof(Post), new {id = programingDto.Id}, programingDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProgramingDto>> Put(int id, ProgramingDto programingDto)
        {
            if (programingDto.Id == 0){
                programingDto.Id = id;
            }
            if (programingDto.Id != id){
                return BadRequest();
            }
            if (programingDto == null){
                return NotFound();
            }
            var programings = _mapper.Map<Programming>(programingDto);
            _unitOfWork.Programmings.Update(programings);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProgramingDto>(programings);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var programing = await _unitOfWork.Programmings.GetByIdAsync(id);
            if (programing == null)
            {
                return NotFound();
            }
            _unitOfWork.Programmings.Remove(programing);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}