using UnityEngine;

namespace Common
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Ins { get; private set; }

        private void Awake()
        {
            Ins = this as T;
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }
    }
}