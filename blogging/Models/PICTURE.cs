namespace blogging.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PICTURE")]
    public partial class PICTURE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PICTURE()
        {
            ARTICLEs = new HashSet<ARTICLE>();
            FOLLOWINGAUTHORs = new HashSet<FOLLOWINGAUTHOR>();
            USERs = new HashSet<USER>();
        }

        public int PictureID { get; set; }

        [StringLength(250)]
        public string SmallSize { get; set; }

        [StringLength(250)]
        public string MiddleSize { get; set; }

        [StringLength(250)]
        public string LargeSize { get; set; }

        public int? ArticleID { get; set; }

        [StringLength(250)]
        public string Video { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ARTICLE> ARTICLEs { get; set; }

        public virtual ARTICLE ARTICLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOLLOWINGAUTHOR> FOLLOWINGAUTHORs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER> USERs { get; set; }
    }
}
