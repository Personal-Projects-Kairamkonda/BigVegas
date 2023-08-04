using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;


public class Character : MonoBehaviour
{
    public TextMeshProUGUI playerDialougeText;
    private string playerDialouge;

    CharacterController characterController;
    Animator GetAnimator;

    // Booleans to check player state
    bool isMovementPressed;
    bool isRunPressed;

    int isWalkingHash;
    int isRunningHash;

    float turnSmoothTime = 0.1f;
    float speed = 0.8f;
    float runSpeed = 3f;
    float gravity = -9.8f;

    float turnsmoothVelocity;
    Vector3 movedir;
    Vector3 velocity;
    Vector3 direction;

    void Awake()
    {
        GetAnimator = transform.GetChild(0).GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        //removed dependance on main menu scene
        //playerDialougeText = FlashScreen.instance.playerDialougeText;
    }

    void Start()
    {
        UpdatePlayerDialouges("Hello EveryBody");
    }

    void Update()
    {
        HandleMovement();
        HandleGravity();
        HandleAnimation();
    }

    void UpdatePlayerDialouges(string dialouge)
    {
        playerDialougeText.text = dialouge;
    }

    void HandleAnimation()
    {
        bool isWalking = GetAnimator.GetBool(isWalkingHash);
        bool isRunning = GetAnimator.GetBool(isRunningHash);

        if (direction.magnitude >= 0.1f && !isWalking)
            GetAnimator.SetBool(isWalkingHash, true);
        else if (direction.magnitude <= 0.1f && isWalking)
            GetAnimator.SetBool(isWalkingHash, false);

        if ((isMovementPressed && isRunPressed) && !isRunning)
            GetAnimator.SetBool(isRunningHash, true);
        else if ((!isMovementPressed || !isRunPressed) && isRunning)
            GetAnimator.SetBool(isRunningHash, false);
    }


    //public void OnMove(InputValue value) => direction = value.Get<Vector2>();

    /// <summary>
    /// Old Input System for movement
    /// </summary>
    void HandleMovement()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;
        

        if (direction.magnitude >= 0.1f)
        {
            isMovementPressed = true;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            movedir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(movedir.normalized * speed * Time.deltaTime);
        }   

        //Run or Sprint
        if (direction.magnitude >= 0.1f && Input.GetKey(KeyCode.LeftShift))
        {
            isRunPressed = true;
            characterController.Move(movedir.normalized * runSpeed * Time.deltaTime);
        }
        else
        {
            isRunPressed = false;
        }
    }

    void HandleGravity()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(10 * -0.2f * gravity);
        }
    }

    void HandleEnvironmentInteraction()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 14f);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.gameObject.name);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
          //FlashScreen.instance.UpdateDialougeText("Aww!! cool dance old man");

        if (other.gameObject.CompareTag("Doozy"))
            //FlashScreen.instance.UpdateDialougeText("Hello Doozy, Have you slept yet?");

        Debug.Log(other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        { }
            //FlashScreen.instance.UpdateDialougeText("Go to meet the Doozy, He is waiting above the stairs");
    }
}
