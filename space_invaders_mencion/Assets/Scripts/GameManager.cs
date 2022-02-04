using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text textStateGame;
    private bool inGameOver = false;
    public enum State
    {
        INGAME,
        GAMEOVER
    }

    public State state;

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

                if (SpaceShipScript.enemyTouchPlayer == true)
                {
                    state = State.GAMEOVER;
                }

                break;
            case State.GAMEOVER:
                OnGameOverState(true);
                break;
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
