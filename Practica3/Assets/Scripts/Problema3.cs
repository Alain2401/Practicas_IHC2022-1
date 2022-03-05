using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problema3 : MonoBehaviour
{
    public static int[] arreglo = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
    public static List<int> nums = new List<int>();
    private static int actual = 0, final = 0, inicio = 0, fin = 0, s = 0;
    void Start()
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            final += arreglo[i];
            if (actual < final)
            {
                actual = final;
                inicio = s;
                fin = i;
            }
            if (final < 0)
            {
                final = 0;
                s = i + 1;
            }
        }
        for (int i = s; i <= fin; i++)
        {
            nums.Add(arreglo[i]);
        }
        Debug.Log("La suma es " + actual);
        Debug.Log("Los numeros usados en la suma son: ");
        foreach (int num in nums)
        {
            Debug.Log(num + " ");
        }
    }
}