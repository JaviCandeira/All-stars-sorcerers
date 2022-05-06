using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

  public static ScoreCounter Instance;
  public int score;
  public TextMeshProUGUI counttext;

    void Awake() {
      if (Instance == null){
        Instance = this;
        DontDestroyOnLoad(gameObject);
      }
      else {
        Destroy(gameObject);
      }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        counttext.text = "Score : " + score.ToString();
    }

    public void increase(int val){
      score += val;
      counttext.text = "Score : " + score.ToString();
    }

    public int getScore(){
      return score;
    }
}
