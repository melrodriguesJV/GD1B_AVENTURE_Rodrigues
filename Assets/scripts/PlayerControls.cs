using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement du personnage
    public Sprite[] sprites; // Tableau de sprites pour chaque direction (gauche, droite, avant, arrière)
    private Rigidbody2D rb; // Référence au Rigidbody2D
    private SpriteRenderer spriteRenderer; // Référence au SpriteRenderer

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtient le Rigidbody2D attaché au personnage
        rb.gravityScale = 0f; // Désactive la gravité pour éviter le glissement

        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtient le SpriteRenderer attaché au personnage
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Récupère l'entrée horizontale (gauche/droite) du joueur
        float verticalInput = Input.GetAxis("Vertical"); // Récupère l'entrée verticale (haut/bas) du joueur
        Vector2 movement = new Vector2(horizontalInput, verticalInput); // Crée un vecteur de mouvement avec les entrées du joueur
        if (movement != Vector2.zero) // Vérifie si le joueur se déplace
        {
            Vector2 velocity = movement * speed; // Calcule la vélocité du mouvement
            rb.velocity = velocity; // Applique la vélocité pour déplacer le personnage
        }
        else
        {
            rb.velocity = Vector2.zero; // Arrête le mouvement si aucune touche n'est pressée
        }
    }
}
