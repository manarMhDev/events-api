

using Events.Domain.BaseEntities;
using Events.Domain.Enums;

namespace Events.Domain.Entities
{
    public class ChairType : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Language Language { get; private set; }
        public string Color { get; private set; }
        public string ColorText { get; private set; }
        public string ImagePath { get; private set; }
        public ChairType() { }
        public ChairType(string name,Language language,string color,string colorText,string imagePath) 
        {
            Name = name;
            Language = language;
            Color = color;
            ColorText = colorText;
            ImagePath = imagePath;
        }
    }
}
