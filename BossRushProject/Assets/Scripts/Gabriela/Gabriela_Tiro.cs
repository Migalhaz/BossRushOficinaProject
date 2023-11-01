using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabriela_Tiro : MonoBehaviour
{
    
    public float speed;
    public float danoDoTiro;

    private void Start()
    {
        Invoke("Death", 5f);
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
    

    public void Death()
    {
        Destroy(gameObject);
    }
   
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<IDamage>().Damage(danoDoTiro);
            Destroy(gameObject);
        }
    }
}
