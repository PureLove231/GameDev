using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour


{

    public float speed = 5.0f;
    public float jumpingForce = 5.0f;

    public bool canJump = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("right"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }


        if (Input.GetKey("left"))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown("space") && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Ground")
        {
            Debug.Log("Hit the ground");
            canJump = true;

        }
    }
}
