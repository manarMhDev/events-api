

using Events.Domain.BaseEntities;
using Events.Domain.Enums;

namespace Events.Domain.Entities
{
    public class PersonType : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Language Language { get; private set; }
        public string Color { get; private set; }
        public PersonType() { }
        public PersonType(string name,Language language,string color)
        {
             Name = name;
            Language = language;
            Color = color;
        }
        public void UpdatePersonType(string name, Language language,string color)
        {
            Name = name;
            Language = language;
            Color = color;
        }
    }
}
