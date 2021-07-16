using dataAPI.Business;
using dataAPI.Data;
using dataAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Results;

namespace dataAPI.Controllers
{

    public class CityController : ApiController
    {
        Methods methods = new Methods();

        [Route("api/city/getdistrictsbycitycode/{id}")]
        public IHttpActionResult GetDistrictsByCityCode(int id)
        {
            List<District> districtList = new List<District>();
            districtList = methods.GetDistrictsByCityCode(id);

            var model = districtList.Select(x => new
            {
                district_name = x.district_name
            }).ToList();
            return Ok(model);
        }

        [Route("api/city/getzipcodesbydistrictname/{name}")]
        public IHttpActionResult GetZipCodesByDistrictName(string name)
        {
            List<Zip> zipList = new List<Zip>();
            zipList = methods.GetZipCodesByDistrictName(name);


            var model = zipList.Select(x => new
            {
                zip_code = x.zip_code,
            }).ToList();
            return Ok(model);
        }

        [Route("api/city/getdistrictbyzipcode/{code}")]
        public IHttpActionResult GetDistrictByZipCode(int code)
        {
            List<District> districts = new List<District>();
            districts = methods.GetDistrictByZipCode(code);

            var model = districts.Select(x => new
            {
                district_name = x.district_name
            }).ToList();
            return Ok(model);
        }

        [Route("api/city/getcitybyzipcode/{code}")]
        public IHttpActionResult GetCityByZipCode(int code)
        {
            List<City> cityList = new List<City>();
            cityList = methods.GetCityByZipCode(code);

            var model = cityList.Select(x => new
            {
                city_name = x.city_name,
                city_code = x.city_code
            }).ToList();
            return Ok(model);
        }

        [Route("api/city/getzipcodesbycitycode/{code}")]
        public IHttpActionResult GetZipCodesByCityCode(int code)
        {
            List<Zip> ziplist = new List<Zip>();
            ziplist = methods.GetZipCodesByCityCode(code).ToList();

            var model = ziplist.Select(x => new
            {
                zip_code = x.zip_code
            }).ToList();
            return Ok(model);
        }

        [Route("api/city/descendingquery")]
        public IHttpActionResult GetDescendingQuery()
        {
            List<City> cityList = new List<City>();
            cityList = methods.GetCities().OrderByDescending(x => x.city_code).ToList();

            var model = cityList.Select(x => new
            {
                city_name = x.city_name,
                city_code = x.city_code
            }).ToList();
            return Ok(model);
        }

        [Route("api/city/ascendingquery")]
        public IHttpActionResult GetAscendingQuery()
        {
            List<City> cityList = new List<City>();
            cityList = methods.GetCities().OrderByDescending(x => x.city_code).Reverse().ToList();

            var model = cityList.Select(x => new
            {
                city_name = x.city_name,
                city_code = x.city_code
            }).ToList();
            return Ok(model);
        }
        [Route("api/city/getcitybydistrictname/{name}")]
        public IHttpActionResult GetCityByDistrictName(string name)
        {
            City city = new City();
            city = methods.GetCityByDistrictName(name);

            var model = new
            {
                city_name = city.city_name,
                city_code = city.city_code
            };
            return Ok(model);
        }

    }
}