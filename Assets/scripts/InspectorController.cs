using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorController : MonoBehaviour {

	public GameObject type;
	public GameObject chance;

	public GameObject asteroidModel;
	public GameObject spaceShipModel;
	
	public void displayHazard(Hazard h)
	{
		if (h.getHazardType() == HazardType.ASTEROID) {
			type.GetComponent<Text> ().text = "Asteroid (Evade)";
			asteroidModel.SetActive (true);
			spaceShipModel.SetActive (false);
		} else if (h.getHazardType() == HazardType.ENEMY) {
			type.GetComponent<Text> ().text = "Enemy (Cloak)";
			spaceShipModel.SetActive (true);
			asteroidModel.SetActive (false);
		}
		chance.GetComponent<Text> ().text = h.getChance ().ToString() + "%";
		this.transform.localPosition = new Vector3 (0, 0, -10);
	}

	void OnMouseDown()
	{
		close ();
	}

	public void close() 
	{
		this.transform.localPosition = new Vector3 (0, 50, -10);
	}
}