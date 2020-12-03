using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
     //user defined functions
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);
    }

    public void LoadNextScene(int sceneID)
    {
        SceneManager.LoadSceneAsync(sceneID);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
    }
	
    public void CheckPreloadScene()
    {
        GameObject check = GameObject.Find("__app");
        if (check == null)
        { UnityEngine.SceneManagement.SceneManager.LoadScene(0); }
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
