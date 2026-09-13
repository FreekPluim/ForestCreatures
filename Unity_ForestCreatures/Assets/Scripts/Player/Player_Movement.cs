using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour, ISaveLoad
{
    public InputActionAsset inputActions;
    InputAction moveAction;
    InputAction sprintAction;

    [SerializeField] Rigidbody rb;
    Vector2 playerMovementInput;
    Vector3 moveDirection = Vector3.zero;
    Quaternion lookRotation;
    bool sprinting;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float sprintSpeed = 8f;

    [SerializeField] Transform visuals;
    [SerializeField] float rotationSpeed = 2;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");

        rb = GetComponent<Rigidbody>();
    }
     
    void Update()
    {
        playerMovementInput = moveAction.ReadValue<Vector2>();
        moveDirection.x = playerMovementInput.x;
        moveDirection.z = playerMovementInput.y;

        //Handle sprinting
        if (sprintAction.WasPerformedThisFrame()) 
        {
            sprinting = true;
        }
        if(sprinting && playerMovementInput.magnitude == 0)
        {
            sprinting = false;
        }

        if(playerMovementInput.magnitude != 0)
        {
            lookRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            visuals.localRotation = Quaternion.Lerp(visuals.localRotation, lookRotation, rotationSpeed);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(sprinting ? rb.position + moveDirection.normalized * sprintSpeed : rb.position + moveDirection.normalized * moveSpeed);
    }

    public void LoadData(GameData data)
    {
        transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = transform.position;
    }
}
