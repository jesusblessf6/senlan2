using System.Collections;

namespace DBEntity
{
    public class EntityUtil
    {
        public static void FilterDeletedEntity(IList entities)
        {
            for (int i = 0; i < entities.Count; )
            {
                if(((IEntity)entities[i]).IsDeleted)
                {
                    entities.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }
    }
}