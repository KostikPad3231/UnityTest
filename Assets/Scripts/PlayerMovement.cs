using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Transform transform;
    public int speed;
    public TMP_Text taskText;
    public TMP_Text winLoseText;
    private bool facingRight = true;

    void Init()
    {
        winLoseText.alpha = 0;
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
        else if(transform.position.y <= 0.7)
        {
            winLoseText.text = "You lose!";
            winLoseText.alpha = 1;
            taskText.alpha = 0;
            animator.SetFloat("Speed", 0);
        }
        else if (transform.position.x >= 3.2)
        {
            winLoseText.text = "You won!";
            winLoseText.alpha = 1;
            taskText.alpha = 0;
            animator.SetFloat("Speed", 0);
        }
        else
        {
            float direction = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(direction));
            transform.Translate(new Vector2(direction * speed * Time.deltaTime, 0));
            if (direction > 0 && !facingRight)
            {
                Flip();
            }
            else if (direction < 0 && facingRight)
            {
                Flip();
            }
        }        
        
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}