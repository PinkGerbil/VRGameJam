using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeConnections : MonoBehaviour
{
    public bool ConnectionUp;
    public bool ConnectionDown;
    public bool ConnectionLeft;
    public bool ConnectionRight;

    /// <summary>
    /// returns if the pipe is connected upwards
    /// </summary>
    /// <returns>bool of upwards connection</returns>
    public bool GetConnectionUp()
    {
        return ConnectionUp;
    }

    /// <summary>
    /// returns if the pipe is connected downwards
    /// </summary>
    /// <returns>bool of downwards connection</returns>
    public bool GetConnectionDown()
    {
        return ConnectionDown;
    }

    /// <summary>
    /// returns if the pipe is connected to the left
    /// </summary>
    /// <returns>bool of the left connection</returns>
    public bool GetConnectionLeft()
    {
        return ConnectionLeft;
    }

    /// <summary>
    /// returns if the pipe is connected to the right
    /// </summary>
    /// <returns>bool of the right connection</returns>
    public bool GetConnectionRight()
    {
        return ConnectionRight;
    }
}
