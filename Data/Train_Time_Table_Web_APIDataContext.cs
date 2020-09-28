using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Train_Time_Table_Web_API.BusinessModel;

namespace Train_Time_Table_Web_API.Models
{
    //Connects the business model to the databse.
    public class Train_Time_Table_Web_APIDataContext : DbContext
    {
        public Train_Time_Table_Web_APIDataContext (DbContextOptions<Train_Time_Table_Web_APIDataContext> options)
            : base(options)
        {
        }

        public DbSet<Train_Time_Table_Web_API.BusinessModel.TrainTimeTableRecord> TrainTimeTableRecord { get; set; }
    }
}
