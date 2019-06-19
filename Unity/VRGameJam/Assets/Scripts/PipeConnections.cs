using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeConnections : MonoBehaviour
{
    public bool ConnectionUp;
    public bool ConnectionDown;
    public bool ConnectionLeft;
    public bool ConnectionRight;

    public bool GetConnectionUp()
    {
        return ConnectionUp;
    }

    public bool GetConnectionDown()
    {
        return ConnectionDown;
    }

    public bool GetConnectionLeft()
    {
        return ConnectionLeft;
    }

    public bool GetConnectionRight()
    {
        return ConnectionRight;
    }
}
