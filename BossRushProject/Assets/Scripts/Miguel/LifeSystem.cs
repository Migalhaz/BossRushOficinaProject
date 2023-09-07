using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class GenericLifeSystem : MonoBehaviour
{
    [Header("Life System")]
    [SerializeField] protected MigalhaSystem.Extensions.IntRange m_hpRange;
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