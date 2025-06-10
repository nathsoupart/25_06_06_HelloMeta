using UnityEngine;

[ExecuteInEditMode] // update execut in editor pour ne pas toujours le refaire

public class ExPinchMono_RotateWheelWithPercent11 : MonoBehaviour
// create volant car
{
    public Transform m_startDirection;
    public Transform m_wheelToMoveAndRotate;
    public float m_currentpercent11 = 0f;
    public float m_wheelRotationAngle = 180;
    public bool m_useUpdate;
    public bool m_inverseRotation;
    public void SetPercent(float percent11)
    {
        m_currentpercent11 = percent11;
        RefreshPosition();
    }

    public void Update()
    {
        if (m_useUpdate)
        {
            RefreshPosition();
        }
        
    }
    private void RefreshPosition()
    {
        Quaternion startDirectionRotation = m_startDirection.localRotation;// rotation de base
        Quaternion rotationToApply = Quaternion.Euler(0,0, m_currentpercent11* -m_wheelRotationAngle *(m_inverseRotation? -1:1));
        Quaternion targetRotation = startDirectionRotation * rotationToApply;
        
        m_wheelToMoveAndRotate.rotation = targetRotation;
        m_wheelToMoveAndRotate.position = m_startDirection.position;
    }
}