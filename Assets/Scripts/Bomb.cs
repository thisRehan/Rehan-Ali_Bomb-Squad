using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] PlayerController player;
    private Rigidbody bombRb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void Movement()
    {
        bombRb = GetComponent<Rigidbody>();
        bombRb.AddRelativeForce(0, 400, 300); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Explosion());
    }
    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
