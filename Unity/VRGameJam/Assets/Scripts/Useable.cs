using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Useable : MonoBehaviour
{
    public bool inUse;

    /// <summary>
    /// runs before the first frame of the program
    /// </summary>
    private void Start()
    {
        inUse = false;
    }

    /// <summary>
    /// checks to see if the current panel is in use
    /// </summary>
    /// <returns>a bool showing if it's in use</returns>
    public bool GetInUse()
    {
        return inUse;
    }

    /// <summary>
    /// sets whether or not the panel is in use
    /// </summary>
    /// <param name="value">bool</param>
    public void SetInUse(bool value)
    {
        inUse = value; 
    }
}
