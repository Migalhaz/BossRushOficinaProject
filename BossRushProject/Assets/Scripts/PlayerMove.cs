using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerInputs m_playerInputs;
    [SerializeField] Rigidbody2D m_rig;
    [SerializeField, Min(0)] float m_moveSpeed;
    [SerializeField, Min(0)] float m_dashTimer;
    float m_currentDashTimer;
    [SerializeField, Min(0)] float m_dashForce;

    private void Start()
    {
        ResetDashTimer();
    }

    private void Update()
    {
        DashTimer();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        m_rig.velocity += m_moveSpeed * Time.fixedDeltaTime * m_playerInputs.m_MoveDir;
    }

    void ResetDashTimer()
    {
        m_currentDashTimer = m_dashTimer;
    }

    void DashTimer()
    {
        m_currentDashTimer -= Time.deltaTime;
    }

    public void Dash()
    {
        if (m_playerInputs.m_MoveDir.magnitude == 0) return;
        if (m_currentDashTimer > 0) return;
        ResetDashTimer();
        m_rig.AddForce(m_playerInputs.m_MoveDir * m_dashForce, ForceMode2D.Impulse);
    }

    public bool Moving()
    {
        return m_playerInputs.m_MoveDir != Vector2.zero;
    }
}
