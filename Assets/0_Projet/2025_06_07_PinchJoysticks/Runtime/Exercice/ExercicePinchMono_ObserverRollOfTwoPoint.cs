using UnityEngine;
using UnityEngine.Events;

public class ExercicePinchMono_ObserverRollOfTwoPoint : MonoBehaviour
{
    public Transform m_leftpoint;
    public Transform m_rightpoint;

    public float m_rollAngle;

    public UnityEvent<float> m_onRollAngleChanged;
    public bool m_onlyOnChanged = true;

    void Awake()
    {
        ComputeTheRoll(); // calcul quand on arrive
    }

    void Update()
    {
        ComputeTheRoll();
    }

    private void ComputeTheRoll()
    {

        Vector3 origin = m_leftpoint.position;
        Vector3 destination = m_rightpoint.position;
        // calcul de direction entre deux axes
        Vector3 direction = destination - origin;
        //cross product allows (permet) to find the axis between two vectors ! sens des axes (,)
        Vector3 up = Vector3.up;
        Vector3 forward = Vector3.Cross(direction, up);
        Vector3 right = Vector3.Cross(up, forward);
        // To have the middle point we can add the two vectors and divide by two
        Vector3 middlePoint = (origin + destination) / 2f;
        // evite d'agrandir ou retisser les lignes en fonction des distances reste entre 0 et 1
        up.Normalize();
        forward.Normalize();
        right.Normalize();


        //creer une ligne dans la direction
        float drawDistance = .05f;
        //Debug.DrawLine(origin, origin + destination, Color.red);
        Debug.DrawLine(middlePoint, middlePoint + forward * drawDistance, Color.blue);
        Debug.DrawLine(middlePoint, middlePoint + up * drawDistance, Color.green);
        Debug.DrawLine(middlePoint, middlePoint + right * drawDistance, Color.red);
        // dessiner la direction  et normalise
        Debug.DrawLine(middlePoint, middlePoint + direction.normalized * drawDistance, Color.red);
        //Calcul l'angle entre la direction et l'axe Unity à une méthode calcul angle depuis ou vers ou et donne axe pour s'orienter
        // stocker la valeur
        float rollAngle = Vector3.SignedAngle(right, direction, forward);
        if (m_onlyOnChanged && rollAngle != m_rollAngle) //si changement et pas egale à l'angle alors
        {
            m_rollAngle = rollAngle;
            m_onRollAngleChanged?.Invoke(rollAngle);
            return;
        }

        m_rollAngle = rollAngle;
        // ? pour  if(m_onRollAngleChanged != null)
           m_onRollAngleChanged?.Invoke(rollAngle);
    }
    // recoit l'angle et doit convertir en % (clamper)
    
}