using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

    public const float  oxygenDropChance = 0.20f;
//    public const float  ironDropChance = 0.80f;
    public int          spawnRate = 60;
    public int          sizeOfSpawningSquare = 200;

    // Resource GameObject prefabs
    [SerializeField]
    private GameObject oxygenPrefab;
//    [SerializeField]
//    private GameObject ironPrefab;

    public int          heightOrigin = 150;     // Minimum height for resource to drop
    public int          heightOffset = 150;     // Random variation upwards

    private int         currentFrame = 0;       // Just a counter


    void Start() {

    }

    void Update() {
        ++currentFrame;
        if (currentFrame >= spawnRate) {
            currentFrame = 0;
            // Spawn an resource randomly
            Vector3 res_pos = GeneratePosition();
            GameObject go;
            float randomVal = Random.value;
//            if (randomVal < ironDropChance) {
//                // Instantiate Iron
//                go = Instantiate(ironPrefab, res_pos, Quaternion.identity) as GameObject;
//            }
//            else {
                // Instantate Oxygen
                go = Instantiate(oxygenPrefab, res_pos, Quaternion.identity) as GameObject;
//            }
            go.transform.SetParent(this.gameObject.transform, true);
        }
    }

    Vector3 GeneratePosition() {
        Vector3 result = Vector3.zero;

        // Get x
        if (Random.value < 0.5) {
            result.x = Player.S.gameObject.transform.position.x + Random.Range(0, sizeOfSpawningSquare);
        }
        else {
            result.x = Player.S.gameObject.transform.position.x - Random.Range(0, sizeOfSpawningSquare);
        }

        // Get z
        if (Random.value < 0.5) {
            result.z = Player.S.gameObject.transform.position.z + Random.Range(0, sizeOfSpawningSquare);
        }
        else {
            result.z = Player.S.gameObject.transform.position.z - Random.Range(0, sizeOfSpawningSquare);
        }

        // Get y
        result.y = heightOrigin + Random.Range(0, heightOffset);

        return result;
    }


}
