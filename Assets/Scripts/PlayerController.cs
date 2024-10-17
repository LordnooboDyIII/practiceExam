using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5.0f;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Spawn", 3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        //rb.AddForce(move);
        transform.position += (move * Time.deltaTime * speed);
        scoreText.text = score.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            score += 100;
        }
    }

    void Spawn()
    {
        Vector3 position = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
        Instantiate(prefab, position, Quaternion.identity);
    }
}
