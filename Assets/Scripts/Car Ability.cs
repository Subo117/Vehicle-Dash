using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarAbility : MonoBehaviour
{
    GameSpeedManager gameSpeedManager;

    [SerializeField] float cooldown = 10f;
    [SerializeField] float nitroSpeed = 350f;
    [SerializeField] float nitroTime = 5f;

    PlayerCollision playerCollision;

    bool isActive = true;

    float timer = 0;


    private void Awake()
    {
        gameSpeedManager = FindAnyObjectByType<GameSpeedManager>();
        playerCollision = GetComponentInChildren<PlayerCollision>();
    }

    private void Update()
    {
        if (isActive && Keyboard.current.qKey.wasPressedThisFrame)
        {
            Debug.Log("Ability Used");
            StartCoroutine(AbilityCoroutine());
            isActive = false;
        }

        if (!isActive)
        {
            timer += Time.deltaTime;
            if(timer >= cooldown)
            {
                Debug.Log("Ability Regained");
                isActive = true;
                timer = 0;
            }
        }

    }

    IEnumerator AbilityCoroutine()
    {
        float tempMaxSpeed = gameSpeedManager.maxSpeed;
        float tempCurrentSpeed = gameSpeedManager.currentSpeed;
        playerCollision.isShieldActive = true;
        gameSpeedManager.maxSpeed = nitroSpeed;
        gameSpeedManager.currentSpeed = nitroSpeed;
        yield return new WaitForSeconds(nitroTime);
        gameSpeedManager.maxSpeed = tempMaxSpeed;
        gameSpeedManager.currentSpeed = tempCurrentSpeed;
        playerCollision.isShieldActive = false;
    }
}
