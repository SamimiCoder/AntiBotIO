using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiBotIO.Shared.Models
{
    public class DetectionPossibilities
    {
        public bool IsDateEqualsPost { get; set; }
        public bool IsTextSuspicious { get; set; }
        public bool IsTextContainsSpecialCaracters { get; set; }
        public bool IsCommentLikesZero { get; set; }
        public bool IsProfileBioHasLink { get; set; }
        public bool IsProfileBioLinkIsTelegram { get; set; }
        public bool IsProfileFollowersLessThanFollowings { get; set; }
    }
}
