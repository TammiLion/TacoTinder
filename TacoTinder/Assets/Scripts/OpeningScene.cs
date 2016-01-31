using UnityEngine;
using System.Collections;

public class OpeningScene : MonoBehaviour {


    public int waitTime;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(waitTime));
    }

    IEnumerator ExecuteAfterTime(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //SceneManager.LoadScene("Sponsors");

    }
}