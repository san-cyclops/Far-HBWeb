using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.ApiModel.Content
{
    public class AbstractGenericContentResponse
    {

        public int from;

        public int to;

        public int total;

        public AuditData auditData;

        public HotelbedsError error;
    }
}
