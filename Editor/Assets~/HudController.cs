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
using SpectatorHUD.Expressions;
using TMPro;
using UnityEngine;

namespace SpectatorHUD
{
    public class HudController : MonoBehaviour
    {
        [Header("Counters")]
        public TMP_Text leftHandReserveCounter;
        public TMP_Text leftHandAmmoCounter;
        public TMP_Text rightHandReserveCounter;
        public TMP_Text rightHandAmmoCounter;
        public TMP_Text healthCounter;
        public TMP_Text maxHealthCounter;
        public TMP_Text percentageHealthCounter;

        public LinearParameters healthModifier = new(10f, 0);

        [Header("Toggleable Elements")] 
        public List<GameObject> activeWithGunHeldInLeftHand;
        public List<GameObject> activeWithGunHeldInRightHand;
    }
}