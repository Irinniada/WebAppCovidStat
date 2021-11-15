using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebAppCovidStat.Models
{
    [DataContract]
    public class DataPoint
    {
		public DataPoint(double y, string legendText, string lable)
		{
			this.Y = y;
			this.LegendText = legendText;
			this.Lable = lable;
			
		}

		

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;

		[DataMember(Name = "legendText")]
		public string LegendText { get; private set; }

        [DataMember(Name = "label")]
        public string Lable { get; private set; }
	}
}