using UnityEngine;
using UnityEngine.Events;

namespace Nathalie
{
    public class PrimitiveToString : MonoBehaviour
    {
        [SerializeField] UnityEvent<string> m_onRelay;
        [SerializeField] private string m_format = "{ 0 }";
        public void Relay(string relay)
        {
            m_onRelay.Invoke(relay);
        }

        public void Relay(float toRelay)
        {
            m_onRelay.Invoke(string.Format(m_format, toRelay));
        }
        // ajouter tous les primitifs
    }
}