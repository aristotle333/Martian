using UnityEngine;
using System.Collections;

public class rotateblock : MonoBehaviour {
	public int counter;
	public bool start;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerEnter(Collider coll)
	{
		print (coll.tag);
		if(coll.tag == "PlayerProjectile")
		{
			this.transform.Rotate (0, 90, 0);
		}

	}
}
