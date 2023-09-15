using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [ContextMenuItem("Enable Shield", nameof(EnableShield))]
    [ContextMenuItem("Disable Shield", nameof(DisableShield))]
    [SerializeField] bool m_active;
    [SerializeField] SpriteRenderer m_shieldSpriteRenderer;
    [SerializeField, Min(0)] float m_timeToActive;
    float m_currentTimer;
    public bool m_Active => m_active;
    void Update()
    {
        ShieldReactivateLogic();
    }

    void ShieldReactivateLogic()
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
        m_shieldSpriteRenderer.enabled = value;
    }

    void SetupShield(bool active)
    {
        SetShieldActive(active);
        ShieldResetTimer();
        enabled = active;
    }


    [ContextMenu("Enable Shield")]
    public void EnableShield()
    {
        SetupShield(true);
    }

    [ContextMenu("Disable Shield")]
    public void DisableShield()
    {
        SetupShield(false);
    }
}
