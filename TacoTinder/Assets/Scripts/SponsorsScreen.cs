using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class SponsorsScreen : MonoBehaviour {

    public int waitTime;
	public Sprite characterScreen;

    // Use this for initialization
    void Start() {
		Invoke ("switchScreen", 5f);
    }

	private void switchScreen() {
		GetComponent<SpriteRenderer> ().sprite = characterScreen;
		StartCoroutine(ExecuteAfterTime(waitTime));
	}

    IEnumerator ExecuteAfterTime(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
		Application.LoadLevel ("CharacterSelectionMenu");
        //SceneManager.LoadScene("CharacterSelectionMenu");

    }
}
