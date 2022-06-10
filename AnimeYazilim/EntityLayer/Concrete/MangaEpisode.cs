using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MangaEpisode
    {
        [Key]
        public int MangaEpisodeID { get; set; }
        public string MangaEpNum { get; set; }
        public string MangaEpPage1 { get; set; }
        public string MangaEpPage2 { get; set; }
        public string MangaEpPage3 { get; set; }
        public string MangaEpPage4 { get; set; }
        public string MangaEpPage5 { get; set; }
        public string MangaEpPage6 { get; set; }
        public string MangaEpPage7 { get; set; }
        public string MangaEpPage8 { get; set; }
        public string MangaEpPage9 { get; set; }
        public string MangaEpPage10 { get; set; }
        public string MangaEpPage11 { get; set; }
        public string MangaEpPage12 { get; set; }
        public string MangaEpPage13 { get; set; }
        public string MangaEpPage14 { get; set; }
        public string MangaEpPage15 { get; set; }
        public string MangaEpPage16 { get; set; }
        public string MangaEpPage17 { get; set; }
        public string MangaEpPage18 { get; set; }
        public string MangaEpPage19 { get; set; }
        public string MangaEpPage20 { get; set; }


        public int MangaID { get; set; }
        public virtual Manga Manga { get; set; }

        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
