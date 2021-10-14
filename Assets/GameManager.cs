using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject sqaureDropPrefab;
    public GameObject circleDropPrefab;
    public GameObject diamondDropPrefab;
    public Text gameOverText;
    public GameObject[] hearts;
    public int playerHP = 3;
    float timeSinceLastDrop;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastDrop = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastDrop += Time.deltaTime * 2;
        if(timeSinceLastDrop > 1)
        {
            int randomDrop = Random.Range(1, 4);
            switch(randomDrop)
            {
                case 1:
                    createDrop(diamondDropPrefab);
                    break;
                case 2:
                    createDrop(sqaureDropPrefab);
                    break;
                case 3:
                    createDrop(circleDropPrefab);
                    break;
            }
  
            timeSinceLastDrop = 0;
        }
    }

    void createDrop(GameObject dropPrefab)
    {
        float x = Random.Range(-10, 10);
        Instantiate(dropPrefab, new Vector2(x, 10), Quaternion.identity);
    }
    public void removeHeart()
    {
        playerHP--;
        if (playerHP >= 3)
        {
            hearts[2].SetActive(true);
        }
        else hearts[2].SetActive(false);
        if (playerHP >= 2)
        {
            hearts[1].SetActive(true);
        }
        else hearts[1].SetActive(false);
        if (playerHP >= 1)
        {
            hearts[0].SetActive(true);
        }
        else hearts[0].SetActive(false);
        if (playerHP <= 0)
        {
            Time.timeScale = 0;
            gameOverText.gameObject.SetActive(true);
        }


    }
}
