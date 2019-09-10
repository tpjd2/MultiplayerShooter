using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] GameObject projetil;
    [SerializeField] Transform projetilSpawn;
    [SerializeField] float velocidadeRotacao;
    [SerializeField] float velocidade;
    float x, y;

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadeRotacao;
        y = Input.GetAxis("Vertical") * Time.deltaTime * velocidade;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, y);

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject tiro =
            (GameObject) Instantiate(
                projetil,
                projetilSpawn.position,
                projetilSpawn.rotation
                );
        tiro.GetComponent<Rigidbody>().velocity =
            tiro.transform.forward * 6.0f;

        Destroy(tiro, 2.0f);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
