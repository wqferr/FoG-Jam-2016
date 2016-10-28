using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 relativePos = null;

    void Awake() {
        PlayerController pc =
                (PlayerController) FindObjectOfType(typeof(PlayerController));

        if (pc) {
            GameObject player = pc.gameObject;
            relativePos = transform.position - player.transform.position;
        } else {
            Debug.Log("Não tem jogador nessa porra.");
        }

        // TAG: Camera
        gameObject.name = "Camera";
    }

    void Update() {
        transform.Translate(relativePos);
    }
}
