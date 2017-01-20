namespace FamousQuoteQuizGame.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Quote : BaseModel
    { 
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [ForeignKey("UserGameInfo")]
        public int? UserGameInfoId { get; set; }

        public virtual UserGameInfo UserGameInfo { get; set; }
    }
}
