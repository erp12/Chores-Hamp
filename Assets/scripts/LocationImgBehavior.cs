using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocationImgBehavior : MonoBehaviour {

	public Globals globals;

	public bool isPlayerLoc;

	private Image myImg;
	private Button myButton;

	public Location loc;

	// Use this for initialization
	void Awake () {
		globals = Camera.main.GetComponent<Globals> ();
		myImg = GetComponent<Image> ();
		myButton = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void onClick() {
		LocationImgBehavior[] others = GameObject.FindObjectsOfType<LocationImgBehavior> ();
		foreach (LocationImgBehavior lib in others) {
			lib.unselect();
		}
		isPlayerLoc = true;
		myImg.color = Color.Lerp (Color.red, Color.white, 0.5f);

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

	public void unselect() {
		isPlayerLoc = false;
		myImg.color = Color.white;
	}
}
