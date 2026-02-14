using UnityEngine;

namespace _Game.Scripts.Core
{
    public abstract class MyBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            OnLoadComponents();
        }

        protected virtual void Reset()
        {
            OnLoadComponents();
            ResetValue();
        }

        protected virtual void OnLoadComponents()
        {
        }

        protected virtual void ResetValue()
        {
        }
    }
}