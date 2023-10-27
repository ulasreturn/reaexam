using Infrastructure.Data.Postgres.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Postgres.Entities
{
  public class Employee : Entity<int>
  {
       
        public int UserId { get; set; } = default!;
        public string Cinsiyet { get; set; } = default!;
        public DateTime DogumTarihi { get; set; } = default!;
        public string UzmanlikAlani { get; set; } = default!;


        public User User { get; set; } 
        public IList<Comment> Comments { get; set; }
        // Ek sütunlar
        // Diğer ilgili doktor bilgileri
    }
}
