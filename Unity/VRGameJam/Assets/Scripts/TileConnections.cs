using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileConnections : MonoBehaviour
{
    public GameObject ConnectionUp;
    public GameObject ConnectionDown;
    public GameObject ConnectionLeft;
    public GameObject ConnectionRight;

    public GameObject PipeCon;

    /// <summary>
    /// sets the upwards connection
    /// </summary>
    /// <param name="target">GameObject</param>
    public void SetConnectionUp(GameObject target)
    {
        ConnectionUp = target;
    }
    /// <summary>
    /// sets the downwards connection
    /// </summary>
    /// <param name="target">GameObject</param>
    public void SetConnectionDown(GameObject target)
    {
        ConnectionDown = target; 
    }

    /// <summary>
    /// sets the left connection
    /// </summary>
    /// <param name="target">GameObject</param>
    public void SetConnectionLeft(GameObject target)
    {
        ConnectionLeft = target;
    }

    /// <summary>
    /// sets the right connection
    /// </summary>
    /// <param name="target">GameObject</param>
    public void SetConnectionRight(GameObject target)
    {
        ConnectionRight = target;
    }

    /// <summary>
    /// returns the upwards connection
    /// </summary>
    /// <returns>Upwards Connection</returns>
    public GameObject GetConnectionUp()
    {
        return ConnectionUp;
    }

    /// <summary>
    /// returns the downwards connection
    /// </summary>
    /// <returns>Downwards Connection</returns>
    public GameObject GetConnectionDown()
    {
        return ConnectionDown;
    }

    /// <summary>
    /// returns the left connection
    /// </summary>
    /// <returns>Left Connection</returns>
    public GameObject GetConnectionLeft()
    {
        return ConnectionLeft;
    }

    /// <summary>
    /// returns the Right connections
    /// </summary>
    /// <returns>Right Connection</returns>
    public GameObject GetConnectionRight()
    {
        return ConnectionRight;
    }

    /// <summary>
    /// sets what pipe is connected on top of the grid spot
    /// </summary>
    /// <param name="other">GameObject</param>
    public void SetPipeCon(GameObject other)
    {
        PipeCon = other;
    }

    /// <summary>
    /// returns the pipe on top of grid
    /// </summary>
    /// <returns>Pipe connected to tile</returns>
    public GameObject GetPipeCon()
    {
        return PipeCon; 
    }
}