using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController player;
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OutOfBound();
    }
    void Movement()
    {
        if(player)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime);
        }
    }
    void OutOfBound()
    {
        float yRange = 5;
        if (transform.position.y < -yRange)
            Destroy(gameObject);
        if (health <= 0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            player.health -= 10;
        if(collision.gameObject.CompareTag("Bomb"))
        {
            health = health / 2;
            if (player.stickybomb == true)
                player.stickyBombClone.transform.parent = gameObject.transform;
            if (player.mines == true)
                Destroy(gameObject);
        }
    }
    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
