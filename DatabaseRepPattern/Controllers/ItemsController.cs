using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseRepPattern.Models;
using DatabaseRepPattern.Models.Dtos;
using DatabaseRepPattern.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseRepPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ItemsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _unitOfWork.Items.GetAll();
            if (!items.Any())
            {
                return NotFound();
            }
            var itemsDto = _mapper.Map<IEnumerable<ItemDto>>(items);
            return Ok(itemsDto);
        }

        [HttpGet("{id}", Name = "GetItem")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await
                _unitOfWork.Items.GetFirstOrDefaul(
                    c => c.id == id
                );
            if (item == null)
            {
                return NotFound();
            }
            var itemDto = _mapper.Map<ItemDto>(item);
            return Ok(itemDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOne(int custId, int itemId)
        {
            var customer = await _unitOfWork.Customers.Get(custId);
            var item = await _unitOfWork.Items.GetFirstOrDefaul(item => item.id == itemId && item.customerId == custId);
            if (customer == null || item == null)
            {
                return NotFound();
            }
            _unitOfWork.Items.Remove(item);
            if (await _unitOfWork.Save())
            {
                return NoContent();
            }
            throw new Exception($"Deleting item {itemId} failed");
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToCustomer(int custId,
        [FromForm] ItemCreateDto itemCreate)
        {
            var customer = await _unitOfWork.Customers.Get(custId);
            if (customer == null) {
                return NotFound();
            }
            var item = _mapper.Map<Item>(itemCreate);
            item.customerId = custId;
            _unitOfWork.Items.Add(item);
            if (await _unitOfWork.Save())
            {
                var itemToReturn = _mapper.Map<ItemDto>(item);
                return CreatedAtRoute("GetItem", new { item.id }, itemToReturn);
            }
            return BadRequest("Could not add the item");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, int custId, ItemUpdateDto update)
        {
            var customer = await _unitOfWork.Customers.Get(custId);
            var oryginal = await _unitOfWork.Items.GetFirstOrDefaul(item => item.id == id && item.customerId == custId);
            if (customer == null || oryginal == null)
            {
                return NotFound();
            }
            _unitOfWork.Items.Update(oryginal, update);
            if (await _unitOfWork.Save())
            {
                return NoContent();
            }
            throw new Exception($"Updating user {id} failed");
        }
    }
}
