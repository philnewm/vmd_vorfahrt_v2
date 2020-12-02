using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
     //user defined functions
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex + 1, LoadSceneMode.Single);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
		else
		{
			Application.Quit();
		}
	}
}
