using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OVRController : MonoBehaviour
{
    public float distance = 10.0f;
    public LineRenderer lineRenderer = null;
    public LayerMask everythingMask = 0;
    public LayerMask interactableMask = 0;

    public UnityAction<Vector3, GameObject> OnPointerUpdate = null; 

    private Transform CurrentOrigin = null;
    public GameObject CurrentObject = null;
    public GameObject selectedObject = null; 

    public bool pickedUp;
    
    /// <summary>
    /// on initialisation 
    /// </summary>
    private void Awake()
    {
        PlayerEvents.OnControllerSource += UpdateOrigin;
        PlayerEvents.OnTouchpadDown += ProcessTouchpadDown;
    }

    /// <summary>
    /// on the object being destroyed it will call this function
    /// </summary>
    private void OnDestroy()
    {

        PlayerEvents.OnControllerSource -= UpdateOrigin;
        PlayerEvents.OnTouchpadDown -= ProcessTouchpadDown;
    }
    
    /// <summary>
    /// Update is called once per frame 
    /// </summary>
    private void Update()
    {
        Vector3 hitPoint = UpdateLine();

        CurrentObject = UpdatePointerStatus();
        if (OnPointerUpdate != null)
            OnPointerUpdate(hitPoint, CurrentObject);
    }

    /// <summary>
    /// Updates the lines position based on the raycast from the controller and returns the end position of the raycast
    /// </summary>
    /// <returns>endPosition</returns>
    private Vector3 UpdateLine()
    {
        RaycastHit hit = CreateRaycast(everythingMask);
        Vector3 endPosition = CurrentOrigin.position + (CurrentOrigin.forward * distance);
        if(hit.collider != null)
            endPosition = hit.point; 
        
        lineRenderer.SetPosition(0, CurrentOrigin.position);
        lineRenderer.SetPosition(1, endPosition);

        return endPosition;
    }

    /// <summary>
    /// Updates the start of the line based on the controller's location
    /// </summary>
    /// <param name="controller">OVRInput.Controller</param>
    /// <param name="controllerObject">GameObject</param>
    private void UpdateOrigin(OVRInput.Controller controller, GameObject controllerObject)
    {
        CurrentOrigin = controllerObject.transform;
    }

    /// <summary>
    /// Checks to see what object the raycast is hitting and if you can interact with the object it shall return it
    /// </summary>
    /// <returns>The gameobject the raycast hits or null</returns>
    private GameObject UpdatePointerStatus()
    {
        RaycastHit hit = CreateRaycast(interactableMask);

        if (hit.collider)
            return hit.collider.gameObject;

        return null; 
    }

    /// <summary>
    /// Creates the raycast and returns what the raycast hits
    /// </summary>
    /// <param name="layer"> int</param>
    /// <returns>what the raycast hits</returns>
    private RaycastHit CreateRaycast(int layer)
    {
        RaycastHit hit;
        Ray ray = new Ray(CurrentOrigin.position, CurrentOrigin.forward);
        Physics.Raycast(ray, out hit, distance, layer);

        return hit;
    }

    /// <summary>
    /// if the controller trigger is down it will check to see if it can interact with object the raycast is hitting
    /// </summary>
    private void ProcessTouchpadDown()
    {
        if (!CurrentObject)
            return; 

        Interactable interactable = CurrentObject.GetComponent<Interactable>();
        
        if (!pickedUp && CurrentObject.tag == "Moveable")
        {
            interactable.PickUp(this.gameObject);
            selectedObject = CurrentObject;
            pickedUp = true;
        }
        else
        {
            RaycastHit hit = CreateRaycast(everythingMask);
            interactable.PutDown(hit.transform.gameObject, selectedObject);
            selectedObject = null; 
            pickedUp = false;
        }
    }
}