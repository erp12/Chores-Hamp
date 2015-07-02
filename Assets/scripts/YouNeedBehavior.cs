using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class YouNeedBehavior : MonoBehaviour {

	public Globals globals;
	public Image[] imgs;

	// Use this for initialization
	void Awake () {
		imgs = new Image[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			imgs[i] = transform.Find("SymbolImg " + i).GetComponent<Image>();
		}
	}
	
	void Update () {
		List<string> needSymbols = globals.needSymbols;

		foreach (string s in globals.hasSymbols) {
			if (needSymbols.Contains(s)) needSymbols.Remove(s);
		}

		for (int i = 0; i < needSymbols.Count; i++) {
			imgs[i].overrideSprite = Resources.Load<Sprite>(needSymbols[i]);
			imgs[i].color = Color.white;
		}
		for (int i = needSymbols.Count; i < imgs.Length; i++) {
			imgs[i].color = Color.clear;
		}
	}
}
