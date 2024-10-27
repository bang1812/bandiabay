using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    public Text scoreText;
    float m_spawnTime;
    int m_score;
    bool m_isGameover;
    bool playgame;
    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        Time.timeScale = 1;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score:" + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isGameover){
            m_spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            scoreText.text = m_score.ToString();
            Time.timeScale = 0;
            return;
        }

        if(playgame == false) return;

        m_spawnTime -= Time.deltaTime;

        if(m_spawnTime <=0){
            SpawnEnemy();
            if(m_score <= 100){
                m_spawnTime = spawnTime;
            }
            else{
                m_spawnTime = spawnTime - 0.5f;
            }
        }
    }

    public void PlayGame(){
        m_ui.SetGameStart(true);
        playgame = true;
    }

    public void SpawnEnemy(){
        float randXPos = Random.Range(-7f,7f);

        Vector2 spawnPos = new Vector2(randXPos, 5.2f);

        if(enemy){
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    public void Replay(){
        SceneManager.LoadScene("GamePlay");
    }

    public void SetScore(int value){
        m_score = value;
    }

    public int GetScore(){
        return m_score;
    }

    public  void ScoreIncrement(){
        m_score += 10;
        Prefs.bestScore = m_score;
        m_ui.SetScoreText("Score: " + m_score);
    }

    public void SetGameoverState(bool state){
        m_isGameover = state;
    }

    public bool IsGameover(){
        return m_isGameover;
    }

    public void Pause(){
        if(m_ui.bestScore){
            m_ui.Show(true);
        }
    }
}
