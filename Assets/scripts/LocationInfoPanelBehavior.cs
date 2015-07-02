using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocationInfoPanelBehavior : MonoBehaviour {

	public Location location;
	public Image keyImg;
	public Image givesImg;
	public Image takesImg;

	void Awake() {
		keyImg = transform.FindChild("NeedsPanel").FindChild("KeyImg").GetComponent<Image>();
		givesImg = transform.FindChild("GivesPanel").FindChild("GivesImg").GetComponent<Image>();
		takesImg = transform.FindChild("TakesPanel").FindChild("TakesImg").GetComponent<Image>();
	}

	public void init(Location loc) {
		location = loc;

		transform.FindChild("NeedsPanel").FindChild("LocImg").GetComponent<Image>().sprite = Resources.Load<Sprite>(loc.Name);
		transform.FindChild("GivesPanel").FindChild("LocImg").GetComponent<Image>().sprite = Resources.Load<Sprite>(loc.Name);
		transform.FindChild("TakesPanel").FindChild("LocImg").GetComponent<Image>().sprite = Resources.Load<Sprite>(loc.Name);

		keyImg.sprite = Resources.Load<Sprite>(loc.Key);
		givesImg.sprite = Resources.Load<Sprite>(loc.Gives);
		takesImg.sprite = Resources.Load<Sprite>(loc.Takes);
	}
}
