using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class CustomerMovie
    {
         public CustomerMovie()
        {
            PurchasedDate = DateTime.Now;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }

        

        public Customer? Customer { get; set; }
        public Movie? Movie { get; set; }

        
        public DateTime PurchasedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
   
}