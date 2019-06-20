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

    private void Update()
    {
        MakeStartEndSpaces(); 
    }

    public void MakeStartEndSpaces()
    {
        startTile = tileHolder.GetComponent<Connections>().GetArray(xPosInGridStart, yPosInGridStart);
        StartPiece.transform.position = startTile.transform.position;

        endTile = tileHolder.GetComponent<Connections>().GetArray(xPosInGridEnd, yPosInGridEnd);
        EndPiece.transform.position = endTile.transform.position;
    }

}
