using dataAPI.Models;
using Nancy;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace dataAPI.Data
{
    interface IRepository
    {
        List<Zip> GetZipCodesByDistrictName(string name);
        List<District> GetDistrictsByCityCode(int code);
        List<District> GetDistrictByZipCode(int code);
        List<City> GetCityByZipCode(int code);
        List<City> GetCities();
        List<District> GetDistricts();
        List<Zip> GetZips();
        List<Zip> GetZipCodesByCityCode(int code);
        City GetCityByDistrictName(string name);

    }
}
