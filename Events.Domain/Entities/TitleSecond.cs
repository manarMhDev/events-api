

using Events.Domain.BaseEntities;
using Events.Domain.Enums;

namespace Events.Domain.Entities
{
    public class TitleSecond : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Language Language { get; private set; }
        public TitleSecond() { }
        public TitleSecond(string name, Language language)
        {
            Name = name;
            Language = language;
        }
        public void UpdateTitleSecond(string name, Language language)
        {
            Name = name;
            Language = language;
        }
    }
}
