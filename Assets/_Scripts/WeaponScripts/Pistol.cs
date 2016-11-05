using UnityEngine;
using System.Collections;

public class Pistol : Weapon_base {

    // Use this for initialization
    static private int lvl = 0;
	public override void Start () {
        range = 3f;
        dmg = Utils.pistol_base_dmg + lvl * Utils.pistol_upgrade_dmg;
        fire_rate = Utils.pistol_base_rate + lvl * Utils.pistol_upgrade_rate;
        fire_cool_down = 1 / fire_rate;
        //pistol is used for puzzle solving
        
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            muzzle = GameObject.Find("Muzzle");
            Vector3 pos = gameObject.transform.position;
            fire_dir = Player.S.playerDirection;
            pos += fire_dir.normalized * projectile_spawning_offset;
            fire(pos, fire_dir);

            //reduce the cool down every update
        }
        fire_timer -= Time.deltaTime;
        if (fire_timer <= 0)
        {
            fire_timer = 0;
        }
    }
    public override void level_up()
    {
        dmg += Utils.pistol_upgrade_dmg;
        fire_rate += Utils.pistol_upgrade_rate;
        fire_cool_down = 1 / fire_rate;
    }
}
