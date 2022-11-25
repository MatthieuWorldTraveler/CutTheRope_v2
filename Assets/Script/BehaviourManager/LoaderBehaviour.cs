using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderBehaviour : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
