using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text textStateGame;

    private bool inGameOver = false;
    private bool win = false;

    public static int totalEnemies;
    public enum State
    {
        INGAME,
        GAMEOVER,
        WIN
    }

    public static State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.INGAME;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.INGAME:
                if (totalEnemies <= 0)
                    state = State.WIN;
                break;
            case State.GAMEOVER:
                OnGameOverState(true);
                break;
            case State.WIN:
                WinGame(true);
                break;
        }
    }

    private void WinGame(bool state)
    {
        if (win != state)
        {
            textStateGame.text = "You Win";
            win = state;
        }
    }

    private void OnGameOverState(bool state)
    {
        if (inGameOver != state)
        {
            textStateGame.text = "Game Over";
            inGameOver = state;
        }
    }
}
