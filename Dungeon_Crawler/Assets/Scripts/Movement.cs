using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float horizontalDirection;
    private float verticalDirection;
    [SerializeField] float speed = 5.0F;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

        horizontalDirection = Input.GetAxis("Horizontal");
        verticalDirection = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalDirection * speed * Time.deltaTime, verticalDirection * speed * Time.deltaTime);

        rb.MovePosition(rb.position + movement);


    }


}
