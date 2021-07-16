using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace dataAPI.Models
{
    [Serializable]
    [XmlRoot(ElementName = "Zip")]
    public class Zip
    {
        public District District { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public int zip_code { get; set; }
        public Zip()
        {
            District = new District();
        }

    }
}