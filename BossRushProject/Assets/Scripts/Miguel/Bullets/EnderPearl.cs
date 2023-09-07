using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnderPearl : GenericBullet
{
    [SerializeField, Min(0)] float m_minDistanceToTp;
    [SerializeField] Transform m_tpPoint;
    [SerializeField] Trigger.System2D.CircleTrigger2D m_trigger;

    protected override void Update()
    {
        base.Update();
        m_trigger.InTrigger(transform.position);
    }

    public void Teleport()
    {
        PlayerManager player = PlayerManager.Instance;
        if (Vector2.Distance(player.transform.position, m_tpPoint.position) <= m_minDistanceToTp) return;
        player.transform.position = m_tpPoint.position;
    }

    private void OnDrawGizmos()
    {
        m_trigger.DrawTrigger(transform.position);
    }
}
