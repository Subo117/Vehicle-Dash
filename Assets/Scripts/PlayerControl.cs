using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject playerModel;
    [SerializeField] float moveSpeed = 100f;

    float laneDistance = 15f;
    int currentLane = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentLane > -1)
            currentLane--;

        if (Input.GetKeyDown(KeyCode.D) && currentLane < 1)
            currentLane++;

        Vector3 targetPos = new Vector3(currentLane * laneDistance, playerModel.transform.position.y, playerModel.transform.position.z);

        playerModel.transform.position = Vector3.MoveTowards(
            playerModel.transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );
    }

}
