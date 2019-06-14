using System;

namespace BusinessEntities
{
    public class ProjectModel
    {
        public long Project_ID { get; set; }
        public string ProjectName { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public short? Priority { get; set; }
        public string Status { get; set; }
        public int? NumberOfTasks { get; set; }

        public long? Manager_ID { get; set; }

        public string Manager_Name { get; set; }

    }
}
