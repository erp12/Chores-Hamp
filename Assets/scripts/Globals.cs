using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Globals : MonoBehaviour {

	public TextAsset locationsXML;
	public Location[] locations;

	public Canvas infoCanvas;
	public GameObject LocInfoPanelPrefab;

	public List<string> hasSymbols;
	public List<string> needSymbols;

	public GameObject winTextObj;

	void Awake() {
		hasSymbols = new List<string>();
		needSymbols = new List<string>();

		locations = LocationContainer.LoadFromText(locationsXML.text).locations;

		foreach (Location l in locations) {
			GameObject locPanel = Instantiate(LocInfoPanelPrefab) as GameObject;
			locPanel.transform.SetParent(infoCanvas.transform, false);
			locPanel.transform.SetAsFirstSibling();
			locPanel.GetComponent<LocationInfoPanelBehavior>().init(l);
		}

		hasSymbols.Add("circle");
		hasSymbols.Add("plus");
		hasSymbols.Add("x");
		hasSymbols.Add("equals");
		hasSymbols.Add("#");

		needSymbols.Add("arch");
		needSymbols.Add("square");
		needSymbols.Add("triangle");
		needSymbols.Add("line");
	}

	public bool checkHaveNeeded() {
		foreach (string s in needSymbols) {
			if (!hasSymbols.Contains(s)) {
				return false;
			}
		}
		return true;
	}

	public Location getLocationByName (string n) {
		foreach (Location l in locations) {
			if (l.Name == n) {
				return l;
			}
		}
		return null;
	}

	public void showWinText() {
		winTextObj.SetActive (true);
	}
	
}
