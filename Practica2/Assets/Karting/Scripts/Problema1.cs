using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problema1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int i, j, aux;
        int[] num = new int[] { 10, 1, 3, 4, 5, 8 , 7, 15};
        int[] r;
        r = inicializarArray(num.Length);
        for (i = 0; i < num.Length; i++)
        {
            aux = num[i];
            for (j = 0; j < num.Length; j++)
            {
                if (aux > num[j])
                {
                    r[i]++;
                }
            }
        }
        for (i = 0; i < 6; i++)
        {
            Debug.Log(r[i]);
        }
    }

    // Update is called once per frame
    int[] inicializarArray(int n)
    {
        int i;
        int[] arreglo = new int[n];
        for (i = 0; i < n; i++)
        {
            arreglo[i] = 0;
        }
        return arreglo;
    }
}
