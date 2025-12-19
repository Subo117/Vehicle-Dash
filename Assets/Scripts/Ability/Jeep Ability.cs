using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class JeepAbility : MonoBehaviour
{
    [SerializeField] float cooldown = 60f;
    [SerializeField] float abilityTime = 10f;

    InputAction ability;

    PlayerCollision playerCollision;

    public bool isActive = true;
    float timer = 0f;

    private void Awake()
    {
        playerCollision = GetComponentInChildren<PlayerCollision>(true);
        ability = InputSystem.actions.FindAction("Ability");

        Debug.Log("player colli done");
    }
    private void Update()
    {
        if (isActive && ability.WasPressedThisFrame())
        {
            Debug.Log("Ability Used");
            StartCoroutine(AbilityCoroutine());
            isActive = false;
        }

        if (!isActive)
        {
            timer += Time.deltaTime;
            if (timer >= cooldown)
            {
                Debug.Log("Ability Regained");
                isActive = true;
                timer = 0;
            }
        }

    }

    IEnumerator AbilityCoroutine()
    {
        playerCollision.isShieldActive = true;
        yield return new WaitForSeconds(abilityTime);
        playerCollision.isShieldActive = false;
    }
}
