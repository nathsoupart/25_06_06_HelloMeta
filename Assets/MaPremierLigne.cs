
using UnityEngine;

public class MaPremierLigne : MonoBehaviour
{
    public Vector3 m_direction;
    public Color m_color;
    public float m_duraction = 3;
    public Transform m_canonDirection;
    public Transform m_canonToMove;
    public float m_leftRightangle;
    public float m_downTopAngle;
    public float m_maxVerticalangle = 20;
    void Start()
    {
        
    }

   
    void Update()
    {   
        if (m_downTopAngle <0) m_downTopAngle = 0;
        if (m_downTopAngle > m_maxVerticalangle) m_downTopAngle = m_maxVerticalangle;
        Debug.DrawLine(Vector3.zero, m_direction, m_color, m_duraction);
        Debug.DrawRay(Vector3.zero, new Vector3(1,0,0), Color.red, Time.deltaTime);
        Debug.DrawRay(Vector3.zero, new Vector3(0,1,0), Color.green, Time.deltaTime);
        Debug.DrawRay(Vector3.zero, new Vector3(0,0,1), Color.blue, Time.deltaTime);
        Vector3 startOfTheCanon = m_canonDirection.position;
        Vector3 endOfTheCanon = startOfTheCanon + m_direction;
        Debug.DrawLine(startOfTheCanon, endOfTheCanon, m_color, Time.deltaTime);
        //Quaternion rotationToApply = Quaternion.LookRotation(m_direction);
        Quaternion horizontalRotation = Quaternion.Euler(0f, m_leftRightangle, 0f);
        Quaternion verticalRotation = Quaternion.Euler(-m_downTopAngle, 0f, 0f);
        Quaternion finalRotation = (m_canonDirection.rotation * horizontalRotation) * verticalRotation;
        m_canonToMove.rotation = finalRotation;
        
        
        
    }
}
