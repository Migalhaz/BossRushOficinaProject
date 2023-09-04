using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLifeSystem : GenericLifeSystem, IDamage
{
    [SerializeField] UnityEvent OnDie;
    [SerializeField] UnityEvent OnTakeDamage;
    [SerializeField] Shield m_playerShield;

    private void Awake()
    {
        m_playerShield ??= GetComponent<Shield>();
    }

    public void Damage(float damage)
    {
        if (m_playerShield.m_Active)
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
    }

    public void Death()
    {
        OnDie?.Invoke();
    }
}
