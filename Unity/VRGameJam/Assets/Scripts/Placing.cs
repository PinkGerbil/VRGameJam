using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placing : MonoBehaviour
{
    public bool used;

    public GameObject tileLocation;

    /// <summary>
    /// code that is run once the program starts
    /// </summary>
    public void Start()
    {
        used = false;

        tileLocation = null;
    }

    /// <summary>
    /// sets the current object to in use and sets it's tile location
    /// </summary>
    /// <param name="tile">GameObject</param>
    public void inUse(GameObject tile)
    {
        tileLocation = tile;

        used = true;
    }

    /// <summary>
    /// checks to see if the gameobject is in use
    /// </summary>
    /// <returns>used</returns>
    public bool GetInUse()
    {
        return used; 
    }

    /// <summary>
    /// when you pick up the gameobject from the tile it sets it's used to false and removes it's tile location
    /// </summary>
    public void PickUpFromTile()
    {
        used = false;

        tileLocation = null;
    }
}
