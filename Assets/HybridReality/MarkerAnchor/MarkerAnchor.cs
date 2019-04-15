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
using UnityEngine.Events;
using UnityEngine.XR.iOS;

//Script to be used in any Image Anchor object you want to recognize
//the manager holds a list of markers and each object with this component will add itself to the list

namespace NEEEU.HybridReality {

    public enum AnchorType { Local }
    public class MarkerAnchor : MonoBehaviour {
        public bool triggerActivate;

        public AnchorType anchorType = AnchorType.Local;
        public ARReferenceImage referenceImage;
        public string referenceImageStr;
        public UnityEvent detected;
        public UnityEvent firstTimeDetected;
        private bool firstTime = true;

        [Header("Debug Options")]
        public bool enableDebug;
        public Material Active;
        public Material InActive;
        public GameObject debugPrefab;

        float lastUpdate;
        //Vector4 referenceCuma;
        Vector3 referencePos;
        Quaternion referenceRot;
        Vector3 realWorldPos;
        Quaternion realWorldRot;


        void Start() {
            if (referenceImage == null && referenceImageStr == "") {
                return;
            }
            if (referenceImageStr == "") {
                referenceImageStr = referenceImage.imageName;
            }
            if (referenceImage == null) {
                if (MarkerAnchorManager.manager == null) {
                    Debug.LogError("No manager found!");
                    return;
                }
                foreach (ARReferenceImage rInst in MarkerAnchorManager.manager.anchorImagesSet.referenceImages) {
                    if (rInst.imageName != referenceImageStr) {
                        continue;
                    }
                    referenceImage = rInst;
                }
                if (referenceImage == null) {
                    Debug.LogError("Image not found!");
                    return;
                }
            }

            if (Active == null) {
                Active = new Material(Shader.Find("Standard"));
                Active.color = Color.white;
            }
            if (InActive == null) {
                InActive = new Material(Shader.Find("Standard"));
                InActive.color = Color.black;
            }

            MarkerAnchorManager.mList.Add(this);
            //transform.localScale = new Vector3(referenceImage.physicalSize,referenceImage.physicalSize,referenceImage.physicalSize);
            referencePos = transform.position;
            referenceRot = transform.rotation;
        }


        void Update() {
            if (triggerActivate) {
                detected.Invoke();
                triggerActivate = false;
            }
            if (enableDebug) {
                GetComponent<Renderer>().material = Time.time - lastUpdate < .25 ? Active : InActive;
            }
        }
        void OnDestroy() {
            MarkerAnchorManager.mList.Remove(this);
        }

        public void AnchorAdded(ARImageAnchor arImageAnchor) {

            //Debug.Log("Image Anchor triggered");
            if (arImageAnchor.referenceImageName != referenceImageStr) {
                //Debug.Log("Not my image");
                return;
            }


            Vector3 position = UnityARMatrixOps.GetPosition(arImageAnchor.transform);
            Quaternion rotation = UnityARMatrixOps.GetRotation(arImageAnchor.transform);

            if (enableDebug) {
                lastUpdate = Time.time;
                Instantiate(debugPrefab, position, rotation);
            }


            if (anchorType == AnchorType.Local) {

                transform.position = position;
                transform.rotation = rotation;
                Debug.Log("Local anchor: " + arImageAnchor.referenceImageName);

            }

            detected.Invoke();
            if (firstTime) {
                firstTimeDetected.Invoke();
                firstTime = false;
            }
            UnityARSessionNativeInterface.GetARSessionNativeInterface().RemoveUserAnchor(arImageAnchor.identifier);
        }

    }
}

