using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public OVRController pointer;
    public SpriteRenderer m_circleRenderer;

    public Sprite m_closedSprite;
    public Sprite m_openSprite;

    private Camera m_Camera = null;

    /// <summary>
    /// called once the object is initialised 
    /// </summary>
    void Awake()
    {
        pointer.OnPointerUpdate += UpdateSprite;

        m_Camera = Camera.main;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        transform.LookAt(m_Camera.gameObject.transform);
    }

    /// <summary>
    /// calls this once the object is destroyed
    /// </summary>
    private void OnDestroy()
    {
        pointer.OnPointerUpdate -= UpdateSprite;
    }

    /// <summary>
    /// updates the reticle's sprite based on what it is hitting
    /// </summary>
    /// <param name="point">Vector3</param>
    /// <param name="hitObject">GameObject</param>
    private void UpdateSprite(Vector3 point, GameObject hitObject)
    {
        transform.position = point;

        if (hitObject)
        {
            m_circleRenderer.sprite = m_closedSprite;
        }
        else
        {
            m_circleRenderer.sprite = m_openSprite;
        }

    }
}