using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Collectible collectible = other.GetComponent<Collectible>();

            if (collectible != null)
            {

                gameManager.AddPoints(collectible.points);
                Debug.Log("points = " + gameManager.score);
            }

            Destroy(other.gameObject);

        }
    }

}
