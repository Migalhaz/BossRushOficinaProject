using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletRaphael : MonoBehaviour
{
    public Trigger.System2D.CircleTrigger2D circleTrigger2D;
    public float speed;
    public float damageValue;

    private void Start()
    {
        Invoke("Death", 5f);
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
    private void FixedUpdate()
    {
        IDamage damage = circleTrigger2D.InTrigger<IDamage>(transform);
        if(damage != null)
        {
            damage.Damage(damageValue);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        circleTrigger2D.DrawTrigger(transform.position);
    }
}
