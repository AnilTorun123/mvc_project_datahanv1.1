using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        [StringLength(50)]
        public string WriterName { get; set; }
        [StringLength(50)]
        public string WriterSurname { get; set; }
        [StringLength(300)]
        public string WriterImage { get; set; }
        [StringLength(500)]
        public string WriterMail { get; set; }
        [StringLength(500)]
        public string WriterPassword { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }
        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }

        public bool WriterStatus { get; set; }
        [StringLength(100)]
        public string WriterAbout { get; set; }


        //
        public ICollection<Anime> Animes { get; set; }
        public ICollection<Manga> Mangas { get; set; }
        public ICollection<AnimeEpisode> AnimeEpisodes { get; set; }
        public ICollection<MangaEpisode> MangaEpisodes { get; set; }

        //

        public byte[] WriterPasswordHash { get; set; }
        public byte[] WriterPasswordSalt { get; set; }
    }
}
