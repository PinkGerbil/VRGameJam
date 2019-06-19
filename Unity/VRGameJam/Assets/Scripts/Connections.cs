using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connections : MonoBehaviour
{
    public Canvas tileHolder;

    public GameObject[,] tiles = new GameObject[6,6];

    /// <summary>
    /// this is called when the object is initialised 
    /// </summary>
    public void Awake()
    {
        SetChildren();
        SetConnections();
    }

    /// <summary>
    /// gets all the children of the canvas and places them into an array
    /// </summary>
    public void SetChildren()
    {
        for (int i = 0; i < tileHolder.transform.childCount; i++)
        {
            GameObject temp = tileHolder.transform.GetChild(i).gameObject;
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    tiles[x, y] = temp;
                }
            }
        }
    }

    /// <summary>
    /// sets the connections of each array space
    /// </summary>
    public void SetConnections()
    {
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                if(tiles[x, y] != null)
                {
                    if(y < 5)
                        tiles[x, y].GetComponent<TileConnections>().SetConnectionUp(tiles[x, y + 1]);

                    if (y > 0)
                        tiles[x, y].GetComponent<TileConnections>().SetConnectionDown(tiles[x, y - 1]);

                    if (x > 0)
                        tiles[x, y].GetComponent<TileConnections>().SetConnectionLeft(tiles[x - 1, y]);

                    if (x < 5)
                        tiles[x, y].GetComponent<TileConnections>().SetConnectionRight(tiles[x + 1, y]);
                }
            }
        }
    }

    /// <summary>
    /// returns the array of tiles
    /// </summary>
    /// <returns>tiles</returns>
    public GameObject[,] GetArray()
    {
        return tiles;
    }
}
