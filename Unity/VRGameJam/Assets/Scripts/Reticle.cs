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

    // Start is called before the first frame update
    void Awake()
    {
        pointer.OnPointerUpdate += UpdateSprite;

        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_Camera.gameObject.transform);
    }

    private void OnDestroy()
    {
        pointer.OnPointerUpdate -= UpdateSprite;
    }

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
