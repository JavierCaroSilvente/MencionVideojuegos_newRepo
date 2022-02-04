using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedo : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedTorpedo;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = transform.up * Time.deltaTime * speedTorpedo;
    }
}
