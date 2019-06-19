using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Useable : MonoBehaviour
{
    public bool inUse;

    private void Start()
    {
        inUse = false;
    }

    public bool GetInUse()
    {
        return inUse;
    }

    public void SetInUse(bool value)
    {
        inUse = value; 
    }
}
