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
        string GetCity();
        string GetCityByCode(int code);
        string GetCityByName(string name);
        string GetDistrict();
        string GetDistrictByName(string name);
        string GetZip();
        string GetZipByCode(int code);
        string GetDistrictsByCityCode(int code);

    }
}
