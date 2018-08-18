using Akic.Core.Domain.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Feedback_
{
    public class FbDocumentMap : AkicEntityTypeConfiguration<FbDocument>
    {
        public FbDocumentMap()
        {
            HasKey(fd => fd.Id);
            //1 ... *
            

            ToTable("FbDocument");
        }    
    }
}
