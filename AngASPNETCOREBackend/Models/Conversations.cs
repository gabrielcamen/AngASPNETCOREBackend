using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Models
{
    public class Conversations
    {
        public int Id { get; set; }
        [Required]
        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public virtual Users Sender { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public virtual Users Reciever { get; set; }
        [MaxLength(255)]
        [Required]
        public string Message { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAT { get; set; }
    }
}
