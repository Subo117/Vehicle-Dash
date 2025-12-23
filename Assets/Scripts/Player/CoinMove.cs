using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 300f;

    Transform playerPos;

    bool coinMove = false;

    private void Start()
    {
        playerPos = FindAnyObjectByType<VehicleSelector>().transform;
    }

    void Update()
    {
        if (!coinMove) return;
        Vector3 target = playerPos.position + playerPos.forward * 3f;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    public void MoveCoin(bool state)
    {
        coinMove = state;
    }
}
