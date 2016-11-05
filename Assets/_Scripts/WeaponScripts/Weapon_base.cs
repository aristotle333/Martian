using UnityEngine;
using System.Collections;



public class Weapon_base : MonoBehaviour {
    public GameObject projectile;
    public GameObject muzzle;
    protected Vector3 fire_dir;
    protected const float projectile_spawning_offset = 1;
    protected float dmg=1;
    protected float range = 1;
    protected float fire_rate = 4f;
    protected float fire_cool_down;
    protected float fire_timer = 0;
    
    

	// Use this for initialization
	public virtual void Start () {
        fire_cool_down = 1 / fire_rate;
    }
	
	// Update is called once per frame
	public virtual void Update () {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            muzzle = GameObject.Find("Muzzle");
            Vector3 pos = gameObject.transform.position;
            fire_dir = Player.S.playerDirection;
            pos += fire_dir.normalized *projectile_spawning_offset ;
            fire(pos,fire_dir);
            
            //reduce the cool down every update
        }
        fire_timer -= Time.deltaTime;
        if (fire_timer <= 0)
        {
            fire_timer = 0;
        }
    }
    protected void fire(Vector3 position,Vector3 direction)
    {
        //check if the weapon is legit to fire at the moment
        if (fire_timer == 0)
        {
			this.GetComponent<AudioSource>().Play ();
            GameObject bullet = Instantiate(projectile, position, transform.rotation) as GameObject;
            bullet.GetComponent<projectile>().set_dmg(dmg);
            Destroy(bullet, range);
            fire_timer = fire_cool_down;
            muzzle.GetComponent<ShotVisual>().fire();
        }
        //weapons cant fire until the cool down time has passed;
    }

    public virtual void level_up() { }
    
}
