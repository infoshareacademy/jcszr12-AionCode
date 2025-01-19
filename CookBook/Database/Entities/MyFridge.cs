using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class MyFridge
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("UserCookBook")]
        public string UserCookBookId { get; set; }
        public virtual UserCookBook UserCookBook { get; set; }

        public virtual ICollection<MyFridgeIngredient> MyFridgeIngredients { get; set; }  // Kolekcja składników

    }
}
