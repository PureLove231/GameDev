using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speed = 5.0f;

    [SerializeField] int faceDirection = 1;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Animator anim;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));


        rb.linearVelocity = new Vector2(horizontal, vertical) * speed * Time.deltaTime;


        if (horizontal > 0 && transform.localScale.x < 0
            || horizontal < 0 && transform.localScale.x > 0
        )

        {
            Flip();
        }

    }

    void Flip()
    {

        faceDirection *= -1;
        transform.localScale = new Vector3(faceDirection, transform.localScale.y, transform.localScale.z);
    }
}
