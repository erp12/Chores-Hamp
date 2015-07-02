using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapBehavior : MonoBehaviour {

	public Globals globals;
	public GameObject emptyTile;
	private float tileSize = 25f;

	// 1 PREFAB FOR EACH LOCATION
	//public GameObject 

	private RectTransform myRT;
	private GridLayoutGroup grid;

	private int numCols;
	private int numRows;

	public TextAsset mapFile;
	private List<string> mapFileLines;
	public GameObject locImgPrefab;
	
	public Image player;

	void Awake () {
		globals = Camera.main.GetComponent<Globals> ();
		myRT = GetComponent<RectTransform> ();
		grid = GetComponent<GridLayoutGroup> ();
		ReadFromFile ();
	}

	// Use this for initialization
	void Start () {
		grid.cellSize = new Vector2 (tileSize, tileSize);
		numCols = (int)(myRT.sizeDelta.x / tileSize);
		numRows = (int)(myRT.sizeDelta.y / tileSize);

		DrawMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DrawMap() {
		for (int r = 0; r < numRows; r++) {
			for (int c = 0; c < numCols; c++) {
				GameObject tile = Instantiate(emptyTile) as GameObject;
				tile.transform.SetParent(transform);
				tile.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);

				tile.tag = ""+CharInMap(r, c);

				if (tile.tag == "r") {
					tile.GetComponent<Image>().color = Color.gray;
				} else if (tile.tag == "H") {
					GameObject locImg = Instantiate(locImgPrefab) as GameObject;
					locImg.transform.SetParent(tile.transform);
					Image i = locImg.GetComponent<Image>();
					i.sprite = Resources.Load<Sprite>("Home");
					i.color = Color.white;
					i.transform.localScale = new Vector2(1f,1f);

					locImg.GetComponent<LocationImgBehavior>().isPlayerLoc = true;
					locImg.GetComponent<LocationImgBehavior>().loc = null;
					locImg.GetComponent<LocationImgBehavior>().onClick();
				}
				else if (tile.tag == "L") {
					GameObject locImg = Instantiate(locImgPrefab) as GameObject;
					locImg.transform.SetParent(tile.transform);
					Image i = locImg.GetComponent<Image>();
					i.sprite = Resources.Load<Sprite>("Library");
					i.color = Color.white;
					i.transform.localScale = new Vector2(1f,1f);

					locImg.GetComponent<LocationImgBehavior>().loc = globals.getLocationByName("Library");
				}
				else if (tile.tag == "P") {
					GameObject locImg = Instantiate(locImgPrefab) as GameObject;
					locImg.transform.SetParent(tile.transform);
					Image i = locImg.GetComponent<Image>();
					i.sprite = Resources.Load<Sprite>("PostOffice");
					i.color = Color.white;
					i.transform.localScale = new Vector2(1f,1f);

					locImg.GetComponent<LocationImgBehavior>().loc = globals.getLocationByName("PostOffice");
				}
				else if (tile.tag == "M") {
					GameObject locImg = Instantiate(locImgPrefab) as GameObject;
					locImg.transform.SetParent(tile.transform);
					Image i = locImg.GetComponent<Image>();
					i.sprite = Resources.Load<Sprite>("Museum");
					i.color = Color.white;
					i.transform.localScale = new Vector2(1f,1f);

					locImg.GetComponent<LocationImgBehavior>().loc = globals.getLocationByName("Museum");
				}
				else if (tile.tag == "F") {
					GameObject locImg = Instantiate(locImgPrefab) as GameObject;
					locImg.transform.SetParent(tile.transform);
					Image i = locImg.GetComponent<Image>();
					i.sprite = Resources.Load<Sprite>("FishMarket");
					i.color = Color.white;
					i.transform.localScale = new Vector2(1f,1f);

					locImg.GetComponent<LocationImgBehavior>().loc = globals.getLocationByName("FishMarket");
				}
			}
		}
	}

	public void ReadFromFile() {
		mapFileLines = new List<string>(mapFile.text.Split('\n'));
	}

	public char CharInMap(int r, int c) {
		return mapFileLines [r].ToCharArray () [c];
	}
}
