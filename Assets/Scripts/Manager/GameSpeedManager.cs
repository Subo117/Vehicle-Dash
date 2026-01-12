using UnityEngine;
using UnityEngine.InputSystem;

public class GameSpeedManager : MonoBehaviour
{
    [SerializeField] public float maxSpeed = 180f;
    [SerializeField] float secondsForSpeedBoost = 2f;
    [SerializeField] float accelerateMultiplier = 10f;
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

        SpeedometerNeedle.transform.eulerAngles = new Vector3(0, 0, GetRotationAngle());

        HandleLinearSpeedIncrement();

        if (accelarate.IsPressed())
        {
            currentSpeed += Time.deltaTime * accelerateMultiplier;
        }
        else
        {
            currentSpeed -= Time.deltaTime * accelerateMultiplier;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, baseSpeed, maxSpeed);

        //Debug.Log(currentSpeed);



    }

    void HandleLinearSpeedIncrement()
    {
        if (currentSpeed > maxSpeed) return;
        timer += Time.deltaTime;
        if (timer > secondsForSpeedBoost)
        {
            baseSpeed++;
            timer = 0;
        }
        currentSpeed = Mathf.Max(currentSpeed, baseSpeed);

    }

    float GetRotationAngle()
    {
        float targetAngle = minAngle - maxAngle;
        float speedNormalised = currentSpeed / maxSpeed;

        return minAngle - targetAngle * speedNormalised;
    }

}
