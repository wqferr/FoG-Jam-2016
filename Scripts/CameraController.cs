using UnityEngine;

public class CameraController : MonoBehaviour {

    public float cameraMaxSpeed = 2;
    public float cameraDistDeaccelerate = 5;

    private GameObject player = null;

    void Awake() {
        PlayerController pc = FindObjectOfType(typeof(PlayerController))
                                                        as PlayerController;

        if (pc) {
            player = pc.gameObject;
        } else {
            Debug.Log("Não tem jogador nessa porra.");
        }

        // TAG: MainCamera
        gameObject.name = "MainCamera";
        gameObject.layer = 8;
    }

    void LateUpdate() {
        Vector3 move = player.transform.position - transform.position;
        move *= move.magnitude / cameraDistDeaccelerate;
        move = Vector3.ClampMagnitude(move, cameraMaxSpeed);
    }
}
