using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Train_Time_Table_Web_API.BusinessModel
{
    //A train time table record.
    public class TrainTimeTableRecord
    {
        //Id of the record.
        public int Id { get; set; }

        //Service name
        public string Service { get; set; }

        //Destinaton name.
        public string Destination { get; set; }

       //Time of arrival.
        public DateTime Time { get; set;  }

    }
}
