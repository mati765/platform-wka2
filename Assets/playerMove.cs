using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float jumpStrength = 400;
    public float moveSpeed = 5;
    public GameObject gameManager;
    public GameManager GM;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GM = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetAxisRaw("Vertical") > 0 && rb.velocity.y == 0)
        {
            rb.AddForce(Vector3.up * jumpStrength);
        }
        if (Input.GetAxisRaw("Horizontal") != 0)
            transform.position += (Vector3) Vector2.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject drop = collision.gameObject;
        Destroy(drop);
        GM.removeHeart();
    }
}
