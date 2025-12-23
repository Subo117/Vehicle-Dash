using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void OnStart()
    {
        string selected = PlayerPrefs.GetString("SelectedVehicle");
        if(selected == "None")
        {
            Debug.Log("None");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
