using UnityEngine;

public class BonusManger : MonoBehaviour
{
    public float augmentationVitesse = 2f; // Augmentation de la vitesse
    public GameObject bouclierPrefab; // Bonus de bouclier
    public GameObject tirPuissantPrefab; // Bonus pour tir plus puissant
    public float dur�eBonus = 10f;

    void Update()
    {
        // Bonus descend vers le joueur
        transform.Translate(Vector3.down * 2f * Time.deltaTime);

        // D�truire le bonus s'il sort de l'�cran
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    // Lorsque le joueur r�cup�re le bonus
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Joueur")
        {
            collision.gameObject.GetComponent<VaisseauSpatial>().ActiverBonusVitesse(augmentationVitesse, dur�eBonus);
            Destroy(gameObject); // D�truire le bonus apr�s activation
        }
    }
   
    // Active un bouclier temporaire sur le joueur
    public void ActiverBouclier(VaisseauSpatial vaisseau)
    {
        GameObject bouclier = Instantiate(bouclierPrefab, vaisseau.transform.position, Quaternion.identity);
        bouclier.transform.SetParent(vaisseau.transform); // Le bouclier suit le vaisseau
        Destroy(bouclier, dur�eBonus); // Le bouclier dispara�t apr�s la dur�e sp�cifi�e
    }

    // Am�liore temporairement les tirs du joueur
    public void ActiverTirPuissant(VaisseauSpatial vaisseau)
    {
        vaisseau.tirPuissant = true; // Active le mode de tir puissant
        Invoke("D�sactiverTirPuissant", dur�eBonus); // D�sactive apr�s un certain temps
    }

    void D�sactiverTirPuissant()
    {
        FindObjectOfType<VaisseauSpatial>().tirPuissant = false; // D�sactive le tir puissant
    }
}

