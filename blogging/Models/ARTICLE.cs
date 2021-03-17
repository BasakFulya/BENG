namespace blogging.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ARTICLE")]
    public partial class ARTICLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ARTICLE()
        {
            COMMENTs = new HashSet<COMMENT>();
            PICTUREs = new HashSet<PICTURE>();
            TAGs = new HashSet<TAG>();
        }

        public int ArticleID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string ArticleContent { get; set; }

        public DateTime UploadDate { get; set; }

        public int CategoryID { get; set; }

        public int ViewedNumber { get; set; }

        public int ArticleLike { get; set; }

        public int AuthorID { get; set; }

        public int? PictureID { get; set; }

        public int? WriterID { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        public virtual PICTURE PICTURE { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT> COMMENTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PICTURE> PICTUREs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAG> TAGs { get; set; }
    }
}
