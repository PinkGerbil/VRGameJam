using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connections : MonoBehaviour
{
    public Canvas tileHolder;
    public GameObject[,] tiles = new GameObject[6,6];

    private int i;

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

        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                GameObject temp = tileHolder.transform.GetChild(i).gameObject;
                tiles[x, y] = temp;
                i++;
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
    /// <returns>the tiles array</returns>
    public GameObject GetArray(int x, int y)
    {
        return tiles[x, y];
    }
}
