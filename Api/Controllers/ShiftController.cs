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
    public class ShiftController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShiftController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ShiftDto>>> Get()
        {
            var shift = await _unitOfWork.Shifts.GetAllAsync();
            return _mapper.Map<List<ShiftDto>>(shift);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShiftDto>> Get(int id)
        {
            var shifts = await _unitOfWork.Shifts.GetByIdAsync(id);
            if (shifts == null)
            {
                return NotFound();
            }
            return _mapper.Map<ShiftDto>(shifts);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ShiftDto>> Post(ShiftDto shiftDto)
        {
            var shift = _mapper.Map<Shift>(shiftDto);
            if (shiftDto.TimeShiftStart == TimeOnly.MinValue)
            {
                shiftDto.TimeShiftStart = TimeOnly.FromDateTime(DateTime.Now);
                shift.TimeShiftStart = TimeOnly.FromDateTime(DateTime.Now);
            }
            if (shiftDto.TimeShiftEnd == TimeOnly.MinValue)
            {
                shiftDto.TimeShiftEnd = TimeOnly.FromDateTime(DateTime.Now);
                shift.TimeShiftEnd = TimeOnly.FromDateTime(DateTime.Now);
            }
            _unitOfWork.Shifts.Add(shift);
            await _unitOfWork.SaveAsync();
            if (shift == null)
            {
                return BadRequest();
            }
            shiftDto.Id = shift.Id;
            return CreatedAtAction(nameof(Post), new {id = shiftDto.Id}, shiftDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ShiftDto>> Put(int id, ShiftDto shiftDto)
        {
            if (shiftDto.Id == 0){
                shiftDto.Id = id;
            }
            if (shiftDto.Id != id){
                return BadRequest();
            }
            if (shiftDto == null){
                return NotFound();
            }
            var shifts = _mapper.Map<Shift>(shiftDto);
            if (shiftDto.TimeShiftStart == TimeOnly.MinValue)
            {
                shiftDto.TimeShiftStart = TimeOnly.FromDateTime(DateTime.Now);
                shifts.TimeShiftStart = TimeOnly.FromDateTime(DateTime.Now);
            }
            if (shiftDto.TimeShiftEnd == TimeOnly.MinValue)
            {
                shiftDto.TimeShiftEnd = TimeOnly.FromDateTime(DateTime.Now);
                shifts.TimeShiftEnd = TimeOnly.FromDateTime(DateTime.Now);
            }
            _unitOfWork.Shifts.Update(shifts);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ShiftDto>(shifts);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var shift = await _unitOfWork.Shifts.GetByIdAsync(id);
            if (shift == null)
            {
                return NotFound();
            }
            _unitOfWork.Shifts.Remove(shift);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}