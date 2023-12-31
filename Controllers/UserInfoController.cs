﻿
using DLS_WebAPI.Entites;
using DLS_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace DLS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {

        private readonly DlDbContext _dbContext;
        private readonly CityDataStore _cityDataStore;
        public UserInfoController(DlDbContext dlDbContext, CityDataStore cityDataStore)
        {
            _dbContext = dlDbContext;
            _cityDataStore = cityDataStore ?? throw new ArgumentNullException(nameof(cityDataStore));
        }


        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUser(UserInfo userInfo)
        {
            _dbContext.UserInfos.Add(userInfo);
            await _dbContext.SaveChangesAsync();

            return Ok(userInfo);
        }


        [HttpPost("company")]
        public async Task<ActionResult<CompanyInfo>> PostCompany(CompanyInfo companyInfo)
        {
            _dbContext.CompanyInfos.Add(companyInfo);
            await _dbContext.SaveChangesAsync();

            return Ok(companyInfo);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTodoItem(int id)
        {
            var item = await _dbContext.Tests.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }


        [HttpGet("all_city_info")]
        public ActionResult<IEnumerable<CityDto>> Getcities()
        {
            //return new JsonResult(new List<object>
            //{
            //    new{id = 1, Name = "Dhaka"}
            //});


            //var temp = new JsonResult(CityDataStore.Current.Cities);
            //temp.StatusCode = 200;
            //return new JsonResult(CityDataStore.Current.Cities);

            return Ok(_cityDataStore.Cities);
        }


        [HttpGet("city_info_by_/{id}")]
        public ActionResult<CityDto> Getcities(int id)
        {
            var cityToReturn = _cityDataStore.Cities
                .FirstOrDefault(x => x.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}
