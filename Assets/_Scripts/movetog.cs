using UnityEngine;
using System.Collections;
public class movetog : MonoBehaviour {
	public bool InBlueRoom; // 1 is red and 2 is blue
	public GameObject mirrored;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (InBlueRoom == Player.S.isInBlueRoom) {
			Vector3 position = this.transform.localPosition;
			position.x = -position.x;
			print (position);
			mirrored.transform.localPosition = position;
		}
	
	}
}
