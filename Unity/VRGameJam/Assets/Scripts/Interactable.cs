using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Pressed()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        bool flip = !renderer.enabled;

        renderer.enabled = flip; 
    }

    public void PickUp(GameObject target)
    {
        this.transform.position = target.transform.position + new Vector3(1.0f, 0.0f, 1.0f);
    }
    public void PutDown(Vector3 target, GameObject selected)
    {
        selected.transform.position = target;
    }

    public void PutDown(GameObject target, GameObject selected)
    {
        selected.transform.position = target.transform.position;
    }
}
