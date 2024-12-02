using System.ComponentModel.DataAnnotations;

namespace SAMotosMaui.Models
{
    public class SAMoto
    {
        public int idSAMoto { get; set; }
        public string? SAmodelo { get; set; }
        public string? SAmarca { get; set; }
        public int SAcilindraje { get; set; }
        public string? SAcolor { get; set; }
    }
}
