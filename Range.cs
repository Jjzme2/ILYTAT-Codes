using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public float GetMin { get; private set; }
    public float GetMax { get; private set; }

    public float GetRandomValue
    {
        get
        {
            float v = Random.Range(GetMin, GetMax);
            return v;
        }
    }

    public bool IsInBounds(float valueToCheck)
    {
        if(valueToCheck <= GetMax && valueToCheck >= GetMin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
