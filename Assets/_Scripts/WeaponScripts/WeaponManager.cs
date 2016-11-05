using UnityEngine;
using System.Collections;
public enum weapons { Pistol, SMG, Rifle, BaseWeapon };

public class WeaponManager : MonoBehaviour {
    public static WeaponManager S;
    public GameObject pistol;
    public GameObject SMG;
    public GameObject rifle;
    public GameObject base_weapon;
    public bool[] ownership = new bool[4];
    private static weapons current_weapon = weapons.Pistol;
    private static GameObject current_weapon_go;
	// Use this for initialization

    void Awake ()
    {
        S = this;
    }
	void Start ()
    {
        ownership[0] = true;
        ownership[3] = true;
        setWeapon(current_weapon);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            current_weapon = weapons.Pistol;
            setWeapon(current_weapon);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            current_weapon = weapons.SMG;
            setWeapon(current_weapon);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            current_weapon = weapons.Rifle;
            setWeapon(current_weapon);
        }

    }

    public void setWeapon(weapons new_weapon)
    {
        if (ownership[(int)new_weapon])
        {
            GameObject new_weapon_prefab = null;
            switch (new_weapon)
            {
                case weapons.BaseWeapon:
                    new_weapon_prefab = base_weapon;
                    break;
                case weapons.Pistol:
                    new_weapon_prefab = pistol;
                    break;
                case weapons.Rifle:
                    new_weapon_prefab = rifle;
                    break;
                case weapons.SMG:
                    new_weapon_prefab = SMG;
                    break;
            }
            GameObject new_weapon_go = Instantiate(new_weapon_prefab, Vector3.zero, Quaternion.identity) as GameObject;
            new_weapon_go.transform.position = Vector3.zero;
            new_weapon_go.transform.SetParent(GameObject.Find("FirstPersonCharacter").transform, false);
            Destroy(current_weapon_go);
            current_weapon_go = new_weapon_go;
        }
    }
}
