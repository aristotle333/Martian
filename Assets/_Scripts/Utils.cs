using UnityEngine;
using System.Collections;

public enum CollectiblesType { IRON, OXYGEN, HEALTH }

public class Utils : MonoBehaviour {

    //the statistics for weapons
    public const float pistol_base_dmg = 10;
    public const float pistol_base_rate = 100;
    public const float pistol_upgrade_dmg = 5;
    public const float pistol_upgrade_rate = 0.5f;
    public const float smg_base_dmg = 2;
    public const float smg_base_rate = 15;
    public const float smg_upgrade_dmg = 1;
    public const float smg_upgrade_rate = 2;
    public const float rifle_base_dmg = 5;
    public const float rifle_base_rate = 10;
    public const float rifle_upgrade_dmg = 3;
    public const float rifle_upgrade_rate = 1;
    public const float projectile_velocity = 2000;
    public const float turrent_dmg = 1;
    public const float turrent_rate = 10;

    // Player power ups
    //static public Vector3 jetPackAcceleration = new Vector3(0, 0.5f, 0);
    public const float jetPackAcceleration = 10f;
    public const float jetPackMaxSpeed = 30f;
}
