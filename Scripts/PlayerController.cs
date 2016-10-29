using UnityEngine;

public class PlayerController : MonoBehaviour {

    public const int SPR_U = 0;
    public const int SPR_UR = 1;
    public const int SPR_R = 2;
    public const int SPR_DR = 3;
    public const int SPR_D = 4;

    public float speed = 0;

    private readonly float scale;

    public Sprite[] sprites = new Sprite[5];

    public Interactable interactable = null;

    private SpriteRenderer sr;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        scale = transform.scale.x;
        // TAG: Player
        gameObject.name = "Player";
    }

    void FixedUpdate() {
        Vector3 moveDir = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        ).normalized;

        transform.Translate(moveDir * speed);
        UpdateSprites(moveDir);
    }

    void Update() {
        if (Input.GetButtonDown("Fire1") && interactable != null) {
            interactable.OnInteract();
        }
    }

    private void UpdateSprites(Vector3 moveDir) {
        if (moveDir.x == 0) {
            // Stopped horizontally
            if (moveDir.y > 0) {
                sr.sprite = sprites[SPR_U];
            } else if (moveDir.y < 0) {
                sr.sprite = sprites[SPR_D];
            }
        } else {
            // Moving horizontally
            if (moveDir.y > 0) {
                sr.sprite = sprites[SPR_UR];
            } else if (moveDir.y < 0) {
                sr.sprite = sprites[SPR_DR];
            } else {
                sr.sprite = sprites[SPR_R];
            }

            if (moveDir.x < 0) {
                transform.scale.x = -scale;
            } else {
                transform.scale.x = scale;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Interactable")) {
            interactable = col.gameObject.GetComponent<Interactable>();
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.GetComponent<Interactable>() == interactable) {
            interactable = null;
        }
    }
}
