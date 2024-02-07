using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabase.Models
{
    public class BaseModel
    {
        [Key]
        public virtual long Id { get; set; }
        public virtual DateOnly Created {  get; set; }
        public virtual DateOnly LastModified { get; set; }
    }
}
