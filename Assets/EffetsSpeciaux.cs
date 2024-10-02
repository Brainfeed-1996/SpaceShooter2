using UnityEngine;

public class EffetsSpeciaux : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab de l'explosion

    // Méthode appelée lors de la destruction de l'ennemi
    public void DétruireEnnemiAvecExplosion()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); // Détruit l'ennemi après avoir instancié l'explosion
    }
}
