using dataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAPI.Data
{
    interface IRead
    {
        //CSV Reading
        List<City> Read(City city, List<City> cities);
        List<District> Read(District district, List<District> districts);
        List<Zip> Read(Zip zip, List<Zip> zips);

        //XML Reading
        List<City> Read(List<City> cities);
        List<District> Read(List<District> districts);
        List<Zip> Read(List<Zip> zips);
        
    }
}
