using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using Unity.VisualScripting;

public class PickupTools : MonoBehaviour
{
    [SerializeField] GameObject missilePrefab;
    [SerializeField] float nitroSpeed = 350f;
    [SerializeField] float nitroTime = 3f;
    [SerializeField] float transitionTime = 1f;

    InputAction ability;
    GameSpeedManager gameSpeedManager;
    CinemachineCamera cmCamera;
    PlayerCollision playerCollision;

    float normalFOV = 60f;
    float zoomOutFOV = 80f;

    float normalSP = 0.2f;

    void Start()
    {
        gameSpeedManager = FindAnyObjectByType<GameSpeedManager>();
        playerCollision = GetComponentInChildren<PlayerCollision>();
        ability = InputSystem.actions.FindAction("Ability");
        cmCamera = FindAnyObjectByType<CinemachineCamera>();

        cmCamera.Lens.FieldOfView = normalFOV;
        
    }

    void Update()
    {
        if (playerCollision.isNitroPicked && ability.WasPressedThisFrame())
        {
            Debug.Log("Ability Used");
            StartCoroutine(NitroCoroutine());
            playerCollision.isNitroPicked = false;
        }
        if(playerCollision.isMissilePicked && ability.WasPressedThisFrame())
        {
            Debug.Log("Missle");
            Instantiate(missilePrefab, transform.position, Quaternion.identity, gameObject.transform);
            playerCollision.isMissilePicked = false;
        }

    }

    IEnumerator NitroCoroutine()
    {
        StartCoroutine(FOVCoroutine(zoomOutFOV));
        playerCollision.isNitroActive = true;
        float tempMaxSpeed = gameSpeedManager.maxSpeed;
        float tempCurrentSpeed = gameSpeedManager.currentSpeed;
        playerCollision.isShieldActive = true;
        gameSpeedManager.maxSpeed = nitroSpeed;
        gameSpeedManager.currentSpeed = nitroSpeed;
        yield return new WaitForSeconds(nitroTime);
        StartCoroutine(FOVCoroutine(normalFOV));
        gameSpeedManager.maxSpeed = tempMaxSpeed;
        gameSpeedManager.currentSpeed = tempCurrentSpeed;
        playerCollision.isShieldActive = false;
        playerCollision.isNitroActive = false;
    }

    IEnumerator FOVCoroutine(float targetFOV)
    {
        float startFOV = cmCamera.Lens.FieldOfView;
        float timer = 0;
        while(timer < transitionTime)
        {
            timer += Time.deltaTime;
            cmCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, timer / transitionTime);
            yield return null;

        }

    }
}
