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

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        rigid.velocity = transform.right * movement * speed;

        float xPos = Mathf.Clamp(transform.position.x, -6f, 6f);

        transform.position = new Vector2(xPos, transform.position.y);
    }

    private void Update()
    {
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
    }

    IEnumerator destroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(bullet);
        //totalBulletsInScene = 0;
    }
}


