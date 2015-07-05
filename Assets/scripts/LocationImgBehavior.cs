using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocationImgBehavior : MonoBehaviour {

	public Globals globals;
	public bool isPlayerLoc;
	private Image myImg;
	public Location loc;

	// Use this for initialization
	void Awake () {
		globals = Camera.main.GetComponent<Globals> ();
		myImg = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnPlayerEnter() {
		isPlayerLoc = true;
		if (loc != null) {
			if (globals.hasSymbols.Contains (loc.Key) && 
				globals.hasSymbols.Contains (loc.Takes)) {
				globals.hasSymbols.Remove (loc.Takes);
				globals.hasSymbols.Add (loc.Gives);
			}
		} else {
			if (globals.checkHaveNeeded()) {
				globals.showWinText();
			} else {
				// Maybe reload scene?
			}
		}
	}

	public void OnPlayerExit() {
		isPlayerLoc = false;
		myImg.color = Color.white;
	}
}
