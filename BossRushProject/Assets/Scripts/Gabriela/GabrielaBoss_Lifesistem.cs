using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabrielaBoss_Lifesistem : MonoBehaviour, IDie
{
    public Gabriela_Estados EstadosBoss;
    public LevelManager levelManager;
    
    public float VidaAtual;

    private float VidaMaxima;
    
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
            EstadosBoss.EstadoAtual = EstadosBossGabriela.vidaAcabando;
        }
        if (VidaAtual <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        levelManager.LoadNextScene();
        Destroy(gameObject);
    }
}
