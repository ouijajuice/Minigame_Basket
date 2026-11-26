using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Basket_Minigame : MonoBehaviour
{
    public float basketSpeed = 3.0f;
    public float startCountdown = 5.0f;
    public int totalDrops = 10;
    public GameObject[] ingredientPrefabs;

    private InputAction moveAction;
    private CharacterController characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get the "Move" input action
        moveAction = InputSystem.actions.FindAction("Move");
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        Vector3 camUp = Camera.main.transform.up;
        Vector3 camRight = Camera.main.transform.right;
        camUp.z = 0f;
        camRight.z = 0f;

        Vector3 moveDirection = (camUp.normalized * moveInput.y + camRight.normalized * moveInput.x);

        characterController.Move(moveDirection * basketSpeed * Time.deltaTime);
    }
}
