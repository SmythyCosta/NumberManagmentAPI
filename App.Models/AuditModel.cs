using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class AuditModel
    {
        [Column("DH_CREATED")]
        public DateTime DhCreated { get; set; }
        [Column("DH_UPDATED")]
        public DateTime DhUpdated { get; set; }
    }
}