using System;
using System.Collections;
using UnityEngine;


namespace Tools
{
    public static class MoveUtility 
    {
        public static Coroutine MoveToPosition(this MonoBehaviour monoBehaviour, Vector2 destination, float time, Action callback)
        {
            return monoBehaviour.StartCoroutine(MoveToPosition(monoBehaviour.transform, destination, time, callback));
        }

        private static IEnumerator MoveToPosition(this Transform transform, Vector2 destinatiom, float time,
            Action callback)
        {
            var currentTime = 0f;
            var startPosition = transform.position;

            while (currentTime < time)
            {
                transform.position = Vector2.Lerp(startPosition, destinatiom, currentTime / time);
                currentTime += Time.deltaTime;
                yield return null;
            }
            transform.position = destinatiom;
            callback?.Invoke();
        }
    }
}