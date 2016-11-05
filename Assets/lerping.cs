using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class lerping : MonoBehaviour {
	public Vector3 startpos;
	public Vector3 endpos;
	public List<float> offsets;//x,y,z
	public float counter;
	// Use this for initialization
	void Start () {
		startpos = this.transform.position;
		endpos = new Vector3 (startpos.x + offsets [0], startpos.y + offsets [1], startpos.z + offsets[2]);
	
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter < 90) {
			this.transform.position = Vector3.Lerp (startpos, endpos, counter / 90);
		} else if (counter >= 90 && counter < 180) 
		{
			this.transform.position = Vector3.Lerp (endpos, startpos, counter / 90 -1);

			
		} else
			counter = 0;
	
	}
}
