using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5f; // Vitesse de d�placement du personnage
    public Sprite[] sprites; // Tableau de sprites pour chaque direction (gauche, droite, avant, arri�re)
    private Rigidbody2D rb; // R�f�rence au Rigidbody2D
    private SpriteRenderer spriteRenderer; // R�f�rence au SpriteRenderer

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtient le Rigidbody2D attach� au personnage
        rb.gravityScale = 0f; // D�sactive la gravit� pour �viter le glissement

        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtient le SpriteRenderer attach� au personnage
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // R�cup�re l'entr�e horizontale (gauche/droite) du joueur
        float verticalInput = Input.GetAxis("Vertical"); // R�cup�re l'entr�e verticale (haut/bas) du joueur
        Vector2 movement = new Vector2(horizontalInput, verticalInput); // Cr�e un vecteur de mouvement avec les entr�es du joueur
        if (movement != Vector2.zero) // V�rifie si le joueur se d�place
        {
            Vector2 velocity = movement * speed; // Calcule la v�locit� du mouvement
            rb.velocity = velocity; // Applique la v�locit� pour d�placer le personnage
        }
        else
        {
            rb.velocity = Vector2.zero; // Arr�te le mouvement si aucune touche n'est press�e
        }
    }
}
