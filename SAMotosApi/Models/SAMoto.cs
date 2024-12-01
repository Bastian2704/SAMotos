using System.ComponentModel.DataAnnotations;

namespace SAMotosMVC.Models
{
    public class SAMoto
    {
        [Key]
        public int idSAMoto { get; set; }
        public string? SAmodelo { get; set; }
        public string? SAmarca { get; set; }
        public int SAcilindraje { get; set; }
        public string? SAcolor { get; set; }
    }
}
