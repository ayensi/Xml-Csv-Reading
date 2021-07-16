using dataAPI.Data;
using dataAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Xml.Linq;
using static dataAPI.WebApiApplication;

namespace dataAPI.Business
{
    public class Reading : IRead
    {
        private string DataSource = Globals.dataSource;
        private string XMLPath = Globals.xmlPath;
        public AddressInfo Read()
        {
            switch (DataSource)
            {
                case "XML":
                    AddressInfo deserialized;
                    XmlSerializer deserializer = new XmlSerializer(typeof(AddressInfo));
                    using (TextReader reader = new StreamReader(XMLPath))
                    {
                        object obj = deserializer.Deserialize(reader);
                        deserialized = (AddressInfo)obj;
                    }
                    return deserialized;
                default:
                    return null;
            }
        }
        public AddressInfo ReadWithCityCode(int citycode)
        {
            switch (DataSource)
            {
                case "XML":
                    AddressInfo deserialized;
                    XmlSerializer deserializer = new XmlSerializer(typeof(AddressInfo));
                    using (TextReader reader = new StreamReader(XMLPath))
                    {
                        object obj = deserializer.Deserialize(reader);
                        deserialized = (AddressInfo)obj;
                    }
                    deserialized.City = deserialized.City.Where(x => x.city_code == citycode).ToList();
                    return deserialized;
                default:
                    return null;
            }


        }

        public AddressInfo ReadWithDistrictName(string districtname)
        {
            switch (DataSource)
            {
                case "XML":
                    AddressInfo addressInfo = new AddressInfo
                    {
                        City = new List<City>()
                    };
                    City city = new City();
                    District dist = new District();
                    Zip zip = new Zip();
                    XmlDocument xml = new XmlDocument();
                    xml.Load(XMLPath);

                    XmlNodeList xnList = xml.SelectNodes($"/AddressInfo/City/District[@name='{districtname}']");
                    foreach (XmlNode xn in xnList)
                    {
                        city.city_name = xn.ParentNode.Attributes["name"].Value;
                        city.city_code = Convert.ToInt32(xn.ParentNode.Attributes["code"].Value);
                        dist.district_name = xn.Attributes["name"].Value;
                        foreach (XmlNode xmlNode in xn)
                        {
                            zip.zip_code = Convert.ToInt32(xmlNode.Attributes["code"].Value);
                            dist.Zip.Add(zip);
                            zip = new Zip();
                        }
                        city.District.Add(dist);
                        addressInfo.City.Add(city);
                        city = new City();
                        dist = new District();
                    }
                    return addressInfo;

                default:
                    return null;
            }
        }
            
        public AddressInfo ReadWithZipCode(int zipcode)
        {
            switch (DataSource)
            {
                case "XML":
                    AddressInfo addressInfo = new AddressInfo
                    {
                        City = new List<City>()
                    };
                    City city = new City();
                    District dist = new District();
                    Zip zip = new Zip();
                    XmlDocument xml = new XmlDocument();
                    xml.Load(XMLPath);

                    XmlNodeList xnList = xml.SelectNodes($"/AddressInfo/City/District/Zip[@code='{zipcode}']");
                    foreach (XmlNode xn in xnList)
                    {
                        city.city_name = xn.ParentNode.ParentNode.Attributes["name"].Value;
                        city.city_code = Convert.ToInt32(xn.ParentNode.ParentNode.Attributes["code"].Value);
                        dist.district_name = xn.ParentNode.Attributes["name"].Value;
                        zip.zip_code = Convert.ToInt32(xn.Attributes["code"].Value);
                        dist.Zip.Add(zip);
                        zip = new Zip();
                        city.District.Add(dist);
                        addressInfo.City.Add(city);
                        city = new City();
                        dist = new District();
                    }
                    return addressInfo;

                default:
                    return null;
            }
        }

    }
}       