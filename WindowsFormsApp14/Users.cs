using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp14
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int IdMiasto { get; set; }
    }
}