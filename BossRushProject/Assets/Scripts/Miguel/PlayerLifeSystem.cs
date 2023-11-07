using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLifeSystem : GenericLifeSystem, IDamage
{
    [SerializeField] UnityEvent OnDie;
    [SerializeField] UnityEvent OnTakeDamage;
    [SerializeField] PlayerMove m_playerMove;
    [SerializeField] Shield m_playerShield;
    public float m_CurrentHp => m_currentHp;

    private void Awake()
    {
        m_playerShield ??= GetComponent<Shield>();
    }
    void Update()
    {
        if (!m_playerShield.enabled)
        {
            m_playerShield.HideShield();
        }
        
    }

    public void Damage(float damage)
    {
        if (PlayerRolling()) return;
        if (ShieldActive())
        {
            m_playerShield.SetShieldActive(false);
            return;
        }
        m_currentHp -= damage;
        OnHpChange?.Invoke();
        OnTakeDamage?.Invoke();
        
        if (m_currentHp <= m_hpRange.m_MinValue)
        {
            OnHpMin?.Invoke();
            Death();
        }

        bool ShieldActive()
        {
            if (m_playerShield.enabled)
            {
                return m_playerShield.m_Active;
            }
            m_playerShield.HideShield();
            return false;
        }

        bool PlayerRolling()
        {
            return m_playerMove.m_Rolling;
        }
    }

    public void Death()
    {
        OnDie?.Invoke();
    }
}
