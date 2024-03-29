
<div align="justify">

## FontApp

![FontApp](fontapp.png)

FontApp generates bitmap fonts for use in 2D applications such as games. It works in a similar manner as [BMFont ](https://www.angelcode.com/products/bmfont/) by AngelCode, so if you are familiar with that application, FontApp will be quite easy to use. Please note however that FontApp is nowhere near as advanced as BmFont and possibly contains many undocumented bugs and features :D

FontApp can generate bitmap fonts from TTF and OTF font files. It can access system fonts installed on the host system as well as custom random font files.

WARNING:  Some fonts don't render correctly at all and some fonts also exhibit graphical anomolies when outlined. It probably has something to do with C# path rendering of fonts. I dunno, using paths was the only way I could get outlined fonts to work (and other things). FontApp works with most fonts so your mileage may vary.

<hr>

### What's New?

v1.0.5 (31 Oct 2023)

- Added option to save JSON using JavaScript case (object keys start with a lower case character).
- Added option to output minified JSON data.



<details><summary>v1.0.4 (8 May 2023)</summary><p>

- Fixed filename shenanigans when saving and exporting.

</p></details>



<details><summary>v1.0.3 (28 Apr 2023)</summary><p>

- Fixed issue where you could save a project without having any font selected.
- Fixed issue where you could initiate an export without any font selected.
- Made the exit menuitem actually exit the application :D

</p></details>



<details><summary>v1.0.2 (28 Apr 2023)</summary><p>

- My dog ate my release notes!

</p></details>



<details><summary>v1.0.1 (v1.0.1 (27 Apr 2023))</summary><p>

- Fixed issue where about dialog hyperlinks had been omitted.
- Fixed issue where atlas background color was not being reset to the correct color when a new project is created.
- Glyphs can now be rendered in pixelated or smooth modes.
- Added a zoom feature.
- Tweaked user interface.

</p></details>



<details><summary>v1.0.0 (26 Apr 2023)</summary><p>

- Initial public release.

</p></details>

<hr>

### Installation

FontApp is distributed as a zip file and is portable, so just download the latest release, unzip it somewhere and then launch the `FontApp` exectable inside the unzipped folder.

FontApp requires the .NET Desktop Runtime (version7.0 x64) which you can download from [Microsofts download page](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).

<hr>

### Use

Operating FontApp shouldn't be overly taxing on your grey-matter but here's a quick rundown of how to use FontApp to generate a bitmap font for your own 2D application.

#### Selecting a font.

Select the font you want to generate a bitmap font from by selecting one of the fonts in the `System Fonts` listbox, or click the little `...` button by the `Custom Font` label to select a custom font from a folder on your system. NOTE: If you change from a custom font to a system font, you can change back to the current custom font by clicking on it's name (not the `...` button).

Use the `Glyphs to Include / Exclude` grid to select which glyphs in the font will be included or excluded from the final output.

NOTE: The output is updated and presented in real-time and you will notice that FontApp tries it's best to arrange the font glyphs inside the atlas in a roughly square area. This is accomplished by using my C# conversion of [PotPack](https://github.com/mapbox/potpack).. A tiny JavaScript library for packing 2D rectangles into a near-square container.

#### Customizing the selected font

Once you have selected a font you can change its appearance using any of the available `Font Options`...

**Size** -  Change the size control to change the size of the selected font.

**Style** - Select a style for your font from the dropdown box. There are four styles to choose from..

- Regular
- **Bold**
- *Italic*
- ***Bold + Italic***

NOTE: Some styles don't seem to work with some fonts, don't ask me why.

**Spacing** - This setting has no visible effect inside FontApp, it is present for the case where you might want that value available in your own applications.

**Render Mode** - You can choose two different rendering modes:

- Pixelated
- Smooth

**Fill** - Click the colored rectangle to change the fill color of the font.

**Outline** - Click the colored rectangle to change the color of the fonts outline.

**Thickness** - Controls the thickness of the fonts outline.

#### Loading and Saving FontApp Projects

FontApp saves its projects as plain text files so there's not too much you need to know about them, except they can be edited in any text editor. This might seem kind of useless but in the case of a custom font file not being able to be found because maybe you moved it.. you can manually edit the project file to point to the correct file, or change it to use a random system font.

#### Exporting

Once you have customized your font you can export the final atlas along with an extra file that contains descriptors about the exported font and the positions of the individual glyphs inside the atlas image.

You can also change a few rudimentary export options in the `Export Options` section of the user interface...

**Include Fields** - You can change these check-boxes to include or exclude the following variables in the exported descriptors file...

- Font Name - Having the font name may be handy in some use cases.

- Glyph Range - Will include the first character of the font (32 or SPACE) and also the last character of the font (127 or DELETE). These are generally useful variables.

- Glyph Spacing -  Only of use if you really need it (like me).

**Format** - There are two possible formats that the descriptors can be exported in...

- Text - The descriptor file will be exported in a plain old text file, with each line in the file describing some aspect of the font.

```
FONTNAME=Exocet-Light
SPACING=2
FIRSTGLYPH=32
LASTGLYPH=127
GLYPH=32,1,1,0,42
```

The first 3 lines are fairly self eplanatory (I hope) and it is really only the `GLYPH` line format that requires some explanation.

The glyph line has the format of CHARCODE,X,Y,WIDTH,HEIGHT where CHARCODE is the glyphs ASCII character code (32 for SPACE), and the remaining values specify the glyphs position and dimensions inside the atlas image.

Parsing the text file should be trivial and you can look in the FontApp code to see how that is done when loading a project.

- JSON - You should probably know what JSON stands for so lets not even go there. 

```
{
  "FontName": "Exocet-Light",
  "GlyphSpacing": 2,
  "FirstGlyph": 32,
  "LastGlyph": 127,
  "Glyphs":[
    {
      "CharCode": 32,
      "X": 1,
      "Y": 1,
      "W": 0,
      "H": 42
    }
  ]
}

```

There are two additional export options that apply to JSON exports..

- JS Names - Selecting this option will cause strings in the output JSON file to be of the correct format for JavaScript.

- Minify - Selecting this option will cause JSON output to be minified (all whitespace removed, and a single line of text).

Parsing the JSON file will be more problematic as you will need a class to decode to and will require some 3rd party package such as [Json.NET](https://www.newtonsoft.com/json) to perform the decoding.

NOTE: If you are using the output with JavaScript, then everything you need is built into JavaScript.

NOTE: I decided to not include the aforementioned package in FontApp, and instead manually generated exported the JSON file in code.

NOTE: All exported glyphs are the same height, which is the height of the tallest glyph in the font.

NOTE: There will be more glyph lines and JSON objects in your own output if you decide to export more than the SPACE character, extras have been omitted in the above examples for readability :)

#### The Atlas

As well as creating a descriptor file, exporting will create an image file for the atlas in PNG format.

NOTE: Each glyph in the atlas is padded on all sides by one pixel.

<hr>

### Notes

FontApp is a Windows application and I'm not sure if it could even be compiled for other platforms.

As you can probably tell, there are a bunch of extra features and what not that could be added to make FontApp better. Raise an issue if you really want it made so and I'll try my lame best ;)

FontApp has been created for my personal use as part of my [FNA](https://fna-xna.github.io/) based 2D game engine. This being the case, there may be nasty bugs (features?) present in FontApp, however, since FontApp is fully open sourced, you can fix those bugs yourself, or maybe raise an issue here and I'll do my best to resolve it.

NOTE: As of v1.0.5 I've given up on FNA and gone back to making HTML5 games, hence the update to make the output more digestable by JavaScript applications :)

And lastly, if you use FontApp and think it's cool, maybe you would consider [buying me a coffee](https://www.buymeacoffee.com/antixdevelu) :)
