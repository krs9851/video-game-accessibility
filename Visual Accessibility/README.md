# unity-accessibility
<p>Learn how to add accessibility features to your unity game. You must have <a href="https://docs.unity3d.com/Manual/com.unity.textmeshpro.html">TextMeshPro</a> installed to use any of the prefabs.

**[If you get stuck on any steps, consult the wiki.](https://github.com/krs9851/unity-accessibility/wiki/Visual-Accessibility)**

<h1>Visual Accessibility</h1>

<p>Visual accessibility focuses on how the player can identify and understand your game's visual content. This includes text-based, color-based, image-based, and animated content. Visual accessibility is not just for those with blindness or low vision, and instead can allow access for a variety of disabilities. This includes dyslexia, sensory disabilities, attention disabilties, color-blindness, migraines, and many more.</p>

<p>Most visual accessibility features are game specific, including voice-over for visual cutscene information, voice-over for dialogue, text size, removing unnecessary animations, and location of UI elements. This section has two subsections: adjusting text's font and color. These accessibility features are for a variety of different disabilities, including cognitive disabilities and vision disabilities.</p>

<p>Player customization is incredibly important for this section. By having multiple color and font options, you can prioritize the original feel of the game for the majority of players, while still making it accessible.</p>

<p>For font, we recommend having at least three options: original font, sans-serif font, and Open Dyslexic. <a href="https://opendyslexic.org/">Open Dyslexic is an open font that is specifically made for people with dyslexia.</a> We also recommend using TextMeshPro assets to help reducing blurry text. <a href="https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/manual/FontAssetsCreator.html">Learn how to make text mesh pro font assets here.</a></p>

<p>For colors, we recommend having four options: original, high-contrast light mode, high-contrast dark mode, and low-contrast mode. Visual disabilities include a wide array of conditions and experiences, so what works for one person with low vision may not work for another one. Low contrast mode can also help people with sensory disabilities, especially those who experience sensory overload.</p>

<h2>Font Adjustments</h2>

<p>Like most other accessibility features, font adjustments are not one size fits all. While stylized font is important to game aesthetic, readability can be greatly decreased by it. That doesn't mean stylized text is wrong, it just means that you should have font alternatives. On computer screens, sans-serif fonts are generally accepted as the a more readable fonts, even for those without disabilities. For people with dyslexia, Comic Sans or Open Dyslexic are generally accepted as more readable.</p>

<p>One thing to keep in mind is that some fonts, even at the same size, can take up more space than other fonts. This is especially true for Open Dyslexic since it has more space between letters. All of your text elements should have a little extra room in your original font, to make sure there is no overflow when adjusting it. Testing is essential. If information is lost by adjusting font, then the accessibility feature is not usable.</p>

<p>Players should be able to adjust the font at the beginning of the game, and throughout the game as needed. We recommend using a dropdown that contains all of the font options.</p>

<h3>Building Font Adjustments</h3>

<p>The scripts and assets that focus on changing font can be found under the ChangingFont folder. The code will change all text in every loaded scene, except for text in the Do Not Destroy On Load scene.</p>
  
<p>The function SceneChange of FontManager.cs should be called every time a scene is loaded or unloaded. If a canvas is spawned after a scene is loaded, it should call the Register function of FontManager.cs and pass in itself. This way, all of the text it contains will be changed to the correct font.</p>

<p><b><a href="https://github.com/krs9851/video-game-accessibility/wiki/Visual-Accessibility">If you get stuck, consult the wiki!</a></b></p>

<p>Steps:</p>
<ol>
  <li>Decide what your original, sans-serif, and dyselxia friendly fonts will be
    <ul>
      <li>Import those fonts into your project and, optionally, <a href="https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/manual/FontAssetsCreator.html">make TextMeshPro versions of the .otf files</a></li>
    </ul>
  </li>
  <li>Import the <a href="https://github.com/krs9851/video-game-accessibility/blob/main/Visual%20Accessibility/changingfontpackage.unitypackage">changingfontpackage.unitypackage</a> or download the <a href="https://github.com/krs9851/video-game-accessibility/blob/main/Visual%20Accessibility/ChangingFont/Assets/_Scripts/FontManager.cs">FontManager.cs</a> script into your own project</li>
  <li>Make an empty gameObject and attach the FontManager script. Give it the fonts you chose in the proper order
    <ul>
      <li>Make sure that the order for Fonts Pro and Fonts are the same</li>
    </ul>
  </li>
  <li>Use the <a href="https://github.com/krs9851/video-game-accessibility/blob/main/Visual%20Accessibility/ChangingFont/Assets/Prefabs/Dropdown.prefab">Dropdown prefab</a> as an example for how to set up the dropdown that changes font options
  <ul>
    <li>We do not recommend having the scipt FontManager.cs attached to your dropdown, that was just to showcase how to format the script</li>
    <li>The dropdown options should correspond to the font types you chose and imported. (ex. pixel font, sans-serif, dyslexia friendly, etc)</li>
    <li>Make sure the order in the dropdown matches the order for Fonts Pro and Fonts in FontManager.cs</li>
    <li>When OnValueChanged is called for the dropdown, it should call the ChangeFont function of FontManager.cs</li>
   </ul>
  </li>
  <li>Call the SceneChange function of FontManager.cs every time the scene changes</li>
  <li>Call the Register function of FontManager.cs every time a canvas or text/TextMeshPro gameObject is spawned in the scene, and pass in the canvas or text/TextMeshPro gameObject</li>
</ol>

<h2>Color Adjustments</h2>

<h3>Building Color Adjustments</h3>
