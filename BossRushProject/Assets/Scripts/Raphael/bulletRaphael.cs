using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletRaphael : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
}
