using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelDaily.Models
{
    [Table("userprofile")]
    public class UserProfile
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(28)]
        [Column("firebaseuserid")]
        public string FirebaseUserId { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("username")]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("firstname")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("lastname")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Column("email")]
        public string Email { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("createdatetime")]
        public DateTime CreateDateTime { get; set; }
        [MaxLength(255)]
        //[DataType(DataType.ImageUrl)]
        [Column("imagelocation")]
        public string ImageLocation { get; set; }
    }
}