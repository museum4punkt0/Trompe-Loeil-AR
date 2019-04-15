/*

Copyright © 2018 NEEEU Spaces GmbH

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEEEU {
    public class PointOfInterest : MonoBehaviour {
        static List<PointOfInterest> poiList = new List<PointOfInterest>();

        public List<GameObject> _objects;

        public static void Reset() {
            foreach (var poi in poiList) {
                poi.ResetPoi();
            }
        }
        public void Activate() {
            foreach (var poi in poiList) {
                if (poi == this) {
                    continue;
                }
                poi.Deactivate();
            }
            foreach (var obj in _objects) {
                obj.SetActive(true);
            }
            gameObject.SetActive(false);
        }
        public void ResetPoi() {

            foreach (var obj in _objects) {
                obj.SetActive(false);
            }
            gameObject.SetActive(true);
        }

        public void Deactivate() {
            foreach (var obj in _objects) {
                obj.SetActive(false);
            }
            gameObject.SetActive(false);
        }
        public void DeactivateAll() {
            foreach (var poi in poiList) {
                if (poi == this) {
                    continue;
                }
                poi.Deactivate();
            }
        }


        void Start() {
            poiList.Add(this);
            ResetPoi();
        }
        void OnDestroy() {
            poiList.Remove(this);
        }
    }
}