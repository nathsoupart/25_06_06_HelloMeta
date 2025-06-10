using UnityEngine;
using UnityEngine.Events;


public class ExPinchMono_AngleRangeToPercent11 : MonoBehaviour
{
    public float m_angleRange = 180f;
    public float m_percent = 0f;
    public bool m_clampTheAngle = true;

    public UnityEvent<float> m_onPercentRelayed; // diffuse a qqun autre
    public bool m_inversePercent = false;
    // donne une valeur
    public void PushIn(float angle)
    {
        float percent = angle / m_angleRange;
        if (m_clampTheAngle)
        {
            percent = Mathf.Clamp(percent, -1, 1);
        }

        if (m_inversePercent)
        {
            percent = -percent;
        }
        m_percent = percent;
        m_onPercentRelayed?.Invoke(m_percent);
    }
}

