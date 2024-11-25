using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void LoadScene(string index)
    {
        LevelManager.Instance.LoadLevel(index);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
