namespace DBEntity
{
    partial class Commodity
    {
        protected bool Equals(Commodity other)
        {
            return _id == other._id;
        }

        public override int GetHashCode()
        {
            return _id;
        }

        /*Re-write the Equals*/

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Commodity)obj);
        }
    }
}
