using System.Data.Objects;

namespace DBEntity
{
	public interface IContext
	{
		ObjectSet<T> GetObjSet<T>() where T : class, new();
	}
}
