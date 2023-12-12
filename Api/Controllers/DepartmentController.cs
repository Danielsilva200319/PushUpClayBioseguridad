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
    public class DepartmentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get()
        {
            var department = await _unitOfWork.Departments.GetAllAsync();
            return _mapper.Map<List<DepartmentDto>>(department);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartmentDto>> Get(int id)
        {
            var departments = await _unitOfWork.Departments.GetByIdAsync(id);
            if (departments == null)
            {
                return NotFound();
            }
            return _mapper.Map<DepartmentDto>(departments);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DepartmentDto>> Post(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.Departments.Add(department);
            await _unitOfWork.SaveAsync();
            if (department == null)
            {
                return BadRequest();
            }
            departmentDto.Id = department.Id;
            return CreatedAtAction(nameof(Post), new {id = departmentDto.Id}, departmentDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DepartmentDto>> Put(int id, DepartmentDto departmentDto)
        {
            if (departmentDto.Id == 0){
                departmentDto.Id = id;
            }
            if (departmentDto.Id != id){
                return BadRequest();
            }
            if (departmentDto == null){
                return NotFound();
            }
            var departments = _mapper.Map<Department>(departmentDto);
            _unitOfWork.Departments.Update(departments);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DepartmentDto>(departments);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            _unitOfWork.Departments.Remove(department);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}