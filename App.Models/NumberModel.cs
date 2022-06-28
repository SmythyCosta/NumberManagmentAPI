using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("NUMBER")]
    public class NumberModel : AuditModel
    {
        [Key]
        [Column("ID_NUMBER")]
        public int Id { get; set; }
        
        [Column("COUNTRY")]
        public string Country { get; set; }

        [Column("DDD")]
        public string Ddd { get; set; }

        [Column("PREFIX")]
        public string Prefix { get; set; }

        [Column("SUFIX")]
        public string Sufix { get; set; }

        [ForeignKey("Category")]
        [Column("CATEGORY_ID")]
        public int CategoryId;

        [ForeignKey("NumberStatus")]
        [Column("STATUS_ID")]
        public int StatusId;

        public CategoryModel Category {get; set;}

        public NumberStatusModel NumberStatus {get; set;}
        
    }
}