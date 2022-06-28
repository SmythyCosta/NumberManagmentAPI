using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("NUMBER_EQUIPAMENT")]
    public class NumberEquipamentModel : AuditModel
    {

        [Column("ID_EQUIPAMENT")]
        public int EquipamentId { get; set; }
        [Column("ID_NUMBER")]
        public int NumberId { get; set; }

        public EquipamentModel Equipament { get; set; }

        public NumberModel Number { get; set; }
        
    }
}