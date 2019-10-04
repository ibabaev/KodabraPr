using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : Singleton<GameManager>
{
    public int LevelsNumber = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetActiveScene();
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            Application.Quit();
        }
    }

    public void LoadNext()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == LevelsNumber)
        {
            SceneManager.LoadScene(0);
            return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}