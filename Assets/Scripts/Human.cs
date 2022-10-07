using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Human : MonoBehaviour
{
    private GameInputs input;
    CharacterController characterController;
    Animator GetAnimator;

    int isWalkingHash;
    int isRunningHash;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;

    // Booleans to check player state
    bool isMovementPressed;
    bool isRunPressed;

    // variables for rotation and run speed
    float rotationFactorPerFrame = 15.0f;
    float runMultiplier = 3.0f;
    private float turnsmoothVelocity;

    void Awake()
    {
        input = new GameInputs();
        characterController = GetComponent<CharacterController>();
        GetAnimator = transform.GetChild(0).GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        input.BigVegasControls.Move.started += onMovementInput;
        input.BigVegasControls.Move.canceled += onMovementInput;
        input.BigVegasControls.Move.performed += onMovementInput;

        input.BigVegasControls.Run.started += onRun;
        input.BigVegasControls.Run.canceled += onRun;
        input.BigVegasControls.Run.performed += onRun;

    }

    void Update()
    {
        if(isRunPressed)
            characterController.Move(currentRunMovement * Time.deltaTime);
        else
            characterController.Move(currentMovement*Time.deltaTime);

        HandleAnimation();
        HandleGravity();
        HandleRotation();
    }

    void OnEnable()
    {
        input.BigVegasControls.Enable();
    }

    void OnDisable()
    {
        input.BigVegasControls.Disable();
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        currentRunMovement.x = currentMovementInput.x * runMultiplier;
        currentRunMovement.z = currentMovementInput.y * runMultiplier;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void onCMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    void HandleAnimation()
    {
        bool isWalking = GetAnimator.GetBool(isWalkingHash);
        bool isRunning = GetAnimator.GetBool(isRunningHash);

        if (isMovementPressed && !isWalking )
            GetAnimator.SetBool(isWalkingHash, true);
        else if(!isMovementPressed && isWalking)
            GetAnimator.SetBool(isWalkingHash, false);

        if ((isMovementPressed && isRunPressed) && !isRunning)
            GetAnimator.SetBool(isRunningHash, true);
        else if((!isMovementPressed || !isRunPressed) && isRunning)
            GetAnimator.SetBool(isRunningHash, false);
    }

    void HandleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;
            
        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame*Time.deltaTime);
        }
    }

    void CHandleRotation()
    {
        Vector3 direction = new Vector3(currentMovement.x, 0, currentMovement.z).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothVelocity, 1f);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 movedir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        currentMovement = movedir;
    }

    void HandleGravity()
    {
        if(characterController.isGrounded)
        {
            float groundedGravity = -0.05f;
            currentMovement.y = groundedGravity;
            currentRunMovement.y= groundedGravity;
        }
        else
        {
            float groundedGravity = -9.8f;
            currentMovement.y += groundedGravity;
            currentRunMovement.y += groundedGravity;
        }
    }
}
