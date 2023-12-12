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
    public class StateController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StateController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<StateDto>>> Get()
        {
            var state = await _unitOfWork.States.GetAllAsync();
            return _mapper.Map<List<StateDto>>(state);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StateDto>> Get(int id)
        {
            var states = await _unitOfWork.States.GetByIdAsync(id);
            if (states == null)
            {
                return NotFound();
            }
            return _mapper.Map<StateDto>(states);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<StateDto>> Post(StateDto stateDto)
        {
            var state = _mapper.Map<State>(stateDto);
            _unitOfWork.States.Add(state);
            await _unitOfWork.SaveAsync();
            if (state == null)
            {
                return BadRequest();
            }
            stateDto.Id = state.Id;
            return CreatedAtAction(nameof(Post), new {id = stateDto.Id}, stateDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<StateDto>> Put(int id, StateDto stateDto)
        {
            if (stateDto.Id == 0){
                stateDto.Id = id;
            }
            if (stateDto.Id != id){
                return BadRequest();
            }
            if (stateDto == null){
                return NotFound();
            }
            var states = _mapper.Map<State>(stateDto);
            _unitOfWork.States.Update(states);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<StateDto>(states);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var state = await _unitOfWork.States.GetByIdAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            _unitOfWork.States.Remove(state);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}