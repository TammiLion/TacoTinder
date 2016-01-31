using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour {


    public int waitTime;

    // Use this for initialization
    void Start()
    {
        if (Input.anyKey)
            SceneManager.LoadScene("Sponsors");
    }

}