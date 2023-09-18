using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBossBruna : MonoBehaviour, IDie
{
    public float VidaAtual;

    private float VidaMaxima;

    public EstadoBossBruna EstadoDoBoss;
    // Start is called before the first frame update
    void Start()
    {
        VidaMaxima = VidaAtual;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        VidaAtual -= damage;
        if (VidaAtual <= VidaMaxima * 0.5f)
        {
            EstadoDoBoss.EstadoBoss = EstadosBossBruna.Estado2;
        }
        if (VidaAtual <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
