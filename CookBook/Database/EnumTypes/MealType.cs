using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
