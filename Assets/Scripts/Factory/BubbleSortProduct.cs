using System.Collections.Generic;
using Interface;

namespace Factory
{
    public static class BubbleSortProduct
    {
        public static List<T> GetSortList<T>(List<T> list) where T : IProduct
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count ; j++)
                {
                    if (list[i].ID > list[j].ID)
                    {
                        (list[i], list[j]) = (list[j], list[i]);
                    }
                }
            }
            
            return list;
        }
    }
}