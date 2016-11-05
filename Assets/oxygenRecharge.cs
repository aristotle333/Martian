using UnityEngine;
using System.Collections;

public class oxygenRecharge : MonoBehaviour {
	public int oxygen_amount;
	public Material damaged;
	public bool start_charge;
	public string prompttext;
	public bool triggerexited;
	// Use this for initialization
	void Start () {
		prompttext = "Move closer to the tank and Press E to recharge oxygen";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.CompareTag("Player"))
			GameManager.S.setPromptText(prompttext);
	}

	void OnTriggerStay (Collider c) {
		//print (c.tag);
		if (c.CompareTag("Player")) {
			// Replendish oxyen
			if(Input.GetKey(KeyCode.E))
			{
				start_charge = true;		
			}
			if (start_charge) {
				if (oxygen_amount > 0) {
					if (Time.time % 0.5f == 0.0f) {
						GameManager.S.oxygenValue += 4;
						oxygen_amount -= 4;
					}
				} else {
					Material[] meterial = this.GetComponent<MeshRenderer> ().materials;
					meterial [0] = damaged;
					prompttext = "The oxygen tank is empty";
					this.GetComponent<MeshRenderer> ().materials = meterial;
					//this.GetComponent<MeshRenderer> ().materials [0] = damaged;
					//print (this.GetComponent<MeshRenderer> ().materials [0]);
				}
			}
		}
	}
	void OnTriggerExit(Collider c)
	{
		
		if (c.CompareTag ("Player"))
		{
			start_charge = false;
			GameManager.S.closePrompt ();
		}
	}
}
