/*
 *      Spectator HUD SDK
 *      Copyright 2026 Millzy
 *
 *      Licensed under the Apache License, Version 2.0 (the "License");
 *      you may not use this file except in compliance with the License.
 *      You may obtain a copy of the License at
 *
 *          http://www.apache.org/licenses/LICENSE-2.0
 *
 *      Unless required by applicable law or agreed to in writing, software
 *      distributed under the License is distributed on an "AS IS" BASIS,
 *      WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *      See the License for the specific language governing permissions and
 *      limitations under the License.
 */

using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpectatorHUD.Animation
{
    public class RandomAnimationParameter : MonoBehaviour
    {
        public Animator animator;
        public string parameterName;
        private int _parameterId;
    
        public float rangeMin = 0f;
        public float rangeMax = 1f;

        public bool doesCycle = false;
        public int bufferSize = 128;
        public float interval = 1;
    
        [NonSerialized] private float[] _buffer;
        [NonSerialized] private Coroutine _coroutine;

        private void Start()
        {
            this._parameterId = Animator.StringToHash(this.parameterName);
        
            float range = this.rangeMax - this.rangeMin;
        
            if (!this.doesCycle)
            {
                float n = this.rangeMin + (Random.value * range);
                this.animator.SetFloat(this._parameterId, n);
                return;
            }

            this._buffer = new float[this.bufferSize];
            for (int i = 0; i < this.bufferSize; i++)
            {
                this._buffer[i] = this.rangeMin + (Random.value * range);
            }

            this._coroutine = this.StartCoroutine(this.BufferCycle());
        }

        private void OnDestroy()
        {
            if (this._coroutine == null)
            {
                return;
            }
        
            this.StopCoroutine(this._coroutine);
        }

        private IEnumerator BufferCycle()
        {
            int i = 0;

            while (true)
            {
                if (i >= this.bufferSize)
                {
                    i = 0;
                }
            
                this.animator.SetFloat(this._parameterId, this._buffer[i++]);
                yield return new WaitForSeconds(this.interval);
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}