using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    // ゲーム状態
    // 列挙定数
    enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;

    // スコア
    int score;

    public PlayerController player;
    public GameObject block;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI titleText;

    private void Start()
    {
        Ready();
    }

    private void LateUpdate()
    {
        switch(state)
        {
            case State.Ready:
                if(Input.GetButtonDown("Fire1"))
                
                    GameStart();
                    break;
                
            case State.Play:
                if(player.IsDead())
                
                    GameOver();
                    break;
                
            case State.GameOver:
                if(Input.GetButtonDown("Fire1"))
                
                    Reload();
                    break;
                
        }
    }
    private void Ready()
    {
        
        state = State.Ready;
        player.SetSteerActive(false);
        block.SetActive(false);
        scoreText.text = "SCORE : " + 0;
        titleText.gameObject.SetActive(true);
        titleText.text = "READY";
    }
    private void GameStart()
    {
        state = State.Play;
        player.SetSteerActive(true);
        block.SetActive(true);
        player.Flap();
        titleText.gameObject.SetActive(false);
        
    }

    private void GameOver()
    {
        state = State.GameOver;
        ScrollObject[] scrollObjects = FindObjectsOfType<ScrollObject>();
        foreach(ScrollObject so in scrollObjects)
        {
            so.enabled = false;
        
        
        }
        titleText.gameObject.SetActive(true);
        titleText.text = "GAME OVER";


    }

    private void Reload()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "SCORE : " + score;
    }
}
