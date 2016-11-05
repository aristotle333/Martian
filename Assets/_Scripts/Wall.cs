using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    private int _life;
	// Use this for initialization
	void Start () {
        life = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter (Collider coll)
    {
        if (coll.tag == "PlayerProjectile" && tag == "Destructible")
        {
            life--;
            
        }
    }
    public int life
    {
        get
        {
            return _life;
        }
        set
        {
            _life = value;
            if (life == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
