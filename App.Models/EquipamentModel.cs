using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Models
{
    [Table("EQUIPAMENT")]
    public class EquipamentModel : AuditModel
    {
        [Key]
        [Column("ID_EQUIPAMENT")]
        public int EquipamentId { get; set; }
        
        [Column("NAME")]
        public string EquipamentName { get; set; }
        
        [Column("DESCRIPTION")]
        public string EquipamentDescription { get; set; }

    }
}