using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject playerModel;
    [SerializeField] float moveSpeed = 100f;

    InputAction left;
    InputAction right;

    float laneDistance = 15f;
    int currentLane = 0;
    public bool isMovable = true;

    private void Awake()
    {
        left = InputSystem.actions.FindAction("Left");
        right = InputSystem.actions.FindAction("Right");


    }
    
    private void Update()
    {
        if (!isMovable) return;
       
        if (left.WasPressedThisFrame() && (currentLane > -1))
        {
            currentLane--;
        }

        if (right.WasPressedThisFrame() && currentLane < 1)
        {
            currentLane++;
        }


        Vector3 targetPos = new Vector3(currentLane * laneDistance, playerModel.transform.position.y, playerModel.transform.position.z);

        playerModel.transform.position = Vector3.MoveTowards(playerModel.transform.position, targetPos, moveSpeed * Time.deltaTime
        );
    }

}
