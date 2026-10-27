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

using System.Collections.Generic;
using SpectatorHUD.Animation;
using UnityEngine;

namespace SpectatorHUD
{
    public class AnimationController : MonoBehaviour
    {
        public List<AnimationBoolReference> animationLeftGunHeld;
        public List<AnimationBoolReference> animationRightGunHeld;
        public List<AnimationTriggerReference> animationLeftGunHeldChanged;
        public List<AnimationTriggerReference> animationRightGunHeldChanged;

        public List<AnimationIntReference> animationLeftAmmo;
        public List<AnimationIntReference> animationRightAmmo;
        public List<AnimationTriggerReference> animationLeftAmmoChanged;
        public List<AnimationTriggerReference> animationRightAmmoChanged;
        
        public List<AnimationIntReference> animationLeftReserve;
        public List<AnimationIntReference> animationRightReserve;
        public List<AnimationTriggerReference> animationLeftReserveChanged;
        public List<AnimationTriggerReference> animationRightReserveChanged;

        public List<AnimationFloatReference> animationHealth;
        public List<AnimationFloatReference> animationMaxHealth;
        public List<AnimationFloatReference> animationHealthPercentage;
        public List<AnimationTriggerReference> animationHealthChanged;
        public List<AnimationTriggerReference> animationMaxHealthChanged;
    }
}