using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Models
{
    [Table("NUMBER_STATUS")]
    public class NumberStatusModel
    {
        [Key]
        [Column("ID_NUMBER_STATUS")]
        public int Id { get; set; }

        [Column("NUMBER_STATUS_NAME")]
        public string StatusName { get; set; }
        
    }
}