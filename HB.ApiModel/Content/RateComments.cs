using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.ApiModel.Content
{
    public class RateComments
    {
        public int incoming;
        public int hotel;
        public String code;
        public List<RateCommentBlock> commentsByRates;
    }
}
