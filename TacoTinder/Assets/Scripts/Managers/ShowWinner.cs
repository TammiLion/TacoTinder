using UnityEngine;
using System.Collections;

public class ShowWinner : MonoBehaviour {

    public Sprite winAquaman;
    public Sprite winPyramid;
    public Sprite winInca;
    public Sprite winJapan;
	public GameObject winScreen;
	
    public void showWinScreen (Player player)
    {
		winScreen.SetActive (true);
		if (player.god == "aquaman") winScreen.GetComponent<SpriteRenderer> ().sprite = winAquaman;

		if (player.god == "pyramid") 		winScreen.GetComponent<SpriteRenderer> ().sprite = winPyramid;

		if (player.god == "inca") 		winScreen.GetComponent<SpriteRenderer> ().sprite = winInca;

		if (player.god == "japan") 		winScreen.GetComponent<SpriteRenderer> ().sprite = winJapan;
        //Instantiate(winIMG, Vector3.zero, Quaternion.identity);
    }
	
	
}
