# sonosthesia-unity-demo-live

This demo expands the [instrument demo](https://github.com/jbat100/sonosthesia-unity-demo-instrument) to use Max 4 Live devices with the [sonosthesia-daw-connector](https://github.com/jbat100/sonosthesia-daw-connector). It showcases the following [sonosthesia framework](https://github.com/jbat100/sonosthesia-unity-packages) packages:

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

## Audio feedback from Live to Unity

