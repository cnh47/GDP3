using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    int num;
    // Update is called once per frame
    void Start()
    {
        num = 0;
        scoreText.text = num.ToString();
    }
    void Update()
    {
        if(player.position.y < -1.28f & num == 0)
        {
            num = Random.Range(1, 11);
            scoreText.text = num.ToString();
        }
    }
}
