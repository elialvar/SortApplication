using System.ComponentModel;

namespace SortApplication.BussinessLogic.Enums
{
    /// <summary>
    /// Enum to indicate the kind of sorting to be applied.
    /// </summary>
    public enum SortingOptions
    {
        [Description("Ascending")]
        Asc = 0,

        [Description("Descending")]
        Desc = 1
    }
}
