using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRController : MonoBehaviour
{
    public float distance = 10.0f;
    public LineRenderer lineRenderer = null;
    public LayerMask everythingMask = 0;
    public LayerMask interactableMask = 0;

    private Transform CurrentOrigin; 

    // Start is called before the first frame update
    private void Start()
    {
        SetLineColour();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 hitPoint = UpdateLine();
    }

    private Vector3 UpdateLine()
    {
        RaycastHit hit = CreateRaycast(everythingMask);
        Vector3 endPosition = CurrentOrigin.position + (CurrentOrigin.forward * distance);
        if(hit.collider != null)
        {
            endPosition = hit.point; 
        }

        lineRenderer.SetPosition(0, CurrentOrigin.position);
        lineRenderer.SetPosition(1, endPosition);

        return endPosition;
    }

    private void UpdateOrigin(OVRInput.Controller controller, GameObject controllerObject)
    {
        CurrentOrigin = controllerObject.transform;

        if(controller == OVRInput.Controller.Touchpad)
        {
            lineRenderer.enabled = false;
        }
        else
        {
            lineRenderer.enabled = true; 
        }
    }

    private RaycastHit CreateRaycast(int layer)
    {
        RaycastHit hit;
        Ray ray = new Ray(CurrentOrigin.position, CurrentOrigin.forward);
        Physics.Raycast(ray, out hit, distance, layer);

        return hit;
    }

    private void SetLineColour()
    {
        if (!lineRenderer)
        {
            return; 
        }
        Color endColour = Color.white;
        lineRenderer.endColor = endColour;
    }
}
