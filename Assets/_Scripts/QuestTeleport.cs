using UnityEngine;
using System.Collections;

public class QuestTeleport : MonoBehaviour {


    void OnTriggerEnter(Collider coll) {
		print (coll.tag);
        if (coll.gameObject.name == "Player") {
            if (this.gameObject.name == "DoorQ1" && !Player.S.playerCollidedWithQuestDoor) {
                if (Terminal.S.numSteelBeamsMade == Terminal.FIRSTQUESTTRIGGER && !Player.S.carriesSignalTowerPart) {
                    Debug.Log("Player collided!");
                    this.GetComponent<AudioSource>().Play();
                    Debug.Log("Starting Quest 1");
                    Player.S.isInAPuzzleRoom = true;
                    Player.S.playerCollidedWithQuestDoor = true;
                    StartCoroutine(GameManager.S.teleportToNextLevel());
                    MusicManager.S.playMazeMusic();
                }
                else {
                    if (Player.S.carriesSignalTowerPart) {
                        GameManager.S.setPromptText(Strings.NEEDTOBRINGBACKTOBASE);
                    }
                    else {
                        GameManager.S.setPromptText(Strings.QUEST1NOTREADY);
                    }
                }
            }
            if (this.gameObject.name == "DoorQ2" && !Player.S.playerCollidedWithQuestDoor) {
                if (Terminal.S.numSteelBeamsMade == Terminal.SECONDQUESTTRIGGER && !Player.S.carriesSignalTowerPart) {
                    Debug.Log("Player collided!");
                    this.GetComponent<AudioSource>().Play();
                    Debug.Log("Starting Quest 2");
                    Player.S.isInAPuzzleRoom = true;
                    Player.S.playerCollidedWithQuestDoor = true;
                    StartCoroutine(GameManager.S.teleportToNextLevel());
                    MusicManager.S.playMazeMusic();
                }
                else {
                    if (Player.S.carriesSignalTowerPart) {
                        GameManager.S.setPromptText(Strings.NEEDTOBRINGBACKTOBASE);
                    }
                    else {
                        GameManager.S.setPromptText(Strings.QUEST2NOTREADY);
                    }
                }
            }
            if (this.gameObject.name == "DoorQ3" && !Player.S.playerCollidedWithQuestDoor) {
                if (Terminal.S.numSteelBeamsMade == Terminal.THIRDQUESTTRIGGER && !Player.S.carriesSignalTowerPart) {
                    Debug.Log("Player collided!");
                    this.GetComponent<AudioSource>().Play();
                    Debug.Log("Starting Quest 3");
                    Player.S.isInAPuzzleRoom = true;
                    Player.S.playerCollidedWithQuestDoor = true;
                    StartCoroutine(GameManager.S.teleportToNextLevel());
                    MusicManager.S.playMazeMusic();
                }
                else {
                    if (Player.S.carriesSignalTowerPart) {
                        GameManager.S.setPromptText(Strings.NEEDTOBRINGBACKTOBASE);
                    }
                    else {
                        GameManager.S.setPromptText(Strings.QUEST3NOTREADY);
                    }
                }
            }
        }
    }
}
