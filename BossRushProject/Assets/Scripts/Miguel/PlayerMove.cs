using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerInputs m_playerInputs;
    [SerializeField] Rigidbody2D m_rig;
    [SerializeField] PlayerSound m_playerSound;
    [SerializeField, Min(0)] float m_moveSpeed;
    [SerializeField, Min(0)] float m_rollTimer;
    [SerializeField, Min(0)] float m_rollDuration;
    float m_currentRollTimer;
    [SerializeField, Min(0)] float m_rollForce;
    public bool m_Rolling { get; private set; }
    public bool m_Moving => m_playerInputs.m_MoveDir.sqrMagnitude > 0;

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
        m_currentRollTimer = m_rollTimer;
    }

    void DashTimer()
    {
        m_currentRollTimer -= Time.deltaTime;
    }

    public void Dash()
    {
        if (m_playerInputs.m_MoveDir.magnitude == 0) return;
        if (m_currentRollTimer > 0) return;
        StartCoroutine(RollDuration());
        ResetDashTimer();
        m_playerSound.PlayDashSound();
        m_rig.AddForce(m_playerInputs.m_MoveDir * m_rollForce, ForceMode2D.Impulse);
    }

    IEnumerator RollDuration()
    {
        m_Rolling = true;
        yield return MigalhaSystem.Extensions.MigalhazHelper.GetWaitForSeconds(m_rollDuration);
        m_Rolling = false;
    }

    public bool Moving()
    {
        return m_playerInputs.m_MoveDir != Vector2.zero;
    }
}
