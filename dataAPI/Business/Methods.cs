using dataAPI.Data;
using dataAPI.Models;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml;

namespace dataAPI.Business
{
    public class Methods : IRepository
    {
        Reading reading = new Reading();
        public List<District> GetDistrictsByCityCode(int code)
        {
            List<District> districts = new List<District>();
            districts = reading.ReadWithCityCode(code).City.SelectMany(x => x.District).ToList();
            return districts;
        }

        public List<Zip> GetZipCodesByCityCode(int code)
        {
            List<Zip> zips = new List<Zip>();
            zips = reading.ReadWithCityCode(code).City.SelectMany(x => x.District).SelectMany(x => x.Zip).ToList();
            return zips;
        }
        public List<Zip> GetZipCodesByDistrictName(string name)
        {
            List<Zip> zips = new List<Zip>();
            zips = reading.ReadWithDistrictName(name).City.SelectMany(x=>x.District.SelectMany(y=>y.Zip)).ToList();
            return zips;
        }
        public City GetCityByDistrictName(string name)
        {
            City city = new City();
            city = reading.ReadWithDistrictName(name).City.FirstOrDefault();
            return city;
        }
        public List<District> GetDistrictByZipCode(int code)
        {
            List<District> districts = new List<District>();
            districts = reading.ReadWithZipCode(code).City.SelectMany(x=>x.District).ToList();
            return districts;
        }
        public List<City> GetCityByZipCode(int code)
        {
            List<City> cities = new List<City>();
            cities = reading.ReadWithZipCode(code).City.ToList();
            return cities;
        }

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            cities = reading.Read().City.ToList();
            return cities;
        }

        public List<District> GetDistricts()
        {
            List<District> districts = new List<District>();
            districts = reading.Read().City.FirstOrDefault().District.ToList();
            return districts;
        }

        public List<Zip> GetZips()
        {
            List<Zip> zips = new List<Zip>();
            zips = reading.Read().City.FirstOrDefault().District.FirstOrDefault().Zip.ToList();
            return zips;
        }
    }
}