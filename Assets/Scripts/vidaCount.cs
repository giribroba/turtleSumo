using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaCount : MonoBehaviour
{
    public static bool Morrivel = false;
    public static float Vida;
    public GameObject Turtle;

    void Update()
    {
        if (Morrivel && Vida <= 0)
        {
            Destroy(Turtle);
        }
        else if (Vida >= 100)
        {
            Morrivel = false;
            Vida = 0;
        }
        if (transform.localScale.x < Vida / 25 && Vida >= 0)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y, transform.localScale.z);
        }
        if (transform.localScale.x > Vida / 25 && Vida >= 0)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y, transform.localScale.z);
        }
    }
}
