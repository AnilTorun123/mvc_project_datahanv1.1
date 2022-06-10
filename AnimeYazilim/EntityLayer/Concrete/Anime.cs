using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Anime
    {
        [Key]
        public int AnimeID { get; set; }
        [StringLength(100)]
        public string AnimeName { get; set; }
        public bool AlreadyFinish { get; set; }
        public DateTime AnimeDate { get; set; }
        public decimal AnimeEpisode { get; set; }
        public decimal AnimeVote { get; set; }
        [StringLength(500)]
        public string AnimeImage { get; set; }
        [StringLength(500)]
        public string AnimeAbout { get; set; }
        [StringLength(1500)]
        public string AnimeText { get; set; }
        public bool AnimeStatus { get; set; }

        [StringLength(100)]
        public string AnimeProducers { get; set; }
        [StringLength(200)]
        public string AnimeDemographic { get; set; }

        //

        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        //
        public ICollection<AnimeEpisode> AnimeEpisodes { get; set; }

    }
}
