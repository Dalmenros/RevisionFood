using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarsAuRegime : MonoBehaviour
{
    public float vitesse = 10.0f;
    private Rigidbody2D rig;

    Vector2 direction = new Vector2();
    private bool estControlable = true;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estControlable)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");
        }
    }

    private void FixedUpdate()
    {
        rig.AddForce(new Vector2(direction.x * vitesse, direction.y * (vitesse-5f)), ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Aliment"))
        {
            rig.AddForce(new Vector2(5f, 0), ForceMode2D.Impulse);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Spike"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
