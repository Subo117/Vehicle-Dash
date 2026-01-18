using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class LoadScreenManager : MonoBehaviour
{
    public Slider loadingSlider;
    public string sceneToLoad;

    float target, progress;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    void Update()
    {
        progress = Mathf.MoveTowards(progress, target, 2 * Time.deltaTime);
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            target = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;

            // Scene ready
            if (operation.progress >= 0.9f)
            {
                loadingSlider.value = 1f;
                yield return new WaitForSeconds(1f); // small delay
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
