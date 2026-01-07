using UnityEngine;
using UnityEngine.InputSystem;

public class GameSpeedManager : MonoBehaviour
{
    [SerializeField] public float maxSpeed = 150f;
    [SerializeField] float secondsForSpeedBoost = 2f;
    [SerializeField] float minAngle = 120f;
    [SerializeField] float maxAngle = -120f;
    [SerializeField] GameObject SpeedometerNeedle;

    InputAction accelarate;
    PlayerCollision playerCollision;

    public float baseSpeed = 20f;
    public float currentSpeed = 20f;
    float timer = 0f;

    private void Awake()
    {
        accelarate = InputSystem.actions.FindAction("Accelerate");
        playerCollision = FindAnyObjectByType<PlayerCollision>();


    }

    private void Update()
    {
        if (playerCollision.isCrashed) return;
        HandleLinearSpeedIncrement();
        if (accelarate.IsPressed())
        {
            if (currentSpeed > maxSpeed) return;
            currentSpeed += Time.deltaTime * 5;
        }
        else
        {
            if(currentSpeed <= baseSpeed) return;
            currentSpeed -= Time.deltaTime * 5;
        }
        Debug.Log(currentSpeed);

        SpeedometerNeedle.transform.eulerAngles = new Vector3(0, 0, GetRotationAngle());


    }

    void HandleLinearSpeedIncrement()
    {
        if (currentSpeed > maxSpeed) return;
        timer += Time.deltaTime;
        if (timer > secondsForSpeedBoost)
        {
            baseSpeed++;
            currentSpeed = Mathf.Max(currentSpeed, baseSpeed);
            timer = 0;
        }
    }

    float GetRotationAngle()
    {
        float targetAngle = minAngle - maxAngle;
        float speedNormalised = currentSpeed / maxSpeed;

        return minAngle - targetAngle * speedNormalised;
    }

}
