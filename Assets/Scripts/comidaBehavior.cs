using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comidaBehavior : MonoBehaviour
{
    public GameObject Comida;
    public int pontosAdquiridos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreCount.Count += pontosAdquiridos;
            vidaCount.Vida += pontosAdquiridos;
            vidaCount.Morrivel = true;
            Destroy(Comida);
        }
    }

}
