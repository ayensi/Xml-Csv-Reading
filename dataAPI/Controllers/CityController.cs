using dataAPI.Business;
using dataAPI.Data;
using dataAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public IHttpActionResult GetCity()
        {
            var json = methods.ChooseClass("GetCity");
            return Ok(json);
        }
        [Route("api/city/getcitybycode/{id}")]
        public IHttpActionResult GetCityByCode(int id)
        {
            var json = methods.ChooseClassWithCodes("GetCityByCode", id);
            return Ok(json);
        }
        [Route("api/city/getdistrictsbycitycode/{id}")]
        public IHttpActionResult GetDistrictsByCityCode(int id)
        {
            var json = methods.ChooseClassWithCodes("GetDistrictsByCityCode", id);
            return Ok(json);

        }
        [Route("api/city/getcitybyname/{name}")]
        public IHttpActionResult GetCityByName(string name)
        {
            var json = methods.ChooseClassWithNames("GetCityByName", name);
            return Ok(json);
        }
        public string GetDistrict()
        {
            var json = methods.ChooseClass("GetDistrict");
            return json;
        }
        [Route("api/city/getdistrictbyname/{name}")]
        public IHttpActionResult GetDistrictByName(string name)
        {
            var json = methods.ChooseClassWithNames("GetDistrictByName", name);
            return Ok(json);
        }
        public string GetZip()
        {
            var json = methods.ChooseClass("GetZip");
            return json;

        }
        [Route("api/city/getzipbycode/{code}")]
        public IHttpActionResult GetZipByCode(int code)
        {
            var json = methods.ChooseClassWithCodes("GetZipByCode", code);
            return Ok(json);
        }
        //Cities descending
        public IHttpActionResult GetCitiesDesc()
        {
            var json = methods.ChooseClass("GetCity");
            var parsedData = JsonConvert.DeserializeObject<List<City>>(json);
            var Models = parsedData.Select(a => new
            {
                city_name = a.city_name,
                city_code = a.city_code
            }).OrderByDescending(x=>x.city_code).ToList();
            return Ok(Models);
        }
        //Cities ascending
        public IHttpActionResult GetCitiesAsc()
        {
            var json = methods.ChooseClass("GetCity");
            var parsedData = JsonConvert.DeserializeObject<List<City>>(json);
            var Models = parsedData.Select(a => new
            {
                city_name = a.city_name,
                city_code = a.city_code
            }).OrderByDescending(x => x.city_code).Reverse().ToList();
            return Ok(Models);
        }

    }


}