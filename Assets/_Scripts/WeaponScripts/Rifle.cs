using UnityEngine;
using System.Collections;

public class Rifle : Weapon_base
{

    // Use this for initialization
    static private int lvl = 0;
    public override void Start()
    {
        range = 4;
        dmg = Utils.rifle_base_dmg + lvl * Utils.rifle_upgrade_dmg;
        fire_rate = Utils.rifle_base_rate + lvl * Utils.rifle_upgrade_rate;
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
        dmg += Utils.rifle_upgrade_dmg;
        fire_rate += Utils.rifle_upgrade_rate;
        fire_cool_down = 1 / fire_rate;
    }
}
