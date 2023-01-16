using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp14
{
    public class Miasta
    {
        [Key]
        public int IdM { get; set; }
        public string Miasto { get; set; }
    }
}