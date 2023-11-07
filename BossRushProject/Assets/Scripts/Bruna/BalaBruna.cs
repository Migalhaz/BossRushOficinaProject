using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBruna : MonoBehaviour
{
    private Transform PlayerTransform;
    public float VelocidadeDaBala;
    public float TempoDeVida;
    public int DanoDoTiro;
    
    
    void Start()
    {
        PlayerTransform = PlayerManager.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        MirarNoPlayer();
        transform.Translate(  VelocidadeDaBala * Time.deltaTime * Vector3.right);
        TempoDeVida -= Time.deltaTime;
        if (TempoDeVida <= 0)
        {
            Destroy(gameObject);
        }
    }
    void MirarNoPlayer()
    {
        Vector3 DirecaoDoTiro =  PlayerTransform.position - transform.position;

        float AnguloDoTiro = Mathf.Atan2(DirecaoDoTiro.y, DirecaoDoTiro.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, AnguloDoTiro );
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<IDamage>().Damage(DanoDoTiro);
            Destroy(gameObject);
        }
    }
}
