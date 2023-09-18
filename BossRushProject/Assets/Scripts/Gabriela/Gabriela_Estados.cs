using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabriela_Estados : MonoBehaviour
{
    public EstadosBossGabriela EstadoAtual;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum EstadosBossGabriela
{
    vidaCheia, vidaAcabando
    
}