using System.Linq;

namespace Codility_Free_Trial_Tasks.MissingElement
{
    public class MissingElementSolution
    {
        public int FindMissingElement(int[] A)
        {
            var result = A.OrderBy(e => e).ToList();
            
            if (result.Count == 0)
            {
                return 1;
            }

            if (result.First() != 1) // first element missing. each collection should start at 1.
            {
                return 1;
            }

            if (result.Last() == result.Count) // last element is missing.
            {
                return result.Count + 1;
            }
            
            for (int i = 0; i < result.Count - 1; i++)
            {
                if(result[i] + 1 != result[i+1])
                {
                    return result[i] + 1;
                }
            }
            return -1;
        }
    }
}