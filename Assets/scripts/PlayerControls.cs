using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Movement parameters")]
    public float speed = 5f; // Vitesse de d�placement du personnage
    private Rigidbody2D rb; // R�f�rence au Rigidbody2D
    private SpriteRenderer spriteRenderer; // R�f�rence au SpriteRenderer
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

            ChangeSpriteDirection(horizontalInput, verticalInput);  // Change le sprite en fonction de la direction du mouvement
        }
        else
        {
            rb.velocity = Vector2.zero; // Arr�te le mouvement si aucune touche n'est press�e
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

        if (horizontalInput < 0) // Si le joueur va � gauche
        {
            anim.SetBool("idleKnightressSide", true);
            anim.SetBool("IdleKnight", false);
            anim.SetBool("idleKnightressBack", false);
            MoveInDirection(-1);

        }
        else if (horizontalInput > 0) // Si le joueur va � droite
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
