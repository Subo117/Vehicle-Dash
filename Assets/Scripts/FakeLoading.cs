using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FakeLoading : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text sliderText;

    private void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 100;
        slider.value = 0;

        StartCoroutine(FakeLoadingCoroutine());
    }

    IEnumerator FakeLoadingCoroutine()
    {
        yield return StartCoroutine(FillTo(30, 1f));

        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(FillTo(90, 1.5f));

        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(FillTo(100, 0.25f));

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator FillTo(float targetValue, float duration)
    {
        float startValue = slider.value;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            slider.value = Mathf.Lerp(startValue, targetValue, time / duration);
            sliderText.text = ((int)slider.value).ToString();
            yield return null;
        }

        slider.value = targetValue;
    }
}
