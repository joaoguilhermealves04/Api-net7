using AwesineDevEvents.Api.Entities;

namespace AwesineDevEvents.Api.Persistence
{
    public class DeveEnvetsDbContext
    {
        public List<DevEvent>DevEvents { get; set; }

        public DeveEnvetsDbContext()
        {
            DevEvents = new List<DevEvent>();
        }
    }
}
