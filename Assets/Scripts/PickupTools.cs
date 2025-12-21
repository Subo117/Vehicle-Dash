using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupTools : MonoBehaviour
{
    [SerializeField] GameObject missilePrefab;
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
            StartCoroutine(NitroCoroutine());
            playerCollision.isNitroActive = false;
        }
        if(playerCollision.isMissileActive && ability.WasPressedThisFrame())
        {
            Debug.Log("Missle");
            Instantiate(missilePrefab, transform.position, Quaternion.identity, gameObject.transform);
            playerCollision.isMissileActive = false;
        }

    }

    IEnumerator NitroCoroutine()
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
