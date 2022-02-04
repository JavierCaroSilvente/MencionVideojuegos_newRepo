using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rigid;

    public GameObject torpedo;
    public float speedTorpedo;

    public Transform initPositionTorpedo;

    public int totalBulletsInScene = 0;

    public static bool enemyTouchPlayer = false;

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
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case State.INGAME:
                float movement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

                rigid.velocity = transform.right * movement * speed;

                float xPos = Mathf.Clamp(transform.position.x, -6f, 6f);

                transform.position = new Vector2(xPos, transform.position.y);
                break;
            case State.GAMEOVER:

                rigid.constraints = RigidbodyConstraints2D.FreezeAll;
                break;
        }
    }

    private void Update()
    {
        switch (state)
        {
            case State.INGAME:
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    if (totalBulletsInScene == 0)
                    {
                        totalBulletsInScene++;
                        GameObject newTorpedo = Instantiate(torpedo, initPositionTorpedo.transform.position, Quaternion.identity);
                        newTorpedo.name = "Torpedo";
                        newTorpedo.tag = "Torpedo";
                        StartCoroutine(destroyBullet(newTorpedo));
                    }
                }
                break;
            case State.GAMEOVER:
                OnGameOverState(true);
                break;
        }

       
    }

    IEnumerator destroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(bullet);
        //totalBulletsInScene = 0;
    }

    private void OnGameOverState(bool state)
    {
       
        if (inGameOver != state)
        {
            inGameOver = state;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy"){
            enemyTouchPlayer = true;
            state = State.GAMEOVER;
        }
    }
}


