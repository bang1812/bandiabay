using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;
    public Transform shootingPoint;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip shootingSound;
    Rigidbody2D m_rb;
    bool moveLeft;
    bool moveRight;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !m_gc.IsGameover()){
            Shoot();
        }
    }

    private void FixedUpdate() {
        float xDir = Input.GetAxisRaw("Horizontal");

        if((xDir < 0 && transform.position.x <= -7) || (xDir > 0 && transform.position.x >= 7)){
            return;
        }

        if((moveLeft && transform.position.x <= -7) || (moveRight && transform.position.x >= 7)){
            return;
        }

        PlayerSpeed(xDir);

        MoveBtn();
    }

    public void Shoot(){
        if(bullet && shootingPoint){
            if(aus && shootingSound){
                aus.PlayOneShot(shootingSound);
            }
            
            Instantiate(bullet, shootingPoint.position, Quaternion.Euler(0,0,90));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            m_gc.SetGameoverState(true);
            
            Destroy(other.gameObject);
            Debug.Log("Enemy da va cham vs player");
        }
    }

    public void PointerDownLeft(){
        moveLeft = true;
    }

    public void PointerUpLeft(){
        moveLeft = false;
    }

    public void PointerDownRight(){
        moveRight = true;
    }

    public void PointerUpRight(){
        moveRight = false;
    }

    private void PlayerSpeed(float xDir){
        if(xDir > 0){
            m_rb.velocity = Vector2.right * moveSpeed * Time.deltaTime;
        }
        else if(xDir < 0){
            m_rb.velocity = Vector2.left * moveSpeed * Time.deltaTime;
        }
        else{
            m_rb.velocity = Vector2.zero;
        }
    }

    private void MoveBtn(){
        if(moveRight){
            m_rb.velocity = Vector2.right * moveSpeed * Time.deltaTime;
        }
        else if(moveLeft){
            m_rb.velocity = Vector2.left * moveSpeed * Time.deltaTime;
        }
        else{
            m_rb.velocity = Vector2.zero;
        }
    }
}
