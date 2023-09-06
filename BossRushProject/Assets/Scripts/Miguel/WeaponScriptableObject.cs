using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponSettings", menuName = "ScriptableObject/Player/New Weapon Settings")]
public class WeaponScriptableObject : ScriptableObject
{
    [Header("Bullet Settings")]
    [SerializeField, Min(1)] float m_bulletSpeed = 10f;
    [SerializeField, Min(0)] float m_bulletDamage = 1f;
    [SerializeField, Min(1)] float m_bulletLifeTime = 5f;
    [SerializeField] Sprite m_bulletSprite;

    [SerializeField] GenericBullet m_bulletPrefab;

    [Header("Weapon Settings")]
    [SerializeField, Range(0, 1)] float m_fireRate;

    public float m_BulletSpeed => m_bulletSpeed;
    public float m_BulletDamage => m_bulletDamage;
    public float m_BulletLifeTime => m_bulletLifeTime;
    public Sprite m_BulletSprite => m_bulletSprite;
    public float m_CurrentBulletSpeed
    {
        get 
        { 
            return m_bulletSpeed * Time.deltaTime;
        }
    }
    public float m_FireRate => m_fireRate;

    public void Shoot(Transform firePoint, Quaternion rotation)
    {
        GenericBullet newBullet = Instantiate(m_bulletPrefab, firePoint.position, rotation);
        newBullet.Init(this);
    }
}
