using Infrastructure.Persistence.Entities.Log;

namespace Infrastructure.Persistence.Contexts
{
    public class MiK8sContext
    {
        public List<PersonEntity> Persons { get; set; } = new List<PersonEntity>();
    }
}
