using System.Collections.Generic;

public class Permutator    
{
    public IEnumerable<T> Permutations<T>(T permutable_object)
        where T : IPermutable<T>
    {
        // Heap's algorithm used here to permutate iteratively instead of recursively :
        // https://rosettacode.org/wiki/Permutations_by_swapping#Java
        // more explanation about the recursive version of this algorithm here : 
        // http://villemin.gerard.free.fr/aNombre/MOTIF/PermutAl.htm
        yield return permutable_object;

        int n = permutable_object.Count;
        int[] counters = new int[n];
        int i = 0;

        while (i < n)
        {
            if (counters[i] < i)
            {
                if (i % 2 == 0)
                {
                    permutable_object = permutable_object.Swap(0, i);
                }
                else
                {
                    permutable_object = permutable_object.Swap(counters[i], i);
                }

                yield return permutable_object;
                ++counters[i];
                i = 0;
            }
            else
            {
                counters[i] = 0;
                ++i;
            }
        }
    }

    public IEnumerable<T> UniquePermutations<T>(T permutable_object)
        where T : IRankable, IPermutable<T>
    {
        foreach (T permutation in Permutations(permutable_object))
        {
            if (permutation.IsOrdered())
            {
                yield return permutation;
            }
        }
    }
}
