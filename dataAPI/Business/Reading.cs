using dataAPI.Data;
using dataAPI.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace dataAPI.Business
{
    public class Reading : IRead
    {
        //CSV Reading
        public List<City> Read(City city, List<City> cities)
        {
            int tmp_code = 0;
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\Okan Bey\source\repos\dataAPI\dataAPI\Files\sample_data.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    foreach (var field in fields)
                    {
                        if (fields[0] != "CityName")
                        {

                            city = new City();
                            city.city_name = fields[0];
                            city.city_code = Convert.ToInt32(fields[1]);
                            if (cities.Count == 0)
                            {
                                tmp_code = Convert.ToInt32(fields[1]);
                                cities.Add(city);
                            }
                            else
                            {

                                if (city.city_code != tmp_code)
                                {
                                    tmp_code = Convert.ToInt32(fields[1]);
                                    cities.Add(city);
                                }
                            }
                        }

                    }

                }

            }
            return cities;
        }
        public List<District> Read(District district, List<District> districts)
        {
            string tmp_name = "";
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\Okan Bey\source\repos\dataAPI\dataAPI\Files\sample_data.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    foreach (var field in fields)
                    {
                        if (fields[0] != "CityName")
                        {

                            district = new District();
                            district.city_code = Convert.ToInt32(fields[1]);
                            district.district_name = fields[2];
                            if (districts.Count == 0)
                            {
                                tmp_name = fields[2];
                                districts.Add(district);
                            }
                            else
                            {
                                if (district.district_name != tmp_name)
                                {
                                    tmp_name = fields[2];
                                    districts.Add(district);
                                }
                            }
                        }

                    }

                }

            }
            return districts;
        }
        public List<Zip> Read(Zip zip, List<Zip> zips)
        {
            int tmp_code = 0;
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\Okan Bey\source\repos\dataAPI\dataAPI\Files\sample_data.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    foreach (var field in fields)
                    {
                        if (fields[0] != "CityName")
                        {

                            zip = new Zip();
                            zip.district_name = fields[2];
                            zip.zip_code = Convert.ToInt32(fields[3]);
                            if (zips.Count == 0)
                            {
                                tmp_code = Convert.ToInt32(fields[3]);
                                zips.Add(zip);
                            }
                            else
                            {

                                if (zip.zip_code != tmp_code)
                                {
                                    tmp_code = Convert.ToInt32(fields[3]);
                                    zips.Add(zip);
                                }
                            }

                        }

                    }

                }

            }
            return zips;
        }

        //XML Reading
        public List<City> Read(List<City> cities)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Files/sample_data.xml"));
            foreach (XmlNode node in doc.SelectNodes("/AddressInfo/City"))
            {
                if (node.Attributes != null)
                {
                    var nameAttribute = node.Attributes["name"];
                    var codeAttribute = node.Attributes["code"];
                    if (nameAttribute != null && codeAttribute != null)
                        cities.Add(new City
                        {
                            city_name = nameAttribute.Value,
                            city_code = Convert.ToInt32(codeAttribute.Value)
                        });
                }

            }
            return cities;
        }
        public List<District> Read(List<District> districts)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Files/sample_data.xml"));
            foreach (XmlNode node in doc.SelectNodes("/AddressInfo/City/District"))
            {
                if (node.Attributes != null)
                {
                    var nameAttribute = node.Attributes["name"];
                    var parentNode = node.ParentNode;
                    if (nameAttribute != null)
                        districts.Add(new District
                        {
                            district_name = nameAttribute.Value,
                            city_code = Convert.ToInt32(parentNode.Attributes["code"].Value)
                        });
                }

            }
            return districts;
        }
        public List<Zip> Read(List<Zip> zips)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Files/sample_data.xml"));
            foreach (XmlNode node in doc.SelectNodes("/AddressInfo/City/District/Zip"))
            {
                if (node.Attributes != null)
                {
                    var codeAttribute = node.Attributes["code"];
                    var parentNode = node.ParentNode;
                    if (codeAttribute != null)
                        zips.Add(new Zip
                        {
                            district_name = parentNode.Attributes["name"].Value,
                            zip_code = Convert.ToInt32(codeAttribute.Value)
                        });
                }

            }
            return zips;
        }

    }
}