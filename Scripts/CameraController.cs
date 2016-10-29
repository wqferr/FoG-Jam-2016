using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 relativePos = null;
    private GameObject player = null;

    void Awake() {
        PlayerController pc = FindObjectOfType(typeof(PlayerController))
                                                        as PlayerController;

        if (pc) {
            player = pc.gameObject;
            relativePos = transform.position - player.transform.position;
        } else {
            Debug.Log("Não tem jogador nessa porra.");
        }

        // TAG: Camera
        gameObject.name = "Camera";
    }

    void LateUpdate() {
        transform.position = player.transform.position + relativePos;
    }
}
