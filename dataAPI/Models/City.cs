using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace dataAPI.Models
{
    [Serializable]
    [XmlRoot(ElementName = "City")]
    [XmlInclude(typeof(District))]
    public class City
    {
        public AddressInfo AddressInfo { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string city_name { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public int city_code { get; set; }
        [XmlElement(ElementName = "District")]
        public List<District> District { get; set; }
        public City()
        {
            AddressInfo = new AddressInfo();
            District = new List<District>();

        }

    }
}