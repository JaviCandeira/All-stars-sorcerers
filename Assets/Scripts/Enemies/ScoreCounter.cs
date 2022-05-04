using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

  public static ScoreCounter Instance;
  public int score;

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
    }

    public void increase(int val){
      score += val;
    }
}
