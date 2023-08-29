using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] PlayerMove m_playerMove;
    [SerializeField] PlayerInputs m_playerInputs;

    public PlayerMove m_PlayerMove => m_playerMove;
    public PlayerInputs m_PlayerInputs => m_playerInputs;

    protected override void Awake()
    {
        base.Awake();
        m_playerMove ??= GetComponent<PlayerMove>();
        m_playerInputs ??= GetComponent<PlayerInputs>();
    }
}
