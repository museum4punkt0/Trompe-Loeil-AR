# Trompe-l’œil

### Table of Contents  
- [Description](#Description)  
- [Technical Documentation](#Technical-Documentation)  
- [Installing / Getting started](#installing--getting-started)  
- [Using the app](#Using-the-app)
- [Contributing](#Contributing)  
- [Credits](#Credits) 
- [Licensing](#Licensing) 

## Description
This is a prototype developed by NEEEU Spaces GmbH and museum4punkt0 to test different ideas on how Augmented Reality could help to improve the visitor experience of the Gemaldegalerie.

The app is build up out of multiple parts working together, the UnityARKit plugin is used to connect Unity to ARkit for tracking the phone's movement, adding the camera feed and tracking the marker images used for localisation.

This prototype is part of the project museum4punkt0 - Digital Strategies for the Museum of the Future, sub-project Rethinking Visitor Journeys. Further information: www.museum4punkt0.de/en/.  

The project museum4punkt0 is funded by the Federal Government Commissioner for Culture and the Media in accordance with a resolution issued by the German Bundestag (Parliament of the Federal Republic of Germany).

## Technical Documentation
### Features
This app uses the UnityARKit plugin. The documentation for it can be found here:

https://docs.unity3d.com/Manual/index.html

Everything is based on Unity's regular Event system to enable and disable the different states of the app. It is recommend to look through the Main scene to see the build up. Comments have been added describing which parts do what.

The different states of the app are controlled by turning on and off gameobjects that contain their respective parts.

Each painting's content is saved in a Scriptable Objects in the Assets/Areas/, these define the audio that should be played and the text that is visible.

### Configuration
The app can be in one of two states, administrative mode, this mode sees all the options for the app and can control what is visible on the other devices that have their state set to player mode.

This state can be changed through the iOS Settings app, scroll down to the name of the app and select a different role. This will be activated the next time the app is relaunched. Make sure to kill the app through the app switcher by swiping up (iOS 12)

## Installing / Getting started
Install Unity 2018.2.14f1.

Download the repository from

https://github.com/museum4punkt0/Trompe-Loeil-AR/

Open the project using Unity Hub.

The project will open, and you will find more information about the parts inside.

The project works using ARKit to recognise the paintings, and then triggering action points that depend on the painting. Each painting had different interactions, in order to understand which were the most attractive for visitors.
ARKit works only for iOS devices which are compatible.

The list of compatible devices is here:

https://developer.apple.com/library/archive/documentation/DeviceInformation/Reference/iOSDeviceCompatibility/DeviceCompatibilityMatrix/DeviceCompatibilityMatrix.html

### Initial Configuration
Make sure the build target is set to iOS in *File -> Build Settings*.

### Deploying / Publishing
For building in Unity3D, for iPad.

Make sure the build target is set to iOS in *File -> Build Settings*.

In the same menu hit the *Build and Run* button.

In XCode select your iPad and hit run.

Might anything go awry consult the documentation here: https://unity3d.com/learn/tutorials/topics/mobile-touch/building-your-unity-game-ios-device-testing

## Using the App
1. The user points his/her iPad at the painting. The iPad’s camera scans the painting and points of interest (POIs) appear on top of that painting – in shape of a soap bubble, floating in front of the painting. There are minimum two, maximum four POIs for each painting. 

2. The user taps on a bubble and content will be triggered. There are two types of content – text and audio. In addition to that there are special interactions, which enable visitors to explore the painting in unique ways, such as opening and closing the triptych or revealing the x-ray examination of a painting. 

## Contributing
If you'd like to contribute, please fork the repository and use a feature branch. Pull requests are warmly welcome.

#### Links

Museum4punkt0 website: https://www.museum4punkt0.de/en/

NEEEU website: www.neu.io

Project homepage in NEEEU’s website: https://www.neeeu.io/portfolio/projects/gemaeldegalerie/

Repository: https://github.com/museum4punkt0/Trompe-Loeil-AR/

## Credits
Contracting entity: Staatliche Museen zu Berlin - Preußischer Kulturbesitz

Design and Programming: NEEEU Spaces GmbH in colaboration with museum4punkt0

## Licensing
MIT license

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above credit information and this permission notice shall be included in all
copies or substantial portions of the Software.

The portions of the project that were developed by NEEEU Spaces GmbH, 
2018 as part of the project are provided under the MIT license.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
