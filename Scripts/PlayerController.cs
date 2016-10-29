using UnityEngine;

public class PlayerController : MonoBehaviour {

    public const int SPR_U = 0;
    public const int SPR_S = 1;
    public const int SPR_D = 2;

    public float speed = 0;

    public Sprite[] sprites = new Sprite[3];

    public Interactable interactable = null;
    public Texture normalMap;

    private SpriteRenderer sr;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        // TAG: Player
        gameObject.name = "Player";
        sr.material.SetTexture("_BumpMap", normalMap);
    }

    void FixedUpdate() {
        Vector3 moveDir = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        ).normalized;

        transform.Translate(moveDir * speed);
        UpdateSprit(moveDir);
    }

    void Update() {
        if (Input.GetButtonDown("Fire1") && interactable != null) {
            interactable.OnInteract();
        }
    }

    private void UpdateSprit(Vector3 moveDir) {
        if (moveDir.x == 0) {
            if (moveDir.y > 0)
                sr.sprite = sprites[SPR_U];
            else if (moveDir.y < 0)
                sr.sprite = sprites[SPR_D];
        } else {
            sr.sprite = sprites[SPR_S];

            if (moveDir.x > 0)
                sr.flipX = false;
            else if (moveDir.x < 0)
                sr.flipX = true;
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
