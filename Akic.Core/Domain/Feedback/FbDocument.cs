using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Feedback
{
    [Table("FbDocument")]  
    public  class FbDocument:BaseEntity
    {

        public string DocumentName { get; set; }
        public string DocumentUrl { get; set; }
        public string FeedbackId { get; set; }
        public string UploaderId { get; set; }

        public string UploaderName { get; set; }
    }
}
