using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject speedometer;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pickupUI;
    [SerializeField] GameObject boostUI;

    PlayerCollision playerCollision;


    private void Start()
    {
        playerCollision = FindAnyObjectByType<PlayerCollision>();
    }

    public void OnGameOver()
    {
        pauseButton.SetActive(false);
        speedometer.SetActive(false);
        pickupUI.SetActive(false);
        boostUI.SetActive(false);

        playerCollision.isCrashed = true;
        StartCoroutine(CrashedCoroutne());

    }

    public void OnRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator CrashedCoroutne()
    {
        //Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;

        gameOverScreen.gameObject.SetActive(true);

        Debug.Log("Set true");

    }
}
