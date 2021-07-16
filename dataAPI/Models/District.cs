using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace dataAPI.Models
{
    [Serializable]
    [XmlRoot(ElementName = "District")]
    [XmlInclude(typeof(Zip))]
    public class District
    {
        [XmlAttribute(AttributeName = "name")]
        public string district_name { get; set; }
        [XmlElement(ElementName = "Zip")]
        public List<Zip> Zip { get; set; }
        public City City { get; set; }
        public District()
        {
            City = new City();
            Zip = new List<Zip>();
            
        }
    }
}