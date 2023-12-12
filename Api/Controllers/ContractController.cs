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
    public class ContractController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContractController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContractDto>>> Get()
        {
            var contract = await _unitOfWork.Contracts.GetAllAsync();
            return _mapper.Map<List<ContractDto>>(contract);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContractDto>> Get(int id)
        {
            var contracts = await _unitOfWork.Contracts.GetByIdAsync(id);
            if (contracts == null)
            {
                return NotFound();
            }
            return _mapper.Map<ContractDto>(contracts);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ContractDto>> Post(ContractDto contractDto)
        {
            var contract = _mapper.Map<Contract>(contractDto);
            _unitOfWork.Contracts.Add(contract);
            await _unitOfWork.SaveAsync();
            if (contract == null)
            {
                return BadRequest();
            }
            contractDto.Id = contract.Id;
            return CreatedAtAction(nameof(Post), new {id = contractDto.Id}, contractDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ContractDto>> Put(int id, ContractDto contractDto)
        {
            if (contractDto.Id == 0){
                contractDto.Id = id;
            }
            if (contractDto.Id != id){
                return BadRequest();
            }
            if (contractDto == null){
                return NotFound();
            }
            var contracts = _mapper.Map<Contract>(contractDto);
            _unitOfWork.Contracts.Update(contracts);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ContractDto>(contracts);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var contract = await _unitOfWork.Contracts.GetByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            _unitOfWork.Contracts.Remove(contract);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}