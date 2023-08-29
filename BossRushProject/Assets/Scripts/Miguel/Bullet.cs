using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    WeaponScriptableObject m_weaponScriptableObject;
    [SerializeField] Trigger.System2D.CircleTrigger2D m_circleTrigger;
    public void Init(WeaponScriptableObject weaponScriptableObject)
    {
        m_weaponScriptableObject = weaponScriptableObject;
        Invoke(nameof(KillBullet), weaponScriptableObject.m_BulletLifeTime);
    }
    private void Update()
    {
        transform.Translate(m_weaponScriptableObject.m_CurrentBulletSpeed * Vector3.right);
        CollisionCheck();
    }
    public void KillBullet()
    {
        Destroy(gameObject);
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
