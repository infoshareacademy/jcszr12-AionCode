using System.ComponentModel;

namespace Database.EnumTypes
{
    public enum MealType
    {
        //breakfast. lunch. dinner supper
        [Description("breakfast")]
        Śniadanie,
        [Description("lunch")]
        Obiad,
        [Description("dinner")]
        Kolacja,
        [Description("supper")]
        NocnePodżeranie,
        [Description("other")]
        Inne
    }
}
