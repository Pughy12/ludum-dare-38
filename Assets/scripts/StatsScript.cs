using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScript : MonoBehaviour {

	public GameObject lost;
	public GameObject saved;
	
	// Update is called once per frame
	void Update () {
		saved.GetComponent<Text> ().text = MainController.instance.gameController.getPlayer ().getNumSuccessfulEvents ().ToString();
		lost.GetComponent<Text> ().text = MainController.instance.gameController.getPlayer ().getNumFailedEvents ().ToString();
	}
}
