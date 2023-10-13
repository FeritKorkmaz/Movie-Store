using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class CustomerMovie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int MovieId { get; set; }

        

        public Customer? Customer { get; set; }
        public Movie? Movie { get; set; }
              
    }
}