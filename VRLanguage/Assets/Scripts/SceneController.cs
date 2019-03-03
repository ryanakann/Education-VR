using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
