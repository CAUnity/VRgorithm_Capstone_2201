using System;
using Common;
using System.Collections;
using UnityEngine;

namespace VRInteract{

    public class TrainManager : MonoSingleton<TrainManager>
    {
        [SerializeField] private AudioSource audio;
        [SerializeField] private GameObject train;
        [SerializeField] private Vector3 offset;
        [SerializeField] private int speed;
        

        public void StartMoveRoutine(Vector3 pos){
            StartCoroutine(MoveRoutine(pos + offset));
        }

        public void teleport(Vector3 pos){
            train.transform.position = pos + offset;
        }

        IEnumerator MoveRoutine(Vector3 pos){
            audio.Play();
            Vector3 dis = (pos - train.transform.position) / speed;

            for(int i = 0; i < speed; i++)
            {
                train.transform.position += dis;
                yield return null;
            }
        }


    }
}