using UnityEngine;

public class ControleTactile : MonoBehaviour
{
    public float vitesse = 10f;
    private Vector3 toucheD�part;
    private bool estTouch� = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touche = Input.GetTouch(0);

            if (touche.phase == TouchPhase.Began)
            {
                toucheD�part = touche.position;
                estTouch� = true;
            }
            else if (touche.phase == TouchPhase.Moved && estTouch�)
            {
                Vector2 direction = touche.position - (Vector2)toucheD�part;
                D�placerVaisseau(direction);
            }
            else if (touche.phase == TouchPhase.Ended)
            {
                estTouch� = false;
            }
        }
    }

    void D�placerVaisseau(Vector2 direction)
    {
        Vector3 mouvement = new Vector3(direction.x, direction.y, 0f).normalized;
        transform.Translate(mouvement * vitesse * Time.deltaTime);
    }
}
