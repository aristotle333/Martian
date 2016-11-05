using UnityEngine;
using System.Collections;

public class emit_light : MonoBehaviour {

    // Use this for initialization
    public GameObject light;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject go = Instantiate(light, transform.position, transform.rotation) as GameObject;
        Destroy(go, 1f);
	}
}
