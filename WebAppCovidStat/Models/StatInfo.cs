using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppCovidStat.Models
{
    public class StatInfo
    {
        [Key]
        public string Name { get; set; }
        public int Count { get; set; }        
    }
}