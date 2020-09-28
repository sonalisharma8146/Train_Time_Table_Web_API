using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Train_Time_Table_Web_API.BusinessModel;
using Train_Time_Table_Web_API.Models;

namespace Train_Time_Table_Web_API.Controllers
{
    //Train time table record controller.
    [Route("api/[controller]")]
    [ApiController]
    public class TrainTimeTableRecordsController : ControllerBase
    {
        private readonly Train_Time_Table_Web_APIDataContext _context;

        public TrainTimeTableRecordsController(Train_Time_Table_Web_APIDataContext context)
        {
            _context = context;
        }

        // GET: api/TrainTimeTableRecords
        //Get all time table records using a linq query.
        
        [HttpGet]
        public  ActionResult<IEnumerable<TrainTimeTableRecord>> GetTrainTimeTableRecord()
        {
            return (from train in _context.TrainTimeTableRecord
                    select train).ToList();
        }

        // GET: api/TrainTimeTableRecords/5
        //Gets a time table record using a linq query
        [HttpGet("{id}")]
        public ActionResult<TrainTimeTableRecord> GetTrainTimeTableRecord(int id)
        {
            var trainTimeTableRecord = (from timeRecord in _context.TrainTimeTableRecord
                                        where timeRecord.Id == id
                                        select timeRecord).FirstOrDefault();

            if (trainTimeTableRecord == null)
            {
                return NotFound();
            }

            return trainTimeTableRecord;
        }

        // PUT: api/TrainTimeTableRecords/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates the time table record.
        [HttpPut("{id}")]
        public IActionResult PutTrainTimeTableRecord(int id, TrainTimeTableRecord trainTimeTableRecord)
        {
            if (id != trainTimeTableRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainTimeTableRecord).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainTimeTableRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TrainTimeTableRecords
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds the train time table record to databse.
        [HttpPost]
        public ActionResult<TrainTimeTableRecord> PostTrainTimeTableRecord(TrainTimeTableRecord trainTimeTableRecord)
        {
            _context.TrainTimeTableRecord.Add(trainTimeTableRecord);
             _context.SaveChanges();

            return CreatedAtAction("GetTrainTimeTableRecord", new { id = trainTimeTableRecord.Id }, trainTimeTableRecord);
        }

        // DELETE: api/TrainTimeTableRecords/5
        //Removes the record from databse uses a linq query to select the record.
        [HttpDelete("{id}")]
        public ActionResult<TrainTimeTableRecord> DeleteTrainTimeTableRecord(int id)
        {
            var trainTimeTableRecord = (from timeRecord in _context.TrainTimeTableRecord
                                        where timeRecord.Id == id
                                        select timeRecord).FirstOrDefault();
            if (trainTimeTableRecord == null)
            {
                return NotFound();
            }

            _context.TrainTimeTableRecord.Remove(trainTimeTableRecord);
             _context.SaveChanges();

            return trainTimeTableRecord;
        }

        //Checks the time record using a lamda query.
        private bool TrainTimeTableRecordExists(int id)
        {
            return _context.TrainTimeTableRecord.Any(e => e.Id == id);
        }
    }
}
