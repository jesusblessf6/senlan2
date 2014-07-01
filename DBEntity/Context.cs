using System;
using System.Collections.Generic;
using System.Data.Objects;

namespace DBEntity
{
    public partial class SenLan2Entities : IContext
	{
		private Dictionary<Type, object> abc = new Dictionary<Type, object>();
        public const string ConnectionString = "name=SenLan2Entities";
        public const string ContainerName = "SenLan2Entities";

		public ObjectSet<TEntity> GetObjSet<TEntity>() where TEntity : class, new()
		{
			TEntity t = new TEntity();
			Type type = t.GetType();
			if (!abc.ContainsKey(type))
			{
				ObjectSet<TEntity> x = CreateObjectSet<TEntity>();
				abc[type] = x;
			}
			return abc[type] as ObjectSet<TEntity>;
		}

        
	}
}
