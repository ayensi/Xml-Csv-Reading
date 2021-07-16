using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace dataAPI.Models
{
    [Serializable]
    [XmlRoot(ElementName = "AddressInfo")]
    [XmlInclude(typeof(City))]
    public class AddressInfo
    {
        [XmlElement(ElementName = "City")]
        public List<City> City { get; set; }
        public AddressInfo()
        {
            City = new List<City>();
        }
    }
}