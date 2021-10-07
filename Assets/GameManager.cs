using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject sqaureDropPrefab;
    public GameObject circleDropPrefab;
    public GameObject diamondDropPrefab;
    float timeSinceLastDrop;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastDrop = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastDrop += Time.deltaTime;
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
}
