

using Events.Domain.BaseEntities;
using Events.Domain.Enums;

namespace Events.Domain.Entities
{
    public class EventPlace : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Language Language { get; private set; }
        public SeatingChart SeatingChart { get; private set; }
        public string? SeatingChartImagePath { get; private set; }
        public int? Columns { get; private set; }
        public int? Rows { get; private set; }
        public EventPlace()
        {

        }
        public EventPlace(string name,Language language,SeatingChart seatingChart,string? seatingChartImagePath,int? columns = 0,int? rows = 0)
        {
            Name = name;
            Language = language;
            SeatingChart = seatingChart;
            SeatingChartImagePath = seatingChartImagePath;
            Columns = columns;
            Rows = rows;
        }
    }
}
