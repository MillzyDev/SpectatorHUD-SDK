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

using TMPro;
using UltEvents;
using UnityEngine;

namespace SpectatorHUD
{
    public class HudManager : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("Counters")]
#endif
        public TMP_Text leftHandReserveCounter;
        public TMP_Text leftHandAmmoCounter;
        public TMP_Text rightHandReserveCounter;
        public TMP_Text rightHandAmmoCounter;
        public TMP_Text healthCounter;
        public TMP_Text maxHealthCounter;

#if UNITY_EDITOR
        [Header("UltEvents")]
#endif
        public UltEvent<float> leftHandReserveCounterChanged;
        public UltEvent<float> leftHandAmmoCounterChanged;
        public UltEvent<float> rightHandReserveCounterChanged;
        public UltEvent<float> rightHandAmmoCounterChanged;
        public UltEvent<float> healthCounterChanged;
        public UltEvent<float> maxHealthCounterChanged;
    }
}