using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using Unity.VisualScripting;

public class PickupTools : MonoBehaviour
{
    [SerializeField] GameObject missilePrefab;
    [SerializeField] AudioClip nitroClip;
    [SerializeField] float nitroSpeed = 350f;
    [SerializeField] float nitroTime = 3f;
    [SerializeField] float transitionTime = 1f;

    InputAction ability;
    GameSpeedManager gameSpeedManager;
    CinemachineCamera cmCamera;
    CinemachineFollow cmFollow;

    PlayerCollision playerCollision;

    float normalFOV = 60f;
    float zoomOutFOV = 80f;

    float normalYOffset = 12f;
    float zoomOutYOffset = 7f;

    void Start()
    {
        gameSpeedManager = FindAnyObjectByType<GameSpeedManager>();
        playerCollision = GetComponentInChildren<PlayerCollision>();
        ability = InputSystem.actions.FindAction("Ability");
        cmCamera = FindAnyObjectByType<CinemachineCamera>();
        cmFollow = FindAnyObjectByType<CinemachineFollow>();

        cmCamera.Lens.FieldOfView = normalFOV;
        cmFollow.FollowOffset.y = normalYOffset;
        
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
            Instantiate(missilePrefab, transform.position, Quaternion.identity);
            playerCollision.isMissilePicked = false;
        }

    }

    IEnumerator NitroCoroutine()
    {
        MusicSettingManager.instance.PlaySound(nitroClip);
        StartCoroutine(FOVCoroutine(zoomOutFOV, zoomOutYOffset));
        playerCollision.isNitroActive = true;
        float tempMaxSpeed = gameSpeedManager.maxSpeed;
        float tempCurrentSpeed = gameSpeedManager.currentSpeed;
        playerCollision.isShieldActive = true;
        gameSpeedManager.maxSpeed = nitroSpeed;
        gameSpeedManager.currentSpeed = nitroSpeed;
        yield return new WaitForSeconds(nitroTime);
        StartCoroutine(FOVCoroutine(normalFOV, normalYOffset));
        yield return new WaitForSeconds(transitionTime);
        gameSpeedManager.maxSpeed = tempMaxSpeed;
        gameSpeedManager.currentSpeed = tempCurrentSpeed;
        playerCollision.isShieldActive = false;
        playerCollision.isNitroActive = false;
    }

    IEnumerator FOVCoroutine(float targetFOV, float targetYOffset)
    {
        float startFOV = cmCamera.Lens.FieldOfView;
        float startYOffset = cmFollow.FollowOffset.y;
        float timer = 0;
        while(timer < transitionTime)
        {
            timer += Time.deltaTime;
            cmCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, timer / transitionTime);
            cmFollow.FollowOffset.y = Mathf.Lerp(startYOffset, targetYOffset, timer / transitionTime);
            yield return null;

        }

    }
}
