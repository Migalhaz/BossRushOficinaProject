using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnderPearl : GenericBullet
{
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
        player.transform.position = m_tpPoint.position;
    }

    private void OnDrawGizmos()
    {
        m_trigger.DrawTrigger(transform.position);
    }
}
