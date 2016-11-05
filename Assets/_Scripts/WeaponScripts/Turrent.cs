using UnityEngine;
using System.Collections;

public class Turrent : Weapon_base {

    public Vector3 player_pos = Player.S.transform.position;
    public GameObject fireLocation;
    private int _life;

    // Use this for initialization
    public override void Start () {
        range = 0.5f;
        dmg = Utils.turrent_dmg;
        fire_rate = Utils.turrent_rate;
        fire_cool_down = 1 / fire_rate;
        life = 10;
    }
	
	// Update is called once per frame
	public override void Update () {
        player_pos = Player.S.transform.position;
        Vector3 turrent_pos = fireLocation.transform.position;
        if ((turrent_pos - player_pos).magnitude < 20)
        {
            fire_dir = fireLocation.transform.forward;
            Vector3 pos = fireLocation.transform.position;
            fire(pos, fire_dir);
            print("i fired");
        }
        fire_timer -= Time.deltaTime;
        if (fire_timer <= 0)
        {
            fire_timer = 0;
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
            if (_life == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter (Collider coll)
    {
        if (coll.tag == "PlayerProjectile")
        {
            life--;
        }
    }
}
