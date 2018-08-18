using Akic.Core.Domain.Feedback;
using System;
using System.ComponentModel.DataAnnotations;

namespace Akic.Data.Mapping.Feedback_
{
     
    public class FeedbackMap : AkicEntityTypeConfiguration<Feedback>
    {
        public FeedbackMap()
        {
            HasKey(f => f.Id);
            Property(f => f.FeedbackName).HasMaxLength(32).IsRequired();
            ToTable("Feedback");
        }
        
       
    }
}
