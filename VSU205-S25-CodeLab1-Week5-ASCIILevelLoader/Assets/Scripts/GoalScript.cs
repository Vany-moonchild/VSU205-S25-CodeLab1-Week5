using UnityEngine;

public class GoalScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<ASCIILevelLoader>().CurrentLevel++;
        
    } 
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
