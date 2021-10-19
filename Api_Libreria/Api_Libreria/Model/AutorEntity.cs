using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Libreria.Model
{
    [Table("AUTOR")]
    public class AutorEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOMBRECOMPLETO")]
        public string NombreCompleto { get; set; }

        [Column("FECHANACIMIENTO")]
        public DateTime FechaNacimiento { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

       


        //Foreign key para ciudad
        [Column("CIUDADID")]
        public int CiudadId { get; set; }
        public CiudadEntity Ciudad { get; set; }
    }
}
