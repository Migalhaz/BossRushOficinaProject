using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class GenericLifeSystem : MonoBehaviour
{
    [Header("Life System")]
    [SerializeField] protected IntRange m_hpRange;
    [SerializeField] protected float m_currentHp;
    [SerializeField] protected UnityEvent OnHpMin;
    [SerializeField] protected UnityEvent OnHpMax;
    [SerializeField] protected UnityEvent OnHpChange;
}

interface IDamage 
{
    public void Damage(float damage);
}

interface IHeal
{
    public void Heal(float heal);
}

interface IDie : IDamage
{
    public void Death();
}

[System.Serializable]
public struct IntRange
{
    [SerializeField] int m_minValue;
    [SerializeField] int m_maxValue;
    public int m_MinValue => m_minValue;
    public int m_MaxValue => m_maxValue;
    public int GetRandomValue(bool _maxInclusive = false)
    {
        return Random.Range(m_minValue, m_maxValue + (_maxInclusive ? 1 : 0));
    }
    public bool InRange(float value)
    {
        return value >= m_minValue && value <= m_maxValue;
    }
    public void ChangeMinValue(int newValue)
    {
        m_minValue = newValue;
    }
    public void ChangeMaxValue(int newValue)
    {
        m_maxValue = newValue;
    }
}