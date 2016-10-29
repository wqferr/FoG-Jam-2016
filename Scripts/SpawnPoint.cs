using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public Transform[] bixos;

    public void Spawn(Transform prefab) {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public void SpawnRandomBixo() {
        if (bixos != null && bixos.Length > 0) {
            int i = (int) (Random.value * (bixos.Length-1));
            Spawn(bixos[i]);
        }
    }

}
