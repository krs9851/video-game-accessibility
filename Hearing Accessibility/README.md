# unity-accessibility
<p>Learn how to add accessibility features to your unity game. You must understand <a href="https://gamedevbeginner.com/singletons-in-unity-the-right-way/">Singletons</a> and <a href="https://docs.unity3d.com/Manual/class-ScriptableObject.html">Scriptable Objects</a> before starting. In addition, you must have <a href="https://docs.unity3d.com/Manual/com.unity.textmeshpro.html">TextMeshPro</a> installed to use any of the prefabs.

**[If you get stuck on any steps, consult the wiki.](https://github.com/krs9851/unity-accessibility/wiki/Hearing-Accessibility)**

<h1>Hearing Accessibility</h1>

<p>This section has two subsections: closed captions and volume controls. These accessibility features are primarily for Deaf/Hard of Hearing users, but can benefit anyone. For example, if someone is unable or must strain to hear the sound effects or musical cues, they may rely on closed captions for that content. In addition, if someone is trying to listen carefully for certain sound effects, they may want to lower the volume of the music and ambient sounds and turn up the volume of those important sound effects. Of course, this could also apply to blind and low vision users who rely on feedback of important sound effect cues or someone with sensory overload who cannot have multiple sounds playing at once.</p>

<h2>Closed Captions</h2>

<p>Closed captions aren't a "one size fits all". Instead, you should have multiple closed caption options. If a user only wants to read the important auditory cues, that should be an option. If a users wants to read every auditory component of the game, that should also be an option. Even if you can theoretically see something related to the auditory cue on screen, that doesn't change the need for closed captions. A user may not be looking at the related visual component, or pay it any mind, without the closed caption to give it significance.</p> 
<p>For this example, we have the following sections: all sound, critial sound effects, ambient sound, critical musical shifts, music. Critical sound effects and musical shifts means anything that notifies a player of something important. For example, if a player is walking on a frozen lake, the cracking of ice would be critical sound effect.</p>

<h2>Volume Controls</h2>

<p>Like closed captions, users should be able to customize the volume of individual game sounds. Not all sound effects have the same importance, and your volume controls should reflect that. While all sound is essential to the feel of your game, not all sound is essential to being able to participate in playing your game.</p>
<p>For this example, we have the following sections: all sound, critial sound effects, ambient sound, critical musical shifts, music. Critical sound effects and musical shifts means anything that notifies a player of something important. For example, music that notifies a player that an enemy is nearby. This corresponds to the options for closed captions, so if a player turns off the volume of one option, they can turn on its related closed caption.</p>

<h2>Building Closed Captions and Volume Control</h2>

<p>Instead of building closed captions and volume controls seperately, we are going to use one script to achieve both features. Essentially, every time an object wants to play a sound effect, it will call "public float PlaySound(AudioClip audioClip)" the Sound Manager will generate closed captions and return the volume that the sound should be played at. To call this function from the Sound Manager, we will be using <a href="https://gamedevbeginner.com/singletons-in-unity-the-right-way/">Singletons, which you can learn about here</a>. So a basic script to play a sound would look something like this:</p>

```
float volume = SoundManager.Instance.PlaySound(selectedAudioClip); 
audioSource.volume = volume;
audioSource.clip = selectedAudioClip;
audioSource.Play();
```
<p>The music will be controlled by the Sound Manager, so to change the music, objects will call "public void PlayMusic(AudioClip audioClip)". That function will generate closed captions to alert users of the change of music and then play the music at the appropriate volume on repeat. A basic music change would look like this:</p>

```
SoundManager.Instance.PlayMusic(selectedAudioClip); 
```

<p>Once you have implemented <a href="https://gamedevbeginner.com/singletons-in-unity-the-right-way/">Singleton</a> funcionality and understand the basics of <a href="https://docs.unity3d.com/Manual/class-ScriptableObject.html">scriptable objects</a>, it is time to actually implement the Sound Manager.</p>

**[If you get stuck on any steps, consult the wiki.](https://github.com/krs9851/unity-accessibility/wiki/Hearing-Accessibility)**

<p>Steps:</p>
<ol>
  <li>Decide what categories of sounds will exist in your game</li>
  <li>Import the HearingPackage.unitypackage or copy the following scripts into your own project 
    <ul>
      <li><a href="https://github.com/krs9851/unity-accessibility/blob/main/Hearing%20Accessibility/HearingUnityProject/Assets/_Scripts/SoundInfo.cs">SoundInfo.cs</a></li>
      <li><a href="https://github.com/krs9851/unity-accessibility/blob/main/Hearing%20Accessibility/HearingUnityProject/Assets/_Scripts/SO_SoundInfo.cs">SO_SoundInfo.cs</a></li>
      <li><a href="https://github.com/krs9851/unity-accessibility/blob/main/Hearing%20Accessibility/HearingUnityProject/Assets/_Scripts/SoundManager.cs">SoundManager.cs</a></li>
      <li><a href="https://github.com/krs9851/unity-accessibility/blob/main/Hearing%20Accessibility/HearingUnityProject/Assets/_Scripts/ButtonManagerSound.cs">ButtonManagerSound.cs</a></li>
    </ul>
  </li>
  <li>Change the Singleton functionality in SoundManager.cs to your own version</li>
  <li>Change the SoundType enum to fit your sound categories</li>
  <li>Create the so_SoundInfo scriptable object and insert different sounds</li>
  <li>Either add the "Volume & CC" and "ClosedCaptions" prefabs to your scene or recreate them.
    <ul>
      <li>Make sure to keep the layout groups for the ClosedCaptions prefab</li>
      <li>You will want to make a Control and ClosedCaption prefab for each of the different sound types</li>
      <li>Change the Control SoundType for each of the controls</li>
    </ul>
  </li>
  <li>Create the gameObject SoundManager and give it the SoundManager.cs script
    <ul>
      <li>Drag in the serialized objects. Make sure the closed caption texts are in the correct order</li>
    </ul>
  </li>
  <li>Call the PlayMusic and PlaySound functions to play sounds</li>
</ol>
