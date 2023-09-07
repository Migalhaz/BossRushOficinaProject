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

    private void Awake()
    {
        m_playerShield ??= GetComponent<Shield>();
    }

    public void Damage(float damage)
    {
        if (PlayerRolling()) return;
        if (ShieldActive())
        {
            m_playerShield.SetShieldActive(false);
            return;
        }
        OnHpChange?.Invoke();
        m_currentHp -= damage;
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
