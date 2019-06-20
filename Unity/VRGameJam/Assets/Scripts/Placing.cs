﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placing : MonoBehaviour
{
    public bool used;

    public bool connectedToStart;
    public bool connectedToEnd;

    PipeConnections GO_PC;

    public GameObject tileLocation;

    /// <summary>
    /// code that is run once the program starts
    /// </summary>
    public void Start()
    {
         GO_PC = this.gameObject.GetComponent<PipeConnections>(); 

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

        tileLocation.GetComponent<TileConnections>().SetPipeCon(this.gameObject);

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

        if(tileLocation != null)
        {
            if(tileLocation.GetComponent<TileConnections>() != null)
                tileLocation.GetComponent<TileConnections>().SetPipeCon(null);

            tileLocation = null;
        }
    }

    /// <summary>
    /// this is called once every frame
    /// </summary>
    public void Update()
    {
        //check adjacent tiles
        CheckAdjacentTiles();
        //check the connection of the object on tile
    }

    /// <summary>
    /// Checks adjacent tiles and returns them
    /// </summary>
    private void CheckAdjacentTiles()
    {
        if(tileLocation != null)
        {
            if (GO_PC.GetConnectionUp())
            {
                if (tileLocation.GetComponent<TileConnections>().GetConnectionUp() != null)
                {
                    //connected up
                    GameObject upCon = tileLocation.GetComponent<TileConnections>().GetConnectionUp();
                    upCon.gameObject.GetComponent<TileConnections>().GetPipeCon();
                }
            }

            if(GO_PC.GetConnectionDown())
            {
                if (tileLocation.GetComponent<TileConnections>().GetConnectionDown() != null)
                {
                    //connected down

                }   
            }

            if (GO_PC.GetConnectionLeft())
            {
                if (tileLocation.GetComponent<TileConnections>().GetConnectionLeft() != null)
                {
                    //connected left

                }
            }

            if (GO_PC.GetConnectionRight())
            {
                if (tileLocation.GetComponent<TileConnections>().GetConnectionRight() != null)
                {
                    //connected right

                }
            }
        }
    }

    public void CheckConnectionsOfPipe(GameObject other)
    {
        if(this.gameObject.GetComponent<PipeConnections>().GetConnectionUp() && other.GetComponent<PipeConnections>().GetConnectionDown())
        {
            //connect upwards to downwards
        }
        if (this.gameObject.GetComponent<PipeConnections>().GetConnectionDown() && other.GetComponent<PipeConnections>().GetConnectionUp())
        {
            //connect downwards to upwards
        }
        if (this.gameObject.GetComponent<PipeConnections>().GetConnectionDown() && other.GetComponent<PipeConnections>().GetConnectionUp())
        {
            //connect downwards to upwards
        }

    }
}
