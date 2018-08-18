namespace Akic.Core.Tests.QQQ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(32)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(32)]
        public string RealName { get; set; }

        [Required]
        [StringLength(32)]
        public string StuNumber { get; set; }

        [StringLength(64)]
        public string Identification { get; set; }

        public int? Gender { get; set; }

        [StringLength(32)]
        public string Phone { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [StringLength(256)]
        public string PhotoUrl { get; set; }

        [Column(TypeName = "ntext")]
        public string About { get; set; }

        [StringLength(64)]
        public string PersonalPage { get; set; }

        public int? State { get; set; }

        [StringLength(100)]
        public string Roles { get; set; }
    }
}
