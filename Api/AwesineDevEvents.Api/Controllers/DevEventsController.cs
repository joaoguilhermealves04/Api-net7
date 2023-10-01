using AwesineDevEvents.Api.Entities;
using AwesineDevEvents.Api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AwesineDevEvents.Api.Controllers

{   [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : Controller
    {
        private readonly DeveEnvetsDbContext _context;

        public DevEventsController( DeveEnvetsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEvents.Where(d => !d.IsDeleted).ToList();
            return Ok(devEvents);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvents =  _context.DevEvents.SingleOrDefault(d => d.Id == id);
            var isequaltonull = devEvents == null ? false : true;
            
            if (isequaltonull != true)
            {
                return NotFound();
            }

            return Ok(devEvents);
         
        }

        [HttpPost]
        public IActionResult Post(DevEvent devEvent) 
        {
             _context.DevEvents.Add(devEvent);
             return CreatedAtAction(nameof(GetById), new {id=devEvent.Id},devEvent);
        }

        [HttpPut ("{Id}")]
        public IActionResult Put(Guid id,DevEvent input)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            var isequaltonull = devEvents == null ? false : true;

            if (isequaltonull != true)
            {
                return NotFound();
            }

            devEvents.Update(input.Title,input.Description,input.StartDate,input.EndDate);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            var isequaltonull = devEvents == null ? false : true;

            if (isequaltonull != true)
            {
                return NotFound();
            }

            devEvents.Delete();

            return NoContent();
        }

        [HttpPost("{id}/speakers")]
        public IActionResult postSpeaker(Guid id,DevEventsSpeaker speaker)
        {
            var devEvents = _context.DevEvents.SingleOrDefault(d => d.Id == id);
            var isequaltonull = devEvents == null ? false : true;

            if (isequaltonull != true)
            {
                return NotFound();
            }

            devEvents.Speakers.Add(speaker);

            return NoContent();
        }


    }
}
