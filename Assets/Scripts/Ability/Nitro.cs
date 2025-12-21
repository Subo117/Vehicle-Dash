using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Nitro : MonoBehaviour
{
    [SerializeField] float nitroSpeed = 350f;
    [SerializeField] float nitroTime = 3f;

    InputAction ability;
    GameSpeedManager gameSpeedManager;

    PlayerCollision playerCollision;

    void Awake()
    {
        gameSpeedManager = FindAnyObjectByType<GameSpeedManager>();
        playerCollision = GetComponentInChildren<PlayerCollision>();
        ability = InputSystem.actions.FindAction("Ability");
    }

    void Update()
    {
        if (playerCollision.isNitroActive && ability.WasPressedThisFrame())
        {
            Debug.Log("Ability Used");
            StartCoroutine(AbilityCoroutine());
            playerCollision.isNitroActive = false;
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
