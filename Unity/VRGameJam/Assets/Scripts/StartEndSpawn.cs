using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEndSpawn : MonoBehaviour
{
    public Canvas tileHolder; 
    
    public GameObject StartPiece;
    public GameObject EndPiece;

    public GameObject startTile;
    public GameObject endTile;

    public int xPosInGridStart;
    public int yPosInGridStart;

    public int xPosInGridEnd;
    public int yPosInGridEnd;

    /// <summary>
    /// calls this function once a frame
    /// </summary>
    private void Update()
    {
        MakeStartEndSpaces(); 
    }

    /// <summary>
    /// Spawns the start and end places on the grid
    /// </summary>
    public void MakeStartEndSpaces()
    {
        startTile = tileHolder.GetComponent<Connections>().GetArray(xPosInGridStart, yPosInGridStart);
        startTile.GetComponent<TileConnections>().SetPipeCon(StartPiece);
        StartPiece.transform.position = startTile.transform.position;

        endTile = tileHolder.GetComponent<Connections>().GetArray(xPosInGridEnd, yPosInGridEnd);
        endTile.GetComponent<TileConnections>().SetPipeCon(EndPiece);
        EndPiece.transform.position = endTile.transform.position;
    }

}
