using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ToggleScale : MonoBehaviour
{
    public Transform Target;
    public Vector3 Scale1;
    public Vector3 Scale2;
    public SteamVR_Action_Boolean plantAction;
    public Hand hand;

    private Vector3 m_initScale;
    private bool m_isScaled;
    
    void Start()
    {
        m_initScale = Target.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Toggle();
    }

    private void OnEnable()
    {
        if (hand == null)
            hand = GetComponent<Hand>();

        if (plantAction == null)
        {
            Debug.LogError("<b>[SteamVR Interaction]</b> No plant action assigned", this);
            return;
        }

        plantAction.AddOnChangeListener(OnToggleActionChange, hand.handType);
    }

    private void OnDisable()
    {
        if (plantAction != null)
            plantAction.RemoveOnChangeListener(OnToggleActionChange, hand.handType);
    }
    private void OnToggleActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
    {
        if (newValue)
        {
            Toggle();
        }
    }
    
    public void Toggle()
    {
        if (m_isScaled)
            Target.localScale = m_initScale;
        else
            Target.localScale = new Vector3(
                ScaleComponent(m_initScale.x, Scale1.x, Scale2.x),
                ScaleComponent(m_initScale.y, Scale1.y, Scale2.y),
                ScaleComponent(m_initScale.z, Scale1.z, Scale2.z)
                );
        m_isScaled = !m_isScaled;
    }

    float ScaleComponent(float _init, float _scale1, float _scale2)
    {
        return _init / _scale1 * _scale2;
    }
}