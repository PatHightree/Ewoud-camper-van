using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ToggleScale : MonoBehaviour
{
    public Transform Target;
    public Vector3 Scale1;
    public Vector3 Scale2;

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
