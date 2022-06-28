using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Models
{
    [Table("QUARENTINE")]
    public class QuarentineInfoModel : AuditModel
    {
        
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        
        [Column("FULL_NUMBER")]
        public string FullNumber { get; set; }

        [Column("START_DATE")]
        public string StartDate { get; set; }

        [Column("QUANTITY_DAYS")]
        public string QauntityDays { get; set; }

        [Column("USER_UPDATE")]
        public string UserUpdate { get; set; }

        [Column("TXT_DESCRIPTION_JOB")]
        public string TxtDesciptionJob { get; set; }
        
    }
}