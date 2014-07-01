using System.Runtime.Serialization;

namespace Utility.Misc
{
    [DataContract]
    public class SortCol
    {
        [DataMember] public bool ByDescending;
        [DataMember] public string ColName;
    }
}