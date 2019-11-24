using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    private List<GameObject> fishList;
    public GameObject fishType1;
	public GameObject fishType2;
	public GameObject fishType3;
    public GameManager gameManager;
    public float padding;

    void CreateFish(GameObject fish, Vector2 position)
    {
        GameObject newFish = Instantiate(fish, position, Quaternion.identity);
        newFish.GetComponent<Fish>().manager = gameObject.GetComponent<FishController>();
        newFish.GetComponent<Fish>().UpdateLevel(gameManager.GetLevel());
        fishList.Add(newFish);
    }
    void CreateFish(GameObject fish)
    {
        int side = Random.Range(0, 2);
        float randomPadding = Random.Range(0, padding);
        CreateFish(
            fish, 
            new Vector2(
                side==0 ? 
                    gameManager.minX - randomPadding: 
                    gameManager.maxX + randomPadding, 
                Random.Range(gameManager.minY, gameManager.maxY - padding)
            )
        );
    }
    public void RemoveFish(GameObject fish)
    {
        fishList.Remove(fish);
    }

    void Start()
    {
        gameManager = GameManager.instance;
        padding = (gameManager.maxY - gameManager.minY) / 4;
        fishList = new List<GameObject>();
        for(int i=0; i<2; ++i)
        {
            CreateFish(fishType1);
            CreateFish(fishType2);
            CreateFish(fishType3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fishList.Count <= 4)
        {
            gameManager = GameManager.instance;
            CreateFish(fishType1);
            CreateFish(fishType2);
            CreateFish(fishType3);
        }
    }

    public void UpdateLevel(int level)
    {
        for (int i = 0; i < fishList.Count; ++i)
            fishList[i].GetComponent<Fish>().UpdateLevel(level);
    }
}
