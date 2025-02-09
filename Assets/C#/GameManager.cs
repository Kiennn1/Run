using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int scores;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.SetText(scores.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(scores.ToString());

    }
}
