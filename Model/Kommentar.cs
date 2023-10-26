using System.ComponentModel.DataAnnotations;

namespace webAPIMiniReddit.Model
{
    public class Kommentar
    {
        [Key]
        public int idKommentar { get; set; }

        public string brugerKommentar { get; set; }
        public string text { get; set; }

        public int stemOpK { get; set; } = 0;
        public int stemNedK { get; set; } = 0;

        public int totalStemmerK { get; set; } = 0;
        
        public DateTime dato { get; set; }

    }
}
