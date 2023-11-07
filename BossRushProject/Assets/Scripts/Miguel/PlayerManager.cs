using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] PlayerMove m_playerMove;
    [SerializeField] PlayerAim m_playerAim;
    [SerializeField] PlayerInputs m_playerInputs;
    [SerializeField] PlayerLifeSystem m_playerLifeSystem;
    [SerializeField] Shield m_playerShield;
    public PlayerMove m_PlayerMove => m_playerMove;
    public PlayerInputs m_PlayerInputs => m_playerInputs;
    public PlayerAim m_PlayerAim => m_playerAim;
    public PlayerLifeSystem m_PlayerLifeSystem => m_playerLifeSystem;
    public Shield m_PlayerShield => m_playerShield;


    protected override void Awake()
    {
        base.Awake();
        m_playerMove ??= GetComponent<PlayerMove>();
        m_playerInputs ??= GetComponent<PlayerInputs>();
        m_playerAim ??= GetComponent<PlayerAim>();
        m_playerLifeSystem ??= GetComponent<PlayerLifeSystem>();
        m_playerShield ??= GetComponent<Shield>();
    }

    public void EnableShield() => m_playerShield.EnableShield();
    public void DisableShield() => m_playerShield.DisableShield();
}
