using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabriela_Estados : MonoBehaviour
{
    public EstadosBossGabriela EstadoAtual;
    public float velocidadeRotacao;

    public List<Transform> firepoints;
    public float BossSpeed;
    public float TempoParatiro;
    private float TempoAtualDoTiro;
    public GameObject Tiro;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        updateEstado1();
        if (EstadoAtual == EstadosBossGabriela.vidaAcabando)
        {
            updateEstado2();
        }
    }

    void updateEstado1()
    {
        transform.Rotate(velocidadeRotacao * Time.deltaTime * Vector3.forward);
        if (TempoAtualDoTiro>=TempoParatiro)
        {
            TempoAtualDoTiro = 0;
            foreach (Transform firepoint in firepoints)
            {
                Instantiate(Tiro, firepoint.position, firepoint.rotation);
            }
        }
        else
        {
            TempoAtualDoTiro += Time.deltaTime;
        }
    }

    void updateEstado2()
    {
        Vector3 target = PlayerManager.Instance.transform.position;
        transform.position = Vector3.Lerp(transform.position, target, BossSpeed * Time.deltaTime);
    }
}

public enum EstadosBossGabriela
{
    vidaCheia, vidaAcabando
    
}