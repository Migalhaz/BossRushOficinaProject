using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabrielaBoss_Lifesistem : GenericLifeSystem, IDie
{
    public Gabriela_Estados EstadosBoss;
    
    
    void Start()
    {
        m_currentHp = m_hpRange.m_MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        m_currentHp -= damage;
        if(m_currentHp <= m_hpRange.m_MinValue)
        {
            Death();
        }

        if (m_currentHp <= m_hpRange.m_MaxValue * 0.5f )
        {
            EstadosBoss.EstadoAtual = EstadosBossGabriela.vidaAcabando;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
