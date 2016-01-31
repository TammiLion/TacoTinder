using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("KeyCode pressed");
            //SceneManager.LoadScene("Sponsors");
			Application.LoadLevel("Sponsors");
        }
    }
}