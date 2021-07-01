using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using dataAPI.Data;
using dataAPI.Models;
using Microsoft.VisualBasic.FileIO;
using Nancy.Json;


namespace dataAPI.Business
{
    public class CSV:IRepository
    {
        Reading reading = new Reading();
        public string GetCity()
        {
            City city = new City();
            List<City> cities = new List<City>();
            var json = new JavaScriptSerializer().Serialize(reading.Read(city, cities));
            return json;
        }
        public string GetCityByCode(int code)
        {
            City city = new City();
            List<City> cities = new List<City>();
            cities = reading.Read(city, cities).Where(x=>x.city_code==code).ToList();
            var json = new JavaScriptSerializer().Serialize(cities);
            return json;
        }
        public string GetCityByName(string name)
        {
            City city= new City();
            List<City> cities = new List<City>();
            cities = reading.Read(city, cities).Where(x => x.city_name == name).ToList();
            var json = new JavaScriptSerializer().Serialize(cities);
            return json;
        }
        public string GetDistrict()
        {
            District district = new District();
            List<District> districts = new List<District>();
            var json = new JavaScriptSerializer().Serialize(reading.Read(district, districts));
            return json;
        }
        public string GetDistrictByName(string name)
        {
            District district= new District();
            List<District> districts = new List<District>();
            districts = reading.Read(district, districts).Where(x => x.district_name == name).ToList();
            var json = new JavaScriptSerializer().Serialize(districts);
            return json;
        }
        public string GetZip()
        {
            Zip zip= new Zip();
            List<Zip> zips = new List<Zip>();
            var json = new JavaScriptSerializer().Serialize(reading.Read(zip, zips));
            return json;
        }
        public string GetZipByCode(int code)
        {
            Zip zip= new Zip();
            List<Zip> zips = new List<Zip>();
            zips = reading.Read(zip, zips).Where(x => x.zip_code == code).ToList();
            var json = new JavaScriptSerializer().Serialize(zips);
            return json;
        }
        public string GetDistrictsByCityCode(int code)
        {
            District district = new District();
            List<District> districts = new List<District>();
            districts = reading.Read(district, districts).Where(x => x.city_code == code).ToList();
            var json = new JavaScriptSerializer().Serialize(districts);
            return json;
        }

    }
}