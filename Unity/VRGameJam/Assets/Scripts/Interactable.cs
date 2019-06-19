using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    /// <summary>
    /// this is called once the trigger on the controller has been pressed
    /// </summary>
    public void Pressed()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        bool flip = !renderer.enabled;

        renderer.enabled = flip; 
    }

    /// <summary>
    /// if you pull the trigger on a moveable object you will be able to pick it up
    /// </summary>
    /// <param name="target">GameObject</param>
    public void PickUp(GameObject target)
    {
        this.gameObject.GetComponent<Placing>().PickUpFromTile();
        this.transform.position = target.transform.position + new Vector3(0.5f, 1.0f, 1.0f);
    }

    /// <summary>
    /// if the trigger is pulled when you are holding a moveable object and looking at a tile you are able to place the object on the tile
    /// </summary>
    /// <param name="target">GameObject</param>
    /// <param name="selected">GameObject</param>
    public void PutDown(GameObject target, GameObject selected)
    {
        if(selected.GetComponent<Placing>() != null)
        {
            if(!selected.GetComponent<Placing>().GetInUse())
            {
                target.GetComponent<Useable>().SetInUse(true);
                selected.GetComponent<Placing>().inUse(target.gameObject);
                selected.transform.position = target.transform.position;
            }
        }
    }
}
