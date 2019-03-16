using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lixoBehavior : MonoBehaviour
{
    public GameObject Lixo;
    public int pontosPerdidos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreCount.Count -= pontosPerdidos;
            vidaCount.Vida -= pontosPerdidos;
            Destroy(Lixo);
        }
    }
}
