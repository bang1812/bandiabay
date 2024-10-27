using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameoverPanel;
    public GameObject gameGUI;
    public GameObject homeGUI;
    public GameObject pauseGame;
    public Text bestScore;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScoreText(string txt){
        if(scoreText){
            scoreText.text = txt;
        }
    }

    public void ShowGameoverPanel(bool isShow){
        if(gameoverPanel){
            gameoverPanel.SetActive(isShow);
        }
    }

    public void SetGameStart(bool isShow){
        if(gameGUI){
            gameGUI.SetActive(isShow);
        }

        if(homeGUI){
            homeGUI.SetActive(!isShow);
        }
    }

    public void Show(bool isShow){
        pauseGame.SetActive(isShow);

        if(bestScore){
            bestScore.text = Prefs.bestScore.ToString();
        }

        Time.timeScale = 0;
    }

    public void Resume(){
        Time.timeScale = 1;
        pauseGame.SetActive(false);
    }
}
