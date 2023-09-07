using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] Animator m_playerAnimator;
    [SerializeField] PlayerAim m_playerAim;
    [SerializeField] PlayerMove m_playerMove;
    void Update()
    {
        SetXY();
        SetMove();
    }

    void SetXY()
    {
        Vector2 aimDirection = m_playerAim.m_AimDirection;
        m_playerAnimator.SetFloat("x", aimDirection.x);
        m_playerAnimator.SetFloat("y", aimDirection.y);
    }

    void SetMove()
    {
        m_playerAnimator.SetBool("Moving", m_playerMove.m_Moving);
    }
}
