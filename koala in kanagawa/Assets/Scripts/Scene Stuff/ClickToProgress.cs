using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneOnClick : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.LoadNextScene();
        }
    }
}
