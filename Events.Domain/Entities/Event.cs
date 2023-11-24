

using Events.Domain.BaseEntities;
using Events.Domain.Enums;

namespace Events.Domain.Entities
{
    public class Event : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Language Language { get; private set; }
        public Event() { }
        public Event(string name, Language language) 
        {
            Name = name;
            Language = language;
        }
    }
}
