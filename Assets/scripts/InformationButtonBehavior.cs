using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InformationButtonBehavior : MonoBehaviour {

	public Canvas infoCanvas;

	public void showInfo(){
		if (!infoCanvas.enabled) {
			infoCanvas.enabled = true;
		}
	}

}
