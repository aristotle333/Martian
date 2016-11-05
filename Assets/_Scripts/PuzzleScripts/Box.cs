using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Box : MonoBehaviour {

    public bool                 isInBlueRoom;
    public bool                 isStatic;
    public GameObject           roomReference;

    void Start() {
        roomReference = this.transform.parent.gameObject;

        if (this.transform.localPosition.x > 0) {
            isInBlueRoom = false;
        }
        else {
            isInBlueRoom = true;
        }
    }




    // Call this whenever a box is moving and needs to recalculate if it is in a red or a blue room
    void updateRoom() {
        if (this.transform.localPosition.x > 0) {
            isInBlueRoom = false;
        }
        else {
            isInBlueRoom = true;
        }
    }


}
