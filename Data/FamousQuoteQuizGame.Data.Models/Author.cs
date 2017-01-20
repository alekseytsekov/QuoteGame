namespace FamousQuoteQuizGame.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Author : BaseModel
    {
        private ICollection<Quote> quotes;
        public Author()
        {
            this.quotes = new HashSet<Quote>();
        }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Quote> Quotes
        {
            get { return this.quotes; }
            set { this.quotes = value; }
        }
    }
}
