using UnityEngine;
using UnityEngine.UI;

public class LivesScreenController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currentlivesbar;

    private void Start()
    {
        totalhealthbar.fillAmount = gameManager.lives / 10;
    }

    private void Update()
    {
        currentlivesbar.fillAmount = gameManager.lives / 10;
    }
}
