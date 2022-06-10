using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AnimeEpisode
    {
        [Key]
        public int AnimeEpisodeID { get; set; }
        public string AnimeEpNum { get; set; }
        public string AnimeEp { get; set; }
        

        public int AnimeID { get; set; }
        public virtual Anime Anime { get; set; }

        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }


    }
}
