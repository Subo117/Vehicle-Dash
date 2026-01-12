using UnityEngine;
using UnityEngine.UI;

public class PickupUIManager : MonoBehaviour
{
    [Header("Magnet")]
    [SerializeField] GameObject magnetUI;
    [SerializeField] Slider magnetSlider;

    [Header("Shield")]
    [SerializeField] GameObject shieldUI;
    [SerializeField] Slider shieldSlider;

    [Header("Twice Coin")]
    [SerializeField] GameObject twiceCoinUI;
    [SerializeField] Slider twiceCoinSlider;

    PlayerCollision playerCollision;

    private void Start()
    {
        playerCollision = FindAnyObjectByType<PlayerCollision>();
    }

    private void Update()
    {
        UpdatePickupUI(playerCollision.isMagnetActive, playerCollision.magnetTimer, playerCollision.pickupTime, magnetUI, magnetSlider);
        UpdatePickupUI(playerCollision.isShieldActive, playerCollision.shieldTimer, playerCollision.pickupTime, shieldUI, shieldSlider);
        UpdatePickupUI(playerCollision.isTwiceCoinActive, playerCollision.twiceCoinTimer, playerCollision.pickupTime, twiceCoinUI, twiceCoinSlider);

    }

    void UpdatePickupUI(bool isActive, float timer, float totalTime, GameObject ui, Slider slider)
    {
        if (playerCollision.isCrashed)
        {
            ui.SetActive(false);
            return;
        }
        if (!isActive)
        {
            ui.SetActive(false);
            return;
        }

        ui.SetActive(true);
        slider.value = timer / totalTime;
    }

}
