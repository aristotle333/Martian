using UnityEngine;
using System.Collections;

public class HiddenDoor : MonoBehaviour {
    public static HiddenDoor S;
	public int counter;
	// Use this for initialization

    void Awake() {
        S = this;
    }

	void Start () {
		counter = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (counter <= 0)
			this.gameObject.SetActive (false);
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "PlayerProjectile")
			counter--;
	}

	public void maze_win()
	{
        Player.S.carriesSignalTowerPart = true;
		this.gameObject.SetActive (false);
	}


}
