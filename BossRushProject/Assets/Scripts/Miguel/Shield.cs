using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] bool m_active;
    [SerializeField] SpriteRenderer m_shieldSpriteRenderer;
    [SerializeField, Min(0)] float m_timeToActive;
    float m_currentTimer;
    public bool m_Active => m_active;

    void Update()
    {
        m_shieldSpriteRenderer.enabled = m_active;
        ShieldReactiveLogic();
    }

    void ShieldReactiveLogic()
    {
        if (m_active) return;
        if (ShieldTimerDecrease())
        {
            ShieldResetTimer();
            SetShieldActive(true);
        }
    }

    bool ShieldTimerDecrease()
    {
        m_currentTimer -= Time.deltaTime;
        return m_currentTimer <= 0;
    }

    void ShieldResetTimer()
    {
        m_currentTimer = m_timeToActive;
    }

    public void SetShieldActive(bool value)
    {
        m_active = value;
    }

}
