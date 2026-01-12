using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    
    [SerializeField] public float pickupTime = 10f;
    [SerializeField] ParticleSystem blastVFX;
    [SerializeField] AudioClip coinClip;
    [SerializeField] AudioClip boostClip;
    [SerializeField] AudioClip blastClip;
    [SerializeField] AudioClip carCrashClip;

    CoinCollector collector;
    PlayerControl playerControl;
    ScoreManager scoreManager;
    GameOverManager gameOverManager;

    ParticleSystem smokeVFX;

    public float magnetTimer = 0f;
    public bool isMagnetActive = false;
    public float shieldTimer = 0f;
    public float twiceCoinTimer = 0f;

    public bool isCrashed = false;
    public bool isShieldActive = false;
    public bool isNitroPicked = false;
    public bool isNitroActive = false;
    public bool isMissilePicked = false;
    public bool isTwiceCoinActive = false;

    bool isCrashable = true;

    Coroutine shieldCoroutine;
    Coroutine magnetCoroutine;
    Coroutine twiceCoinCoroutine;

    private void Start()
    {
        playerControl = GetComponentInParent<PlayerControl>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        collector = FindAnyObjectByType<CoinCollector>();
        collector.gameObject.SetActive(false);
        gameOverManager = FindAnyObjectByType<GameOverManager>();
        smokeVFX = GetComponentInChildren<ParticleSystem>(true);


    }
    private void Update()
    {
        if (isCrashed)
        {
            Debug.Log("Crashed");
            gameOverManager.OnGameOver();
        }
        if (Keyboard.current.cKey.wasPressedThisFrame) isCrashable = !isCrashable;


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isCrashable) return;

        if (collision.gameObject.CompareTag("Car"))
        {

            if (isShieldActive)
            {
                isCrashed = false;
                playerControl.isMovable = true;

                MusicSettingManager.instance.PlaySound(blastClip);

                ParticleSystem vfx = Instantiate(blastVFX, transform.position, Quaternion.identity);
                vfx.Play();
                float totalTime = vfx.main.duration + vfx.main.startLifetime.constantMax;
                Destroy(vfx.gameObject, totalTime);

                Destroy(collision.gameObject);
            }
            else
            {
                isCrashed = true;
                playerControl.isMovable = false;
                smokeVFX.gameObject.SetActive(true);

                MusicSettingManager.instance.PlaySound(carCrashClip);
            }
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            if (isNitroActive) return;

            MusicSettingManager.instance.PlaySound(boostClip);

            if (shieldCoroutine != null)
            {
                StopCoroutine(shieldCoroutine);
            }
            shieldCoroutine = StartCoroutine(ShieldCoroutine(collision));
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            if (isTwiceCoinActive) scoreManager.IncreaseScore(2);
            else scoreManager.IncreaseScore(1);

            MusicSettingManager.instance.PlaySound(coinClip);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Magnet"))
        {
            if (isNitroActive) return;

            MusicSettingManager.instance.PlaySound(boostClip);

            if (magnetCoroutine != null)
            {
                StopCoroutine(magnetCoroutine);
            }
            magnetCoroutine = StartCoroutine(MagnetRoutine());
            Destroy(collision.gameObject);



        }
        else if (collision.gameObject.CompareTag("TwiceCoin"))
        {
            if(isNitroActive) return;

            MusicSettingManager.instance.PlaySound(boostClip);

            if (twiceCoinCoroutine != null)
            {
                StopCoroutine(twiceCoinCoroutine);
            }
            twiceCoinCoroutine = StartCoroutine(TwiceCoinCoroutine(collision));
        }
        else if (collision.gameObject.CompareTag("Nitro"))
        {
            if(isNitroActive) return;
            if (isNitroPicked || isMissilePicked) return;

            MusicSettingManager.instance.PlaySound(boostClip);

            isNitroPicked = true;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Missile"))
        {
            if(isNitroActive) return;
            if (isNitroPicked || isMissilePicked) return;

            MusicSettingManager.instance.PlaySound(boostClip);

            Debug.Log("Collided");
            isMissilePicked = true;
            Destroy(collision.gameObject);
        }
    }

    

    IEnumerator ShieldCoroutine(Collision collision)
    {
        isShieldActive = true;
        shieldTimer = pickupTime;
        Destroy(collision.gameObject);

        while (shieldTimer > 0)
        {
            shieldTimer -= Time.deltaTime;
            yield return null;
        }

        shieldTimer = 0;
        isShieldActive = false;
    }

    IEnumerator TwiceCoinCoroutine(Collision collision)
    {
        isTwiceCoinActive = true;
        twiceCoinTimer = pickupTime;
        Destroy(collision.gameObject);

        while (twiceCoinTimer > 0)
        {
            twiceCoinTimer -= Time.deltaTime;
            yield return null;
        }

        twiceCoinTimer = 0;
        isTwiceCoinActive = false;
    }

    IEnumerator MagnetRoutine()
    {
        Debug.Log("magnet enabled");

        isMagnetActive = true;
        magnetTimer = pickupTime;
        collector.gameObject.SetActive(true);

        while (magnetTimer > 0)
        {
            magnetTimer -= Time.deltaTime;
            yield return null;
        }

        magnetTimer = 0;
        isMagnetActive = false;
        collector.gameObject.SetActive(false);

        Debug.Log("magnet disabled");

    }



}
