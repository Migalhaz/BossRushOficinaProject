using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerAim : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] WeaponScriptableObject m_currentWeapon;
    [SerializeField] WeaponScriptableObject m_tpWeapon;
    [SerializeField, Min(1)] float m_fireRateMultiplier;
    float m_currentWeaponFireRate;
    float m_tpWeaponFireRate;

    [Header("Aim Settings")]
    [SerializeField] PlayerInputs m_playerInputs;
    [SerializeField] Transform m_aim;
    [SerializeField] Transform m_firepoint;
    Vector2 m_aimDirection;
    float m_aimAngle;
    public Vector2 m_AimDirection => m_aimDirection;
    public float m_AimAngle => m_aimAngle;

    private void Awake()
    {
        m_currentWeaponFireRate = 0f;
    }
    private void Update()
    {
        FireRateSet();
    }

    void FixedUpdate()
    {
        Aim();
    }

    void Aim()
    {
        m_aimDirection = m_playerInputs.MouseWorldPosition() - m_aim.position;
        m_aimAngle = Mathf.Atan2(m_aimDirection.y, m_aimDirection.x) * Mathf.Rad2Deg;
        m_aim.rotation = Quaternion.Euler(0f, 0f, m_aimAngle);
    }

    void FireRateSet()
    {
        m_currentWeaponFireRate -= Time.deltaTime;
        m_tpWeaponFireRate -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (m_currentWeaponFireRate > 0) return;
        m_currentWeapon.Shoot(m_firepoint, m_aim.rotation);
        ResetCurrentWeaponFireRate();
    }

    void SetCurrentWeapon()
    {

    }

    void ResetCurrentWeaponFireRate()
    {
        m_currentWeaponFireRate = Mathf.Abs((m_currentWeapon.m_FireRate - 1) * m_fireRateMultiplier);
    }

    public void TpWeapon()
    {
        if (m_tpWeapon is null) return;
    }
}
