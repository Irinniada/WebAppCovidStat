using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppCovidStat.Models
{
    public class StatIntInfo
    {
        [Key]
        public int Name { get; set; }
        public int Count { get; set; }
    }
}