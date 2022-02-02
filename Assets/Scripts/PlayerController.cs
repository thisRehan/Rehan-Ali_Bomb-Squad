using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    public GameObject stickyBombClone;
    [SerializeField] GameObject enemy;
    private bool multiBomb = false;
    public bool stickybomb = false;
    public bool mines = false;
    private bool life = false;
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OutOfBound();
        BombThrow();
        destroy();
    }
    void Movement()
    {
        float speed = 10;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * speed * 5 * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
    }
    void OutOfBound()
    {
        float yRange = 5;
        if (transform.position.y < -yRange)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MultiBomb"))
        {
            Destroy(other.gameObject);
            multiBomb = true;
            StartCoroutine(MultiBomb());
        }
        if (other.CompareTag("StickyBomb"))
        {
            Destroy(other.gameObject);
            stickybomb = true;
            StartCoroutine(StickyBomb());
        }
        if (other.CompareTag("Mines"))
        {
            Destroy(other.gameObject);
            mines = true;
        }
        if (other.CompareTag("Life"))
        {
            Destroy(other.gameObject);
            life = true;
        }
    }
    void BombThrow()
    {
        Vector3 offset = new Vector3(0, 1.5f, 0);
        int NoOfBomb = FindObjectsOfType<Bomb>().Length;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (multiBomb == true)
                Instantiate(bomb, transform.position + offset, transform.rotation);
            if (multiBomb == false && NoOfBomb == 0)
                Instantiate(bomb, transform.position + offset, transform.rotation);
            if(stickybomb == true)
                stickyBombClone = Instantiate(bomb, transform.position + offset, transform.rotation);
        }
    }
    void destroy()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
    IEnumerator MultiBomb()
    {
        yield return new WaitForSeconds(10);
        multiBomb = false;
    }
    IEnumerator StickyBomb()
    {
        yield return new WaitForSeconds(3);
        stickybomb = false;
    }
}
