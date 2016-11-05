using UnityEngine;
using System.Collections;

public class Q1Manager : MonoBehaviour {
    public GameObject bear;
    public GameObject bunny;
    public GameObject hellephant;
    private bool[,] x_wall_array = new bool[6, 6];
    private bool[,] z_wall_array = new bool[6, 6];
    private bool trap_triggered = false;
    public static Q1Manager S;
    public GameObject wall_x;
    public GameObject wall_z;
    GameObject challenge1;
    GameObject door, trap, secret_path, falling_wall;
    Vector3 pos, trap_pos;
    Vector3 pos_offset_x = new Vector3(-5, 0, 0);
    Vector3 pos_offset_z = new Vector3(0, 0, 5);

	// Use this for initialization
	void Start () {
        S = this;
        challenge1 = GameObject.Find("Q1Manager");
        pos = transform.position;
        #region create map bool
        for (int col = 0; col < 5; col++) {
            x_wall_array[0, col] = true;
        }
        for (int col = 1; col < 5; col++) {
            x_wall_array[5, col] = true;
        }
        for (int col = 1; col < 4; col++) {
            x_wall_array[1, col] = true;
        }
        for (int col = 1; col < 3; col++) {
            x_wall_array[4, col] = true;
        }
        for (int row = 0; row < 5; row++) {
            z_wall_array[row, 0] = true;
            z_wall_array[row, 5] = true;
        }
        for (int row = 1; row < 4; row++) {
            z_wall_array[row, 1] = true;
            z_wall_array[row, 3] = true;
            z_wall_array[row, 4] = true;
        }

        #endregion

        #region create map
        for (int row = 0; row < 6; row++) {
            for (int col = 0; col < 6; col++) {
                Vector3 delta_pos = new Vector3(-10 * col, 0, 10 * row);
                if (x_wall_array[row, col]) {
                    GameObject x = Instantiate(wall_x, pos + delta_pos + pos_offset_x, Quaternion.identity) as GameObject;
                    x.transform.SetParent(challenge1.transform, true);
                }
                if (z_wall_array[row, col]) {
                    GameObject z = Instantiate(wall_z, pos + delta_pos + pos_offset_z, Quaternion.identity) as GameObject;
                    z.transform.SetParent(challenge1.transform, true);
                }
            }
        }
        #endregion
        
        #region create gameobject door
        door = Instantiate(wall_x, new Vector3(0, 0, 10 * 5) + pos + pos_offset_x, Quaternion.identity) as GameObject;
        door.transform.SetParent(challenge1.transform, true);
        #endregion
    
        #region trap
        trap = Instantiate(wall_x, new Vector3(-10 * 3, 0, 10 * 4) + pos + pos_offset_x, Quaternion.identity) as GameObject;
        trap.transform.SetParent(challenge1.transform, true);
        trap_pos = trap.transform.position + pos_offset_z;
        #endregion

        #region secret_path
        secret_path = Instantiate(wall_z, new Vector3(-10 * 1, 0, 10 * 4) + pos + pos_offset_z, Quaternion.identity) as GameObject;
        secret_path.transform.SetParent(challenge1.transform, true);
        secret_path.tag = "Destructible";
        #endregion


    }

    // Update is called once per frame
    void Update () {
        Vector3 trap_distance = Player.S.transform.position - trap_pos;
        if (trap_distance.magnitude <= 3 && !trap_triggered)
        {
            //trigger trap
            trap_triggered = true;
            wall_fall();
            Destroy(trap);
            Vector3 Spawning_pos = pos + new Vector3(-10 * 3, 5, 10 * 1) + pos_offset_x + pos_offset_z;
           for (int i = 0; i < 10; i++)
            {

                Instantiate(bear, Spawning_pos, Quaternion.identity);
                Spawning_pos.x+=2;
                Instantiate(bunny, Spawning_pos, Quaternion.identity);
                Spawning_pos.x-=2;
                Spawning_pos.z+=2;
            }
        }
	}

    public void Q1Start (){
        Destroy(door);
    }
    

    public void quest_finish()
    {
        Debug.Assert(Player.S.carriesSignalTowerPart);
        Player.S.carriesSignalTowerPart = true;

		GameManager.S.setPromptText (Strings.BRINGBACK);
    }
    private void wall_fall ()
    {
        falling_wall = Instantiate(wall_z, new Vector3(-10 * 4, 0, 10 * 4) + pos + pos_offset_z, Quaternion.identity) as GameObject;
        falling_wall.transform.SetParent(challenge1.transform, true);
    }
}
