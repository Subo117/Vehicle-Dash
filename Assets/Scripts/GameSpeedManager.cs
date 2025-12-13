using UnityEngine;
using UnityEngine.InputSystem;

public class GameSpeedManager : MonoBehaviour
{
    [SerializeField] float maxSpeed = 200f;
    [SerializeField] float secondsForSpeedBoost = 2f;

    InputAction accelarate;

    public float baseSpeed = 15f;
    public float currentSpeed = 15f;
    float timer = 0f;

    private void Awake()
    {
        accelarate = InputSystem.actions.FindAction("Accelerate");

    }

    private void Update()
    {
        HandleLinearSpeedIncrement();
        if (accelarate.IsPressed())
        {
            if (currentSpeed > maxSpeed) return;
            currentSpeed += Time.deltaTime * 10;
            
            

        }
        else
        {
            if(currentSpeed <= baseSpeed) return;
            currentSpeed -= Time.deltaTime * 10;
            

        }
    }

    void HandleLinearSpeedIncrement()
    {
        if (currentSpeed > maxSpeed) return;
        timer += Time.deltaTime;
        if (timer > secondsForSpeedBoost)
        {
            baseSpeed++;
            currentSpeed = Mathf.Max(currentSpeed, baseSpeed);
            //Debug.Log(currentSpeed);
            timer = 0;
        }
        

    }

}
