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
using UnityEngine;

namespace SpectatorHUD.Animation
{
    public class TMPMaterialPropertyOverrideColor : MonoBehaviour
    {
        public TMP_FontAsset fontAsset;
        public string propertyName;
        public Color value;
        
        private Material _material;
        private int _propertyId;
        
        private void Awake()
        {
            this._material = this.fontAsset.material;
            this._propertyId = Shader.PropertyToID(this.propertyName);
        }

        private void Update()
        {
            this._material.SetColor(this._propertyId, this.value);
        }
    }
}