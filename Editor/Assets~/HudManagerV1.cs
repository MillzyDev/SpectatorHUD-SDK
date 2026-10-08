/*
 *      SpectatorHUD SDK
 *      Copyright (C) 2026  Millzy
 *
 *      This program is free software: you can redistribute it and/or modify
 *      it under the terms of the GNU General Public License as published by
 *      the Free Software Foundation, either version 3 of the License, or
 *      (at your option) any later version.
 *
 *      This program is distributed in the hope that it will be useful,
 *      but WITHOUT ANY WARRANTY; without even the implied warranty of
 *      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *      GNU General Public License for more details.
 *
 *      You should have received a copy of the GNU General Public License
 *      along with this program.  If not, see https://www.gnu.org/licenses/.
 */

using System.Collections.Generic;
using SpectatorHUD.Animation;
using TMPro;
using UnityEngine;

namespace SpectatorHUD
{
    public class HudManagerV1 : MonoBehaviour
    {
        [Header("Counters")]
        public TMP_Text leftHandReserveCounter;
        public TMP_Text leftHandAmmoCounter;
        public TMP_Text rightHandReserveCounter;
        public TMP_Text rightHandAmmoCounter;
        public TMP_Text healthCounter;
        public TMP_Text maxHealthCounter;
        public TMP_Text percentageHealthCounter;

        [Header("Toggleable Elements")] 
        public List<GameObject> activeWithGunHeldInLeftHand;
        public List<GameObject> activeWithGunHeldInRightHand;

        [Header("Animation Events")] 
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