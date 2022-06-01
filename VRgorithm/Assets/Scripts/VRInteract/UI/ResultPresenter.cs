using System.Collections;
using TMPro;
using UnityEngine;

namespace VRInteract
{
    public class ResultPresenter : MonoBehaviour
    {
        [Header("Text")]
        [SerializeField] private TextMeshPro textUI;
        [SerializeField] private Color wrongColor; 
        [SerializeField] private Color rightColor;
        [SerializeField] private float waitTime = 5f;

        [Header("Sound")] 
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip wrongSound;
        [SerializeField] private AudioClip rightSound;
        
        public void PrintWrongText()
        {
            textUI.text = "틀렸습니다!";
            audioSource.clip = wrongSound;
            audioSource.Play();
            StartCoroutine(FadeRoutine(textUI,wrongColor,waitTime));
        }
        public void PrintSuccess()
        {
            textUI.text = "맞았습니다!";
            audioSource.clip = rightSound;
            audioSource.Play();
            StartCoroutine(FadeRoutine(textUI,rightColor,waitTime));
        }
        private IEnumerator FadeRoutine(TextMeshPro text,Color startColor,float wait)
        {
            text.color = startColor;
            var time = .0f;
            while (wait >= time)
            {
                time += Time.deltaTime;
                text.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(1,0,time / wait));
                yield return null;
            }
            text.color = Color.clear;
        }
    }
}