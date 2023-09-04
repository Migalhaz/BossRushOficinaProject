using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GenericBullet
{
    [SerializeField] Trigger.System2D.CircleTrigger2D m_circleTrigger;

    protected override void Update()
    {
        base.Update();
        CollisionCheck();
    }

    void CollisionCheck()
    {
        IDamage diable = m_circleTrigger.InTrigger<IDamage>(gameObject.transform.position);
        if (diable is null) return;
        diable.Damage(m_weaponScriptableObject.m_BulletDamage);
    }

    private void OnDrawGizmos()
    {
        m_circleTrigger.DrawTrigger(transform.position);
    }
}
