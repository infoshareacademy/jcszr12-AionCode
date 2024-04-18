using System.ComponentModel;

namespace Database.EnumTypes
{
    public enum IngredientType
    {
        [Description("Vegetable")]
        Warzywa,
        [Description("Fruit")]
        Owoce,
        [Description("Bread")]
        Pieczywo,
        [Description("Fish")]
        Ryby,
        [Description("Meat")]
        Mięsa,
        [Description("Mushroom")]
        Grzyby,
        [Description("Drink")]
        Napoje,
        [Description("Dairy")]
        Nabiał,
        [Description("Seasoning")]
        Przyprawy,
        [Description("Other")]
        Inne
    }
}
