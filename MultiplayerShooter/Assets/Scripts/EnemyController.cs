using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] int damage;

    PlayerController player;
    
    private void Start()
    {
        player = (PlayerController)FindObjectOfType<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("move", 2.0f, 2.0f);
    }

    private void move()
    {
        if (player == null)
        {
            player = (PlayerController)FindObjectOfType<PlayerController>();
        }
        transform.LookAt(player.gameObject.transform);
        GetComponent<Rigidbody>().velocity = transform.forward * velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vida v = collision.gameObject.GetComponent<Vida>();
            if (v != null)
                v.Damage(damage);
        }
    }
}
