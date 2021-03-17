namespace blogging.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COMMENT")]
    public partial class COMMENT
    {
        public int CommentID { get; set; }

        [Column("Comment")]
        [Required]
        [StringLength(1500)]
        public string Comment1 { get; set; }

        public int ArticleID { get; set; }

        public DateTime? UploadDate { get; set; }

        [Required]
        [StringLength(150)]
        public string NameSurname { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }

        public int? CommentLike { get; set; }

        public virtual ARTICLE ARTICLE { get; set; }
    }
}
