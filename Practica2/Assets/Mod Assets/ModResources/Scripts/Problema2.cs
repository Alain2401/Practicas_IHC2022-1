using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problema2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int target;
        int[] nums = new int[] { 2, 5, 9, 13, 17 };
       
        int[] output = new int[2];
        target = 15;
        Acom(nums);
        Sum(nums, target, output);
        Debug.Log("Primer numero en indice: " + output[0] + " Segundo numero en indice: " + output[1]);
    }

    public void Acom(int[] numeros)
    {
        int temp;
        for (int j = 0; j <= numeros.Length - 2; j++)
        {
            for (int i = 0; i <= numeros.Length - 2; i++)
            {
                if (numeros[i] > numeros[i + 1])
                {
                    temp = numeros[i + 1];
                    numeros[i + 1] = numeros[i];
                    numeros[i] = temp;
                }
            }
        }
    }


    public void Sum(int[] nums, int target, int[] output)
    {
        int aux;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                aux = 0;
                aux = nums[i] + nums[j];
                if (aux == target)
                {
                    output[0] = j;
                    output[1] = i;
                }
            }
        }
    }


}