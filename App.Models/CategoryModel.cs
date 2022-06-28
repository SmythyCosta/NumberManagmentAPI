using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Models
{
    [Table("CATEGORY")]
    public class CategoryModel : AuditModel
    {
        [Key]
        [Column("CATEGORY_ID")]
        public int CategoryId { get; set; }
        [Column("CATEGORY_NAME")]
        public string CategoryName { get; set; }
        [Column("CATEGORY_DESCRIPTION")]
        public string CategoryDescription { get; set; }

    }
}
