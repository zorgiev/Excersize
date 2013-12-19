using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PicturesExchange.Models
{
    public class Picture
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public byte[] pictureData { get; set; }
        public string contentType { get; set; }
    }
}
