using UnityEngine;

public class DestroyAfterAnim : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1);
    }
}
