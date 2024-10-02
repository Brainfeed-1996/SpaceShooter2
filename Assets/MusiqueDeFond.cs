using UnityEngine;

public class MusiqueDeFond : MonoBehaviour
{
    public AudioSource musique; // La musique de fond (fichier audio attaché à l'AudioSource)

    void Start()
    {
        musique.Play(); // Démarre la musique à l'initialisation du jeu
    }
}
