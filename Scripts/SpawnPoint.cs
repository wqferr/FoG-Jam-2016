using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public void Spawn(Transform prefab) {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

}
