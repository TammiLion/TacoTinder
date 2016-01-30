using UnityEngine;
using System.Collections;

public class ShowWinner : MonoBehaviour {

    public Sprite winAquaman;
    public Sprite winPyramid;
    public Sprite winInca;
    public Sprite winJapan;

    Sprite winIMG;

    // Use this for initialization
    void Start () {
	    
	}

    void showWinScreen (Player player)
    {
        if (player.name == "aquaman") winIMG = winAquaman;
        if (player.name == "pyramid") winIMG = winPyramid;
        if (player.name == "inca") winIMG = winInca;
        if (player.name == "japan") winIMG = winJapan;

        Instantiate(winIMG, Vector3.zero, Quaternion.identity);
    }
	
	
}
