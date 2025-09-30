using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

    public InputActionAsset inputActionMap;

    private InputAction moveInput;
    private InputAction attackInput;

    private InputAction sprintInput;



    private Vector2 movement;

    private Rigidbody2D rb;

    private Animator anim;
    [SerializeField] float speed = 5.0F;

    bool isFacingRight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {


        moveInput = inputActionMap.FindActionMap("Player").FindAction("Move");
        attackInput = inputActionMap.FindActionMap("Player").FindAction("Attack");
        sprintInput = inputActionMap.FindActionMap("Player").FindAction("Sprint");

        rb.gravityScale = 0;

    }

    void FixedUpdate()
    {

        HandleMovement();



    }

    // Update is called once per frame
    void Update()
    {

        HandleAttack();

        movement = moveInput.ReadValue<Vector2>();

        //Vector2 movementPosition = new Vector2(horizontalDirection * speed * Time.deltaTime, verticalDirection * speed * Time.deltaTime);




    }

    private void HandleMovement()
    {


        Vector2 transformPosition = rb.position + movement * speed * Time.fixedDeltaTime;

        rb.MovePosition(transformPosition);


        float inputSpeed = movement.magnitude;



        anim.SetFloat("Speed", inputSpeed);


        if (movement.x < 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.localScale = new Vector2(-1, 1);

        }
        else if (movement.x > 0 && isFacingRight)
        {
            isFacingRight = false;
            rb.transform.localScale = new Vector2(1, 1);

        }


        if (sprintInput.IsPressed())
        {
            anim.SetBool("Sprint", true);
        }

        else if (sprintInput.WasReleasedThisFrame())
        {
            anim.SetBool("Sprint", false);
        }






    }

    private void HandleAttack()
    {

        if (attackInput.WasPressedThisFrame())
        {
            anim.SetBool("Attack1", true);

        }

        if (attackInput.WasReleasedThisFrame())
        {
            anim.SetBool("Attack1", false);
        }



    }


}
