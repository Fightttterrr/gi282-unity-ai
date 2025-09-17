// 17/9/2568 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement3DNoAnimation : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character's movement

    private CharacterController characterController; // Reference to the CharacterController component
    private Vector3 movement;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleInput();
        MoveCharacter();
    }

    // Handles user input for movement
    private void HandleInput()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down arrow keys

        // Calculate movement direction based on input
        movement = new Vector3(horizontal, 0, vertical).normalized;
    }

    // Moves the character based on input
    private void MoveCharacter()
    {
        if (movement != Vector3.zero)
        {
            // Move the character
            characterController.Move(movement * moveSpeed * Time.deltaTime);

            // Rotate the character to face the movement direction
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720f * Time.deltaTime); // Smooth rotation
        }
    }
}