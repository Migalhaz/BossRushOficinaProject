using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericBullet : MonoBehaviour
{
    protected WeaponScriptableObject m_weaponScriptableObject;
    [SerializeField] SpriteRenderer m_spriteRenderer;
    public virtual void Init(WeaponScriptableObject weaponScriptableObject)
    {
        m_spriteRenderer ??= GetComponent<SpriteRenderer>();
        m_weaponScriptableObject = weaponScriptableObject;
        Invoke(nameof(KillBullet), weaponScriptableObject.m_BulletLifeTime);
        m_spriteRenderer.sprite = weaponScriptableObject.m_BulletSprite;
    }
    protected virtual void Update()
    {
        transform.Translate(m_weaponScriptableObject.m_CurrentBulletSpeed * Vector3.right);
    }
    public void KillBullet()
    {
        Destroy(gameObject);
    }
}
