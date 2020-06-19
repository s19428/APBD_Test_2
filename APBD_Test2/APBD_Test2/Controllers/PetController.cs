using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_Test2.Models;
using APBD_Test2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Test2.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetsDbService _dbService;
        public PetController(IPetsDbService petsDbService)
        {
            _dbService = petsDbService;
        }

        [HttpGet("{year}")]
        public IActionResult GetPets(int year)
        {
            try
            {
                return Ok(_dbService.GetPets(year));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPet(Pet pet)
        {
            bool result = _dbService.AddPet(pet);
            if (result == false)
                return BadRequest("Pet already exists");
            return Ok("New pet added");
        }
    }
}