using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoBossBruna : MonoBehaviour
{
    private Transform playerTransform;
    public Transform aim;
    public EstadosBossBruna EstadoBoss;
    private Transform FirePoint;

    public GameObject Tiro;
    [Header("Estado1")]
    public float TempoParaAtirar;
    private float TempoAtualDoTiro;
    
    [Header("Estado2")]
    public List<Transform> PontoDeTeleporte;

    public float TempoDeTeleporte;
    private float TempoDeTeleporteAtual;
    private Animator anim;
    void Start()
    {
        playerTransform = PlayerManager.Instance.transform;
        FirePoint = aim.GetChild(0);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        UpdateEstado1();

        if (EstadoBoss==EstadosBossBruna.Estado2)
        {
          UpdateEstado2();  
        }
    }

    void MirarNoPlayer()
    {
        Vector3 DirecaoDoTiro =  playerTransform.position - transform.position;

        float AnguloDoTiro = Mathf.Atan2(DirecaoDoTiro.y, DirecaoDoTiro.x) * Mathf.Rad2Deg;

        aim.rotation = Quaternion.Euler(0f, 0f, AnguloDoTiro );
    }

    void UpdateEstado1()
    {
        MirarNoPlayer();
        if (TempoAtualDoTiro>=TempoParaAtirar)
        {
            TempoAtualDoTiro = 0;
            Instantiate(Tiro, FirePoint.position, Quaternion.identity);
        }
        else
        {
            TempoAtualDoTiro += Time.deltaTime;
        }
    }

    void UpdateEstado2()
    {
        if (TempoDeTeleporteAtual>=TempoDeTeleporte)
        {
            TempoDeTeleporteAtual = 0;
            Teleportar();
            anim.SetInteger("Transition", 1 );
        }
        else
        {
            TempoDeTeleporteAtual += Time.deltaTime;
        }
    }

    void Teleportar()
    {
        int IndexPonto= Random.Range(0,PontoDeTeleporte.Count);
        Transform PontoTeleporte = PontoDeTeleporte[IndexPonto];
        transform.position = PontoTeleporte.position;
    }
}

public enum EstadosBossBruna
{
    Estado1, Estado2
}