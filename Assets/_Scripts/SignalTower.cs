using UnityEngine;
using System.Collections;

public class SignalTower : MonoBehaviour {

    public GameObject stage0;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;

    private GameObject TerminalReference;


    void Awake() {
        TerminalReference = GameObject.Find("Terminal");
    }

    public void CreateBase() {
        GameObject baseGO = Instantiate(stage0, this.transform.position, Quaternion.identity) as GameObject;
        baseGO.transform.SetParent(this.gameObject.transform, true);
        print("Creating stage 0");
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player" && Player.S.carriesSignalTowerPart) {
            print("Player is in Signal Tower Collider and carries signal tower part");
            Player.S.carriesSignalTowerPart = false;
            int constructionStage = TerminalReference.GetComponent<Terminal>().numSteelBeamsMade;

            if (constructionStage == Terminal.FIRSTQUESTTRIGGER) {
                DestroyAllChildren();
                GameObject baseGO = Instantiate(stage1, this.transform.position, Quaternion.identity) as GameObject;
                baseGO.transform.SetParent(this.gameObject.transform, true);
                print("Creating stage 1");
                TerminalReference.GetComponent<Terminal>().questComplete();
            }
            else if(constructionStage == Terminal.SECONDQUESTTRIGGER) {
                DestroyAllChildren();
                GameObject baseGO = Instantiate(stage2, this.transform.position, Quaternion.identity) as GameObject;
                baseGO.transform.SetParent(this.gameObject.transform, true);
                print("Creating stage 2");
                TerminalReference.GetComponent<Terminal>().questComplete();
            }
            else if (constructionStage == Terminal.THIRDQUESTTRIGGER) {
                DestroyAllChildren();
                GameObject baseGO = Instantiate(stage3, this.transform.position, Quaternion.identity) as GameObject;
                baseGO.transform.SetParent(this.gameObject.transform, true);
                print("Creating stage 3");
                TerminalReference.GetComponent<Terminal>().questComplete();
            }
        }
    }

    void DestroyAllChildren() {
        foreach (Transform child in this.transform) {
            Destroy(child.gameObject);
        }
    }

}
