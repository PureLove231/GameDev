using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speed = 5.0f;
    [SerializeField] Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed * Time.deltaTime;

    }
}
