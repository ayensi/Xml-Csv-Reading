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
        AddressInfo Read();
        AddressInfo ReadWithCityCode(int citycode);
        AddressInfo ReadWithDistrictName(string districtname);
        AddressInfo ReadWithZipCode(int zipcode);


    }
}
