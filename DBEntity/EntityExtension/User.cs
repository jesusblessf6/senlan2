namespace DBEntity
{
    partial class User
    {
        /*Re-write the Equals*/

        protected bool Equals(User other)
        {
            return _id == other._id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((User)obj);
        }
    }
}
