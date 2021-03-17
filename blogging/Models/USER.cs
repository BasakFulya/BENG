namespace blogging.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            ARTICLEs = new HashSet<ARTICLE>();
            FOLLOWINGAUTHORs = new HashSet<FOLLOWINGAUTHOR>();
            UserRoles = new HashSet<UserRole>();
        }

        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(250)]
        public string Password { get; set; }

        public string Explanation { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public bool? Gender { get; set; }

        public DateTime? Birthdate { get; set; }

        public DateTime RecordDate { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public bool? Author { get; set; }

        public bool? Confirmed { get; set; }

        public bool? Active { get; set; }

        public int? PictureID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ARTICLE> ARTICLEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOLLOWINGAUTHOR> FOLLOWINGAUTHORs { get; set; }

        public virtual PICTURE PICTURE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
