using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    
    private void OnTriggerExit(Collider other)
    {
        if (tag == "RedWall" && other.CompareTag("Player"))
        {
            levelManager.isRed = true;
            levelManager.isGreen = false;
        }
        else if (tag == "GreenWall" && other.CompareTag("Player"))
        {
            levelManager.isRed = false;
            levelManager.isGreen = true;
        }
        
    }
}
