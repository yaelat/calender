using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace  Webcalender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<Event> events=new List<Event> { new Event {Id=1,Title="default eventss",Start=DateTime.Now}, new Event { Id = 2, Title = "tom" , Start = DateTime.Now } };
        private static int Id=3;
        
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }
        // POST api/<EventsController>
        [HttpPost]
        public Event Post([FromBody] Event eve)
        {
            eve.Id = Id++;
            events.Add(eve);
            return eve;
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public Event Put(int id, [FromBody] Event eve)
        {
            var nevent = events.Find(ev => ev.Id == id);
            nevent.Start=eve.Start;
            nevent.Title=eve.Title;
            return nevent;

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var nevent = events.Find(ev => ev.Id == id);
            events.Remove(nevent);

        }


    }
}
