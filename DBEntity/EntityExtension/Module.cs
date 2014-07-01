namespace DBEntity
{
    partial class Module
    {
        protected bool Equals(Module other)
        {
            return _id == other._id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        /*Re-write the Equals*/

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Module)obj);
        }
    }
}
