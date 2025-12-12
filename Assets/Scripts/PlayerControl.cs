using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject playerModel;
    [SerializeField] float moveSpeed = 100f;

    InputAction left;
    InputAction right;

    Animator animator;
    float laneDistance = 15f;
    int currentLane = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        left = InputSystem.actions.FindAction("Left");
        right = InputSystem.actions.FindAction("Right");

    }
    
    private void Update()
    {
        if (left.WasPressedThisFrame() && (currentLane > -1))
        {
            currentLane--;
            animator.Play("Turn Left", 0, 0f);
        }

        if (right.WasPressedThisFrame() && currentLane < 1)
        {
            currentLane++;
            animator.Play("Turn Right", 0, 0f);
        }


        Vector3 targetPos = new Vector3(currentLane * laneDistance, playerModel.transform.position.y, playerModel.transform.position.z);

        playerModel.transform.position = Vector3.MoveTowards(
            playerModel.transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );
    }

}
