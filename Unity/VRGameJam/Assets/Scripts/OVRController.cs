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

    private void Awake()
    {
        PlayerEvents.OnControllerSource += UpdateOrigin;
        PlayerEvents.OnTouchpadDown += ProcessTouchpadDown;
    }

    // Start is called before the first frame update
    private void Start()
    {
        SetLineColour();
    }

    private void OnDestroy()
    {

        PlayerEvents.OnControllerSource -= UpdateOrigin;
        PlayerEvents.OnTouchpadDown -= ProcessTouchpadDown;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 hitPoint = UpdateLine();

        CurrentObject = UpdatePointerStatus();
        if (OnPointerUpdate != null)
            OnPointerUpdate(hitPoint, CurrentObject);
    }

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

    private void UpdateOrigin(OVRInput.Controller controller, GameObject controllerObject)
    {
        CurrentOrigin = controllerObject.transform;
        print(CurrentOrigin);

        if(controller == OVRInput.Controller.Touchpad)
        {
            lineRenderer.enabled = false;
        }
        else
        {
            lineRenderer.enabled = true; 
        }
    }

    private GameObject UpdatePointerStatus()
    {
        RaycastHit hit = CreateRaycast(interactableMask);

        if (hit.collider)
            return hit.collider.gameObject;

        return null; 
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
            return; 
        Color endColour = Color.white;
        endColour.a = 0.0f;
        lineRenderer.endColor = endColour;
    }
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