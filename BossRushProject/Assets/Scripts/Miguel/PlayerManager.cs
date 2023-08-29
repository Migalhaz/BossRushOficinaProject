using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    Camera m_mainCamera;
    [SerializeField] PlayerMove m_playerMove;
    [SerializeField] PlayerInputs m_playerInputs;

    public Camera m_MainCamera
    {
        get
        {
            if (m_mainCamera is null)
            {
                m_mainCamera = Camera.main;
            }
            return m_mainCamera;
        }
    }
    public PlayerMove m_PlayerMove => m_playerMove;
    public PlayerInputs m_PlayerInputs => m_playerInputs;


    protected override void Awake()
    {
        base.Awake();
        m_playerMove ??= GetComponent<PlayerMove>();
        m_playerInputs ??= GetComponent<PlayerInputs>();
    }
}
