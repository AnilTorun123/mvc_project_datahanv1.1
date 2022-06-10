using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Manga
    {
        [Key]
        public int MangaID { get; set; }
        [StringLength(100)]
        public string MangaName { get; set; }
        public decimal MangaEpisode { get; set; }
        [StringLength(500)]
        public string MangaImage { get; set; }
        [StringLength(500)]
        public string MangaAbout { get; set; }
        [StringLength(1500)]
        public string MangaText { get; set; }
        [StringLength(100)]
        public string MangaDemographic { get; set; }

        //

        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
