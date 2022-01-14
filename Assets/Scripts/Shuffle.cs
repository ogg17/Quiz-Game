using UnityEngine;
public static class Shuffle
{
    public static void ShuffleArray(int[] array)  
    {  
        int n = array.Length;  
        while (n > 1) {  
            n--;  
            var k = Random.Range(0, n + 1);  
            (array[k], array[n]) = (array[n], array[k]);
        }  
    }
}
