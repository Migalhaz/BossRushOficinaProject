using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttackRaphael : MonoBehaviour
{
    public EstadosBossRaphael estadoBoss;
    private Transform playerTransform;
    public Transform aim;

    [Header("Configurações Estado 1")]
    public float timeForFirstAttack;
    public int shots;
    public float angleShotBreak;
    public float attackCooldown;
    public float waveAttackCooldown;
    private float waveCooldownTimer;
    public int waveCounter;

    //[Header("Configurações Estado 2")]


    void Start()
    {
        playerTransform = PlayerManager.Instance.transform;
        waveCooldownTimer = waveAttackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
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
            waveCooldownTimer -= Time.deltaTime;
            return waveCooldownTimer <= 0;
        }
    }
    void UpdateEstadoDois()
    {
        Debug.Log("update no estado 2");
        LookToPlayer();
    }

    void LookToPlayer()
    {
        Vector3 aimDirection =  playerTransform.position - transform.position;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        aim.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    [ContextMenu("paulo")]
    void Teste()
    {
        StartCoroutine(FirstStateAttack());
    }

    IEnumerator FirstStateAttack()
    {
        for (int i = 0; i < waveCounter; i++)
        {
            int direction = 1;

            if (Random.value <= 0.5f)
            {
                direction = -1;
            }

            for (int j = 0; j < shots; j++)
            {
                aim.rotation = Quaternion.Euler(0f, 0f, angleShotBreak * j * direction);
                yield return new WaitForSeconds(timeForFirstAttack);
            }
            yield return new WaitForSeconds(attackCooldown);
        }
    }
}
public enum EstadosBossRaphael
{
    Estado1, Estado2
}