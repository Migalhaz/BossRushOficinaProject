using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealthRaphael : MonoBehaviour, IDie
{

    public float health;
    public bool canTakeDamage;
    public bossAttackRaphael attackBoss;
    private float maxHealth;

    public void Damage(float damage)
    {
        
        if (canTakeDamage)
        {
            health -= damage;
            if (health <= maxHealth * 0.5f)
            {
                attackBoss.estadoBoss = EstadosBossRaphael.Estado2;
            }
            if (health <= 0)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
