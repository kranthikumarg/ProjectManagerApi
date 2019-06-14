namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Task")]
    public partial class Task
    {
        [Key]
        public long Task_ID { get; set; }
        public long? Parent_ID { get; set; }

        public long? Project_ID { get; set; }

        [Column("Task")]
        [StringLength(500)]
        public string Task1 { get; set; }

        public DateTime? Start_Date { get; set; }

        public DateTime? End_Date { get; set; }

        public short? Priority { get; set; }

        public bool? Status { get; set; }

        public long? User_ID { get; set; }

        public virtual ParentTasks ParentTask { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }
    }
}
