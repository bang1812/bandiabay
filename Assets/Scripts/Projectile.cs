using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    Rigidbody2D m_rg;
    GameController m_gc;
    public GameObject ufoboom;
    AudioSource aus;
    public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        m_rg = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        m_rg.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            m_gc.ScoreIncrement();

            if(aus && hitSound){
                aus.PlayOneShot(hitSound);
            }

            Instantiate(ufoboom, other.transform.position, Quaternion.identity);

            Destroy(gameObject);

            Destroy(other.gameObject);
            Debug.Log("vien dan da va cham enemy");
        }
    }
}
