using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] PlayerLifeSystem m_playerLifeSystem;
    [SerializeField] List<RawImage> m_hearts;


    public void UpdateHearts()
    {
        for (int i = 0; i < m_hearts.Count; i++)
        {
            m_hearts[i].gameObject.SetActive(i < m_playerLifeSystem.m_CurrentHp);
        }
    }
}
