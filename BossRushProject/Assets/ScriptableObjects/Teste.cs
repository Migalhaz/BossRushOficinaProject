using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    [SerializeField] InputAction m_action1;
    [SerializeField] InputAction m_action2;
    [SerializeField] InputAction m_action3;

    void Start()
    {
        
    }
    void Update()
    {
        m_action1.Action();
        m_action2.Action();
        m_action3.Action();
    }

    public void SetCurrentWeapon(WeaponScriptableObject weaponScriptableObject)
    {
        PlayerManager.Instance.m_PlayerAim.SetCurrentWeapon(weaponScriptableObject);
    }
}
