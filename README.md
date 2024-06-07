# sonosthesia-unity-demo-live

This demo expands the [instrument demo](https://github.com/jbat100/sonosthesia-unity-demo-instrument) to use Max 4 Live devices with the [sonosthesia-daw-connector](https://github.com/jbat100/sonosthesia-daw-connector), in particular the [Tri Band](https://github.com/jbat100/sonosthesia-daw-connector/tree/main/m4l) which sends energy levels in three different frequency bands allowing realtime visual feedback in Unity. 

It uses the following [sonosthesia framework](https://github.com/jbat100/sonosthesia-unity-packages) packages:

- [com.sonosthesia.touch](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.touch)
- [com.sonosthesia.instrument](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.instrument)
- [com.sonosthesia.midi](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.midi)
- [com.sonosthesia.audio](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.audio)
- [com.sonosthesia.pack](https://github.com/jbat100/sonosthesia-unity-packages/tree/main/packages/com.sonosthesia.pack)

Note the raw MIDI functionality is presented in a separate [demo project](https://github.com/jbat100/sonosthesia-unity-demo-midi).

## Installation

Note that to add those packages to your Unity project you will need to add the following [scoped registeries](https://docs.unity3d.com/Manual/upm-scoped.html) to your `Packages/package.json` file.. 

```
"scopedRegistries": [
    {
      "name": "Neuecc",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.neuecc.unirx",
        "com.cysharp.unitask"
      ]
    },
    {
      "name": "Sonosthesia",
      "url": "https://registry.npmjs.com",
      "scopes": [
        "com.sonosthesia"
      ]
    }
  ]
```

## MIDI output with hit visuals

Procedural visuals running on the GPU for performance allowing use in XR apps

<p align="center">
    <img alt="Keyboard Builder" src="https://github.com/jbat100/sonosthesia-unity-demo-live/assets/1318918/2a1deb74-3b2c-40eb-9a37-371e0db165d9" width="75%">
</p>

## Audio feedback from Live to Unity


<p align="center">
    <img alt="Keyboard Builder" src="https://github.com/jbat100/sonosthesia-unity-demo-live/assets/1318918/7afd6093-199b-4bc8-8d21-d31f93ef32cf" width="75%">
</p>
