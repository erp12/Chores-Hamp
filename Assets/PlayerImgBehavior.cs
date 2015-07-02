using UnityEngine;
using System.Collections;

public class PlayerImgBehavior : MonoBehaviour {

	RectTransform myRT;
	GameObject playerLoc;

	// Use this for initialization
	void Start () {
		myRT = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerLoc = GameObject.FindGameObjectWithTag ("Player");
		myRT.position = playerLoc.transform.position;
	}
}
