using UnityEngine;
using UnityEngine.Events;

namespace Nathalie
{
    public class DistanceBetweenTwoPointsRelay : MonoBehaviour
    {
        [SerializeField] Transform m_leftHand;
        [SerializeField] Transform m_rightHand;
        [SerializeField]  float m_distanceBetween;
        [SerializeField] UnityEvent <float> m_onDistanceChanged;

        private void OnValidate()
        {
            UpDatePosition();
        }

        private void UpDatePosition()
        {
           // m_distanceBetween = Vector3.Distance(m_leftHand.position, m_rightHand.position);
            var distance = Vector3.Distance(m_leftHand.position, m_rightHand.position);
            if (distance != m_distanceBetween)
            {
                m_distanceBetween = distance;
                m_onDistanceChanged.Invoke(distance);
            }
        }
        void Update()
        {
            UpDatePosition();

        }
    }
}
