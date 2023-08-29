using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLifeSystem : GenericLifeSystem, IDamage
{
    [SerializeField] UnityEvent OnDie;
    [SerializeField] UnityEvent OnTakeDamage;

    public void Damage(float damage)
    {
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
