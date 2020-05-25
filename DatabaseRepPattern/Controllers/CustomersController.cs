using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseRepPattern.Models;
using DatabaseRepPattern.Models.Dtos;
using DatabaseRepPattern.Repository;
using DatabaseRepPattern.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseRepPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomersController(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSimple()
        {
            var customers = await _unitOfWork.Customers.GetAll();
            if(!customers.Any())
            {
                return NotFound();
            }
            var simpleCustomers = _mapper.Map<IEnumerable<CustomerSimpleDto>>(customers);
            return Ok(simpleCustomers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStandard(int id)
        {
            var customer = await
                _unitOfWork.Customers.GetFirstOrDefaul(
                    c => c.id == id
                );
            if (customer == null)
            {
                return NotFound();
            }
            var simpleCustomer = _mapper.Map<CustomerStandardDto>(customer);
            return Ok(simpleCustomer);
        }

        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var customer = await
                _unitOfWork.Customers.GetFirstOrDefaul(
                    c => c.id == id,
                    includeProperties: "items,orders"
                );
            if (customer == null)
            {
                return NotFound();
            }
            var detailCustomer = _mapper.Map<CustomerDetailDto>(customer);
            return Ok(detailCustomer);
        }

        [HttpGet("{id}/simple")]
        public async Task<IActionResult> GetSimple(int id)
        {
            var customer = await
                _unitOfWork.Customers.GetFirstOrDefaul(
                    c => c.id == id
                );
            if (customer == null)
            {
                return NotFound();
            }
            var simpleCustomer = _mapper.Map<CustomerSimpleDto>(customer);
            return Ok(simpleCustomer);
        }

        [HttpGet("{id}/items")]
        public async Task<IActionResult> GetItemsOfCustomer(int id)
        {
            var items = await
                _unitOfWork.Items.GetAll(
                    p => p.customerId == id
                );
            if (!items.Any())
            {
                return NotFound();
            }
            var itemsDto = _mapper.Map<IEnumerable<ItemDto>>(items);
            return Ok(itemsDto);
        }

        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetOrdersOfCustomer(int id)
        {
            var orders = await
                _unitOfWork.Orders.GetAll(
                    c => c.customerId == id
                );
            if (!orders.Any())
            {
                return NotFound();
            }
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(ordersDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerUpdateDto update)
        {
            var userOryginal = await _unitOfWork.Customers.Get(id);
            if (userOryginal == null)
            {
                return NotFound();
            }
            _unitOfWork.Customers.Update(userOryginal, update);
            if (await _unitOfWork.Save())
            {
                return NoContent();
            }
            throw new Exception($"Updating user {id} failed");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOne(int id)
        {
            var customer = await _unitOfWork.Customers.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            _unitOfWork.Customers.Remove(customer);
            if(await _unitOfWork.Save())
            {
                return NoContent();
            }
            throw new Exception($"Deleting user {id} failed");
        }
    }
}
