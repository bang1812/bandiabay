using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D m_rg;
    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        m_rg = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpeed();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("DeathZone")){
            m_gc.SetGameoverState(true);

            Destroy(gameObject);
            Debug.Log("Enemy da va cham death zone");
        }
    }

    private void EnemySpeed(){
        if(m_gc.GetScore() <= 100){
            m_rg.velocity = Vector2.down * moveSpeed;
        }
        else{
            m_rg.velocity = Vector2.down * (moveSpeed + 1);
        }
    }
}
