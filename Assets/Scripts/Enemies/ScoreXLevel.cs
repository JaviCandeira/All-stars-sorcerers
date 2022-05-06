using System;
using TMPro;
using UnityEngine;

    public class ScoreXLevel : MonoBehaviour
    {
        
        public int score;
        public TextMeshProUGUI counttext;
        [SerializeField] private string onEnableStr;
        [SerializeField] private string onDisableStr;
        
        private void OnEnable()
        {
            score = PlayerPrefs.GetInt(onEnableStr);
            counttext.text ="Score : " + score.ToString();
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt(onDisableStr,score);
        }

        public void increase(int val){
            score += val;
            counttext.text = "Score : " + score.ToString();
        }

        public int getScore(){
            return score;
        }
    }
