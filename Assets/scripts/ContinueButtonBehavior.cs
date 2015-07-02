using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContinueButtonBehavior : MonoBehaviour {

	public Canvas infoCanvas;
	
	public void hideInfo(){
		if (infoCanvas.enabled) {
			infoCanvas.enabled = false;
		}
	}
}
