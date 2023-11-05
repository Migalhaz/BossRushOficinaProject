using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttackRaphael : MonoBehaviour
{
    public EstadosBossRaphael estadoBoss;
    private Transform playerTransform;
    public Transform aim;
    private bossHealthRaphael bossHealthRaphael;
    public GameObject bullet;
    public Animator anim;
    public Transform firePoint;
    

    [Header("Configurações Estado 1")]
    public float timeForFirstAttack;
    public int shots;
    public float angleShotBreak;
    public float attackCooldown;
    public float waveAttackCooldown;
    private float waveCooldownTimer;
    public int waveCounter;
    private bool attacking;
    [Header("Configurações Estado 2")]
    public float timerToAttack2State;
    private float currentTimerToAttack;


    void Start()
    {
        bossHealthRaphael = GetComponent<bossHealthRaphael>();
        playerTransform = PlayerManager.Instance.transform;
        waveCooldownTimer = waveAttackCooldown;
        currentTimerToAttack = timerToAttack2State;
        bossHealthRaphael.canTakeDamage = true;
        anim = GetComponent<Animator>();
        firePoint = aim.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Horizontal", firePoint.position.x);
        anim.SetFloat("Vertical", firePoint.position.y);
        switch (estadoBoss)
        {
            case EstadosBossRaphael.Estado1:
                UpdateEstadoUm();
                break;
            case EstadosBossRaphael.Estado2:
                UpdateEstadoDois();
                break;
        }
    }

    void UpdateEstadoUm()
    {
        if (WaveCooldownTimer())
        {
            StartCoroutine(FirstStateAttack());
            waveCooldownTimer = waveAttackCooldown;
        }
        bool WaveCooldownTimer()
        {
            if(attacking == true){
                return false;
            }
            waveCooldownTimer -= Time.deltaTime;
            return waveCooldownTimer <= 0;
        }
    }
    void UpdateEstadoDois()
    {
        bossHealthRaphael.canTakeDamage = true;
        LookToPlayer();
        if (TimerToShoot())
        {
            Shoot();
            currentTimerToAttack = timerToAttack2State;
        }

        bool TimerToShoot()
        {
            currentTimerToAttack -= Time.deltaTime;
            return currentTimerToAttack <= 0;
        }
    }

    void LookToPlayer()
    {
        Vector3 aimDirection =  playerTransform.position - transform.position;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        aim.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, aim.rotation);

        
    }

    

    IEnumerator FirstStateAttack()
    {
        attacking = true;
        anim.SetBool("isAttacking", true);
        float startAngle = Random.Range(0, 360);
        bossHealthRaphael.canTakeDamage = false;
        for (int i = 0; i < waveCounter; i++)
        {
            int direction = 1;

            if (Random.value <= 0.5f)
            {
                direction = -1;
            }

            for (int j = 0; j < shots; j++)
            {
                aim.rotation = Quaternion.Euler(0f, 0f, angleShotBreak * j * direction + startAngle);
                Shoot();
                yield return new WaitForSeconds(timeForFirstAttack);
            }

            
            yield return new WaitForSeconds(attackCooldown);
        }
        bossHealthRaphael.canTakeDamage = true;
        attacking = false;
        anim.SetBool("isAttacking", false);
    }
}
public enum EstadosBossRaphael
{
    Estado1, Estado2
}