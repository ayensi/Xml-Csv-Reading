using dataAPI.Data;
using dataAPI.Models;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace dataAPI.Business
{
    public class XML : IRepository
    {
        Reading reading = new Reading();
        public string GetCity()
        {
            List<City> cities = new List<City>();
            cities = reading.Read(cities);
            string output = new JavaScriptSerializer().Serialize(cities);
            return output;
        }

        public string GetCityByCode(int code)
        {         
            List<City> cities = new List<City>();
            cities = reading.Read(cities).Where(x=>x.city_code == code).ToList();
            string output = new JavaScriptSerializer().Serialize(cities);
            return output;
        }

        public string GetCityByName(string name)
        {
            List<City> cities = new List<City>();
            cities = reading.Read(cities).Where(x => x.city_name == name).ToList();
            string output = new JavaScriptSerializer().Serialize(cities);
            return output;
        }

        public string GetDistrict()
        {
            List<District> districts = new List<District>();
            districts = reading.Read(districts);
            string output = new JavaScriptSerializer().Serialize(districts);
            return output;
        }

        public string GetDistrictByName(string name)
        {
           
            List<District> districts = new List<District>();
            districts = reading.Read(districts).Where(x=>x.district_name==name).ToList();
            string output = new JavaScriptSerializer().Serialize(districts);
            return output;
        }

        public string GetZip()
        {
            List<Zip> zips = new List<Zip>();
            zips = reading.Read(zips);
            string output = new JavaScriptSerializer().Serialize(zips);
            return output;
        }

        public string GetZipByCode(int code)
        {
            
            List<Zip> zips = new List<Zip>();
            zips = reading.Read(zips).Where(x => x.zip_code == code).ToList();
            string output = new JavaScriptSerializer().Serialize(zips);
            return output;
        }
        public string GetDistrictsByCityCode(int code)
        {

            List<District> districts = new List<District>();
            districts = reading.Read(districts).Where(x => x.city_code == code).ToList();
            string output = new JavaScriptSerializer().Serialize(districts);
            return output;
        }

    }
}