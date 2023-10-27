using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] bool m_activeUI = true;
    [SerializeField] PlayerLifeSystem m_playerLifeSystem;
    [SerializeField] List<RawImage> m_hearts;


    public void UpdateHearts()
    {
        if (!CanUpdate()) return;
        for (int i = 0; i < m_hearts.Count; i++)
        {
            m_hearts[i].gameObject.SetActive(i < m_playerLifeSystem.m_CurrentHp);
        }

        bool CanUpdate()
        {
            if (m_hearts is null) return false;
            if (m_hearts.Count <= 0) return false;
            return m_activeUI;
        }
    }
}
