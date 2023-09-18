using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttackRaphael : MonoBehaviour
{
    public EstadosBossRaphael estadoBoss;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("update no estado 1");
    }
    void UpdateEstadoDois()
    {
        Debug.Log("update no estado 2");
    }
}
public enum EstadosBossRaphael
{
    Estado1, Estado2
}