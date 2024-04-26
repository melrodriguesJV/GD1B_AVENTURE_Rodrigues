using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Movement parameters")]
    public float speed = 5f; // Vitesse de déplacement du personnage
    private Rigidbody2D rb; // Référence au Rigidbody2D
    private SpriteRenderer spriteRenderer; // Référence au SpriteRenderer
    private Vector3 initScale;
    
    [Header("Player Animator")]
    [SerializeField] private Animator anim;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        initScale = player.localScale;
    }
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

            ChangeSpriteDirection(horizontalInput, verticalInput);  // Change le sprite en fonction de la direction du mouvement
        }
        else
        {
            rb.velocity = Vector2.zero; // Arrête le mouvement si aucune touche n'est pressée
        }

        if (horizontalInput != 0)
        {
            anim.SetBool("isMoving", true);
        }       
        else if (horizontalInput == 0)
        {
            anim.SetBool("isMoving", false);
        }
    }

    void ChangeSpriteDirection(float horizontalInput, float verticalInput)
    {
        // Change le sprite en fonction de la direction du mouvement

        if (horizontalInput < 0) // Si le joueur va à gauche
        {
            anim.SetBool("idleKnightressSide", true);
            anim.SetBool("IdleKnight", false);
            anim.SetBool("idleKnightressBack", false);
            MoveInDirection(-1);

        }
        else if (horizontalInput > 0) // Si le joueur va à droite
        {
            anim.SetBool("idleKnightressSide", true);
            anim.SetBool("IdleKnight", false);
            anim.SetBool("idleKnightressBack", false);
            MoveInDirection(1);
        }
        else if (verticalInput < 0) // Si le joueur va vers le haut
        {
            anim.SetBool("IdleKnight", true);
            anim.SetBool("idleKnightressBack", false);
            anim.SetBool("idleKnightressSide", false);
            anim.SetBool("isMoving", false);
        }
        else if (verticalInput > 0) // Si le joueur va vers le bas
        {
            anim.SetBool("IdleKnight", false);
            anim.SetBool("idleKnightressBack", true);
            anim.SetBool("idleKnightressSide", false);
            anim.SetBool("isMoving", false);
        }
    }

    private void MoveInDirection(int _direction)
    {
        player.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        player.position = new Vector3(player.position.x + Time.deltaTime * _direction,
            player.position.y, player.position.z);
    }   
}
