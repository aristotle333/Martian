using UnityEngine;
using System.Collections;

public class SMG : Weapon_base
{

    // Use this for initialization
    static private int lvl = 0;
    public override void Start()
    {
        range = 2;
        dmg = Utils.smg_base_dmg + lvl * Utils.smg_upgrade_dmg;
        fire_rate = Utils.smg_base_rate + lvl * Utils.smg_upgrade_rate;
        fire_cool_down = 1 / fire_rate;

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //check change gun
        //change_weapon(new_weapon);

        //check weapon upgrade
        //level_up();
    }
    public override void level_up()
    {
        dmg += Utils.smg_upgrade_dmg;
        fire_rate += Utils.smg_upgrade_rate;
        fire_cool_down = 1 / fire_rate;
    }
}
