using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {
    public float dmg;
    private float range;
    public void set_dmg (float dmg)
    {
        this.dmg = dmg;
    }
    public void Set_range(float range)
    {
        this.range = range;
    }


	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * Time.deltaTime * Utils.projectile_velocity;
    }
	
	// Update is called once per frame
	void Update () {
        //the projectile destroy after 10 seconds
       
    }

    void OnTriggerEnter (Collider coll)
    {
        if (coll.tag != "Player")
        {
            Destroy(gameObject);
        }
        
    }

}
