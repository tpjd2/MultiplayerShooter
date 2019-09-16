using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InimigoSpawner : NetworkBehaviour
{
    [SerializeField] GameObject inimigoPrefab;
    [SerializeField] int numeroInimigos;

    public override void OnStartServer()
    {
        for (int i = 0; i < numeroInimigos; i++)
        {
            //Vector3 posicaoSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 0.8f));
            Vector3 posicaoSpawn = PontoAleatorio(8.0f);
            Quaternion rotacaoSpawn = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0.0f);

            GameObject inimigo = (GameObject)Instantiate(inimigoPrefab, posicaoSpawn, rotacaoSpawn);
            NetworkServer.Spawn(inimigo);
        }
    }

    private Vector3 PontoAleatorio(float raio)
    {
        Vector2 v = Random.insideUnitCircle.normalized * raio;
        return new Vector3(v.x, 0.0f, v.y);
    }
}
