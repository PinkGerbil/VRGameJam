using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    #region Events
    public static UnityAction OnTouchpadUp = null;
    public static UnityAction OnTouchpadDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> OnControllerSource = null; 
    #endregion

    #region Anchors
    public GameObject m_LeftAnchor;
    public GameObject m_RightAnchor;
    public GameObject m_HeadAnchor;
    #endregion

    #region Input
    private Dictionary<OVRInput.Controller, GameObject> m_ControllerSets = null;
    private OVRInput.Controller m_inputSource = OVRInput.Controller.None;
    private OVRInput.Controller m_Controller= OVRInput.Controller.None;
    private bool m_InputActive= true;

    #endregion
    /// <summary>
    /// awake is called when the object is first made
    /// </summary>
    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

        m_ControllerSets = CreateControllerSets(); 
    }

    private void OnDestroy()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;
    }

    /// <summary> 
    /// Update is called once per frame 
    /// </summary>
    private void Update()
    {
        if (!m_InputActive)
            return;

        CheckForController();

        checkInputSource();

        Input(); 
    }

    /// <summary>
    /// checks which controller is currently in use
    /// </summary>
    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = m_Controller;

        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            controllerCheck = OVRInput.Controller.RTrackedRemote;
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.LTrackedRemote;
        if (!OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) && !OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.Touchpad;

        m_Controller = UpdateSource(controllerCheck, m_Controller);
    }

    /// <summary>
    /// checks the source of the input
    /// </summary>
    public void checkInputSource()
    {
        m_inputSource = UpdateSource(OVRInput.GetActiveController(), m_inputSource);
    }

    /// <summary>
    /// checks to see what buttons are being pressed
    /// </summary>
    private void Input()
    {
        //trigger down
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if(OnTouchpadDown != null)
            {
                OnTouchpadDown();
            }
        }
        //trigger up
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if(OnTouchpadUp != null)
            {
                OnTouchpadUp();
            }
        }
    }

    /// <summary>
    /// checks the source of the controller
    /// </summary>
    /// <param name="check">OVRInput.Controller</param>
    /// <param name="previous">OVRInput.Controller</param>
    /// <returns>check</returns>
    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous)
    {
        if(check == previous)
            return previous;
        
        GameObject controllerObject = null;
        m_ControllerSets.TryGetValue(check, out controllerObject);

        if (controllerObject == null)
            controllerObject = m_HeadAnchor;

        if (OnControllerSource != null)
            OnControllerSource(check, controllerObject);

        return check; 
    }

    /// <summary>
    /// while the player is connected it will set the input to true
    /// </summary>
    private void PlayerFound()
    {
        m_InputActive = true;
    }

    /// <summary>
    /// if the player disconnects for whatever reason it will set the input to inactive
    /// </summary>
    private void PlayerLost()
    {
        m_InputActive = false;
    }

    private Dictionary<OVRInput.Controller, GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            {OVRInput.Controller.LTrackedRemote, m_LeftAnchor },
            {OVRInput.Controller.RTrackedRemote, m_RightAnchor},
            {OVRInput.Controller.Touchpad, m_HeadAnchor}
        };
        return newSets;
    }
}
