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
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace NEEEU {
    public class DragContainer : MonoBehaviour, IDragHandler {

        public Vector2 _dragDist;
        public Vector2 _dragDistNorm;

        float _lastDrag;
        RectTransform _element;

        void Start() {
            _element = GetComponent<RectTransform>();
        }

        void Update() {
            if (Time.time - _lastDrag > 0.2f) {
                var cur = _element.anchorMin.y;
                cur += _dragDistNorm.y;

                cur = Mathf.Clamp(cur, -1, 0);

                _element.anchorMin = new Vector2(_element.anchorMin.x, cur);
                _element.anchorMax = new Vector2(_element.anchorMax.x, cur + 1);
            }
        }
        public void OnDrag(PointerEventData eventData) {
            _lastDrag = Time.time;

            _dragDist = eventData.delta;

            var rect = _element.rect;

            _dragDistNorm = new Vector2(_dragDist.x / rect.width, _dragDist.y / rect.height);

            var cur = _element.anchorMin.y;
            cur += _dragDistNorm.y;


            cur = Mathf.Clamp(cur, -1, 0);



            _element.anchorMin = new Vector2(_element.anchorMin.x, cur);
            _element.anchorMax = new Vector2(_element.anchorMax.x, cur + 1);


        }
    }
}