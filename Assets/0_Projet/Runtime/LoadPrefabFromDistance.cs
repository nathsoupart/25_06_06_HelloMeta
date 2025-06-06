using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

[System.Serializable]
public class RangeToCreatePrefab
{
    public string m_levelName;
    public Texture2D m_iconLevel;
    
    public float m_minRange;
    public float m_maxRange;
    public GameObject m_prefab;
}
public class LoadPrefabFromDistance : MonoBehaviour
{   
    [SerializeField] private float m_distance;
    [SerializeField] List<RangeToCreatePrefab> m_ListOfPrefab;
    public UnityEvent<GameObject> m_onPrefabRangeFound;
    public GameObject m_lastPush;
    
    public void SetDistance(float distance)
    {
        m_distance = distance; 
        
    }
    [ContextMenu("TryToCreatePrefab")]
    public void TryToCreatInRange()
    {
        foreach (var item in m_ListOfPrefab)
        {
            if(item == null) continue;
            if (m_distance < item.m_minRange) continue;
            if (m_distance > item.m_maxRange) continue;
            m_onPrefabRangeFound.Invoke(item.m_prefab);
            m_lastPush = item.m_prefab;
        }
        
    }
    
}
