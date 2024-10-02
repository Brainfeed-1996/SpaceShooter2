using UnityEngine;

public class EffetsSpeciaux : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab de l'explosion

    // M�thode appel�e lors de la destruction de l'ennemi
    public void D�truireEnnemiAvecExplosion()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); // D�truit l'ennemi apr�s avoir instanci� l'explosion
    }
}
