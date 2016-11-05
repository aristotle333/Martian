using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * Time.deltaTime * Utils.projectile_velocity;

    }
	
	// Update is called once per frame
	void Update () {
		
	
	}
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag != "Player" && coll.tag != "Pistol")
        {
            Destroy(gameObject);
        }
        
    }

}
