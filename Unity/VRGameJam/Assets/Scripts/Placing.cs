using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placing : MonoBehaviour
{
    public bool used;

    public bool connectedToStart;
    public bool connectedToEnd;

    public Material red;
    public Material blue;
    public Material pink;

    public PipeConnections GO_PC;

    public GameObject tileLocation;

    /// <summary>
    /// code that is run once the program starts
    /// </summary>
    public void Start()
    {
         GO_PC = this.gameObject.GetComponent<PipeConnections>(); 

        used = false;
        connectedToStart = false; 
        connectedToEnd = false; 

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
        //check the connection of the object on tile
        CheckAdjacentTiles();

        if (connectedToStart && !connectedToEnd)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = blue;
        }
        if (connectedToEnd && !connectedToStart)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = pink;
        }
        else
        {
            if (!connectedToStart && !connectedToEnd)
            { this.gameObject.GetComponent<MeshRenderer>().material = red; }
        }
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
                    if (upCon.gameObject.GetComponent<TileConnections>().GetPipeCon().name == "Start")
                    {
                        connectedToStart = true;
                    }
                    else
                    {
                        connectedToStart = false;
                    }
                    if (upCon.gameObject.GetComponent<TileConnections>().GetPipeCon().name == "End")
                    {
                        connectedToEnd = true;
                    }
                    else
                    {
                        connectedToEnd = false;
                    }
                    CheckConnectionsOfPipe(upCon.gameObject.GetComponent<TileConnections>().GetPipeCon());
                }
            }

            if(GO_PC.GetConnectionDown())
            {
                if (tileLocation.GetComponent<TileConnections>().GetConnectionDown() != null)
                {
                    //connected down
                    GameObject downCon = tileLocation.GetComponent<TileConnections>().GetConnectionDown();
                    downCon.gameObject.GetComponent<TileConnections>().GetPipeCon();
                    if(downCon.gameObject.GetComponent<TileConnections>().GetPipeCon().name == "Start")
                    {
                        connectedToStart = true; 
                    }
                    else
                    {
                        connectedToStart = false;
                    }
                    if (downCon.gameObject.GetComponent<TileConnections>().GetPipeCon().name == "End")
                    {
                        connectedToEnd = true;
                    }
                    else
                    {
                        connectedToEnd = false;
                    }
                    CheckConnectionsOfPipe(downCon.gameObject.GetComponent<TileConnections>().GetPipeCon());
                }   
            }

            if (GO_PC.GetConnectionLeft())
            {
                if (tileLocation.GetComponent<TileConnections>().GetConnectionLeft() != null)
                {
                    //connected left
                    GameObject leftCon = tileLocation.GetComponent<TileConnections>().GetConnectionLeft();
                    leftCon.gameObject.GetComponent<TileConnections>().GetPipeCon();
                    if (leftCon.gameObject.GetComponent<TileConnections>().GetPipeCon().name == "Start")
                    {
                        connectedToStart = true;
                    }
                    else
                    {
                        connectedToStart = false;
                    }
                    if (leftCon.gameObject.GetComponent<TileConnections>().GetPipeCon().name == "End")
                    {
                        connectedToEnd = true;
                    }
                    else
                    {
                        connectedToEnd = false;
                    }
                    CheckConnectionsOfPipe(leftCon.gameObject.GetComponent<TileConnections>().GetPipeCon());
                }
            }

            if (GO_PC.GetConnectionRight())
            {
                if (tileLocation.GetComponent<TileConnections>().GetConnectionRight() != null)
                {
                    //connected right
                    GameObject rightCon = tileLocation.GetComponent<TileConnections>().GetConnectionRight();
                    rightCon.gameObject.GetComponent<TileConnections>().GetPipeCon();
                    if (rightCon.gameObject.GetComponent<TileConnections>().GetPipeCon().name == "Start")
                    {
                        connectedToStart = true;
                    }
                    else
                    {
                        connectedToStart = false;
                    }
                    if (rightCon.gameObject.GetComponent<TileConnections>().GetPipeCon().name == "End")
                    {
                        connectedToEnd = true;
                    }
                    else
                    {
                        connectedToEnd = false;
                    }
                    CheckConnectionsOfPipe(rightCon.gameObject.GetComponent<TileConnections>().GetPipeCon());
                }
            }
        }
    }

    public void CheckConnectionsOfPipe(GameObject other)
    {
        if(this.gameObject.GetComponent<PipeConnections>().GetConnectionUp() && other.GetComponent<PipeConnections>().GetConnectionDown())
        {
            //connect upwards to downwards
            if (other.GetComponent<Placing>().connectedToEnd)
            {
                this.connectedToEnd = true;
            }
            if (other.GetComponent<Placing>().connectedToStart)
            {
                this.connectedToStart = true;
            }
        }
        if (this.gameObject.GetComponent<PipeConnections>().GetConnectionDown() && other.GetComponent<PipeConnections>().GetConnectionUp())
        {
            //connect downwards to upwards
            //connect upwards to downwards
            if (other.GetComponent<Placing>().connectedToEnd)
            {
                this.connectedToEnd = true;
            }
            if (other.GetComponent<Placing>().connectedToStart)
            {
                this.connectedToStart = true;
            }
        }
        if (this.gameObject.GetComponent<PipeConnections>().GetConnectionLeft() && other.GetComponent<PipeConnections>().GetConnectionRight())
        {
            //connect left to right
            //connect upwards to downwards
            if (other.GetComponent<Placing>().connectedToEnd)
            {
                this.connectedToEnd = true;
            }
            if (other.GetComponent<Placing>().connectedToStart)
            {
                this.connectedToStart = true;
            }
        }
        if (this.gameObject.GetComponent<PipeConnections>().GetConnectionRight() && other.GetComponent<PipeConnections>().GetConnectionLeft())
        {
            //connect right to left
            //connect upwards to downwards
            if (other.GetComponent<Placing>().connectedToEnd)
            {
                this.connectedToEnd = true;
            }
            if (other.GetComponent<Placing>().connectedToStart)
            {
                this.connectedToStart = true;
            }
        }
    }
}
