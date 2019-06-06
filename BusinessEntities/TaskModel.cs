using System;

namespace BusinessEntities
{
    public class TaskModel
    {
        public long Task_ID { get; set; }


        public long? Parent_ID { get; set; }

        public string Parent_Name { get; set; }

        public long? Project_ID { get; set; }
        public string Project_Name { get; set; }
        public string TaskName { get; set; }
        public DateTime? Start_Date { get; set; }

        public DateTime? End_Date { get; set; }

        public short? Priority { get; set; }

        public bool? Status { get; set; }

        public long? User_ID { get; set; }
        public string User_Name { get; set; }
    }
}
