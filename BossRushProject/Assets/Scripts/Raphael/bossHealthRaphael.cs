using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossHealthRaphael : MonoBehaviour, IDie
{

    public float health;
    public bool canTakeDamage;
    public bossAttackRaphael attackBoss;
    private float maxHealth;
    public LevelManager levelManager;

    public Image bossHealthBar;

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
        bossHealthBar.fillAmount = health / maxHealth;
    }

    public void Death()
    {
        levelManager.LoadNextScene();
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
