using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 500f;

    Transform playerPos;

    bool coinMove = false;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
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
