using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class SponsorsScreen : MonoBehaviour {

    public int waitTime;

    // Use this for initialization
    void Start() {
        StartCoroutine(ExecuteAfterTime(waitTime));
    }

    IEnumerator ExecuteAfterTime(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //SceneManager.LoadScene("CharacterSelectionMenu");

    }
}
