using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void LoadScene(string index)
    {
        LevelManager.Instance.LoadLevel(index);
        AudioManager.instance.StopClip();

    }

    public void Quit()
    {
        Application.Quit();
    }
}
