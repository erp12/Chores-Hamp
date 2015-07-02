using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class YouHaveBehavior : MonoBehaviour {

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
		List<string> hasSymbols = globals.hasSymbols;
		for (int i = 0; i < hasSymbols.Count; i++) {
			imgs[i].overrideSprite = Resources.Load<Sprite>(hasSymbols[i]);
			imgs[i].color = Color.white;
		}
		for (int i = hasSymbols.Count; i < imgs.Length; i++) {
			imgs[i].color = Color.clear;
		}
	}
}
