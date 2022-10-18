using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void LoadSceneCredits()
    {
        SceneManager.LoadScene("credits");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
