using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] const int vidaMaxima = 100;
    [SerializeField] int vidaAtual;

    private void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void Damage(int quantidade)
    {
        vidaAtual -= quantidade;
        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            Debug.Log("Morreu!!!");
        }
    }
}
