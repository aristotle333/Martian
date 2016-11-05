using UnityEngine;
using System.Collections;

public class ShotVisual : MonoBehaviour {

    public GameObject lazer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void fire ()
    {
        GameObject go = Instantiate(lazer, transform.position, transform.rotation) as GameObject;
        Destroy(go, 3f);
    }
}
