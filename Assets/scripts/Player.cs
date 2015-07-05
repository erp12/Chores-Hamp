using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public int xLoc;
	public int yLoc;
	private float startTime;

	private MapBehavior map;
	private Globals globals;

	// Use this for initialization
	void Start () {
		globals = Camera.main.GetComponent<Globals> ();
		map = GameObject.FindGameObjectWithTag ("Map").GetComponent<MapBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Move (0, -1);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			Move (0, 1);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Move (1, 0);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Move (-1, 0);
		}
	}

	public void Move(int deltaX, int deltaY) {	
		char potentialNewLoc = map.CharInMap (yLoc + deltaY, xLoc + deltaX);
		print (potentialNewLoc);
		if (potentialNewLoc != '-') {

			if (map.CharInMap (yLoc, xLoc) == 'r') {
				map.map[yLoc, xLoc].GetComponent<Image>().color = Color.gray;
			} else {
				foreach (Image childImg in map.map[yLoc, xLoc].GetComponentsInChildren<Image>()) {
					childImg.color = Color.white;
				}
			}

			xLoc += deltaX;
			yLoc += deltaY;

			map.map[yLoc, xLoc].GetComponent<Image>().color = Color.red;
			foreach (Image childImg in map.map[yLoc, xLoc].GetComponentsInChildren<Image>()) {
				childImg.color = Color.red;
			}
		}

	}
}