# CoatOfArmsGenerator
Coat Of Arms Generator (written in .NET 5, C# WinForms)

I contend we should build flexible "purpose-built" programs, not focusing on "clean code" like advocates such as Robert Martin.  This program is the second in a series of my purpose-built programs that illustrate "expandable programs".  Expandable programs are those whose functionalty grows then more as new data is introduced.  In this particular case, the coat-of-arms generator's functionalty grows as more data (in this case images - grows).  So as you add an shield-shape or an "ordinary" or a "charge", the number of possible coat-of-arms generated expands.


Designed to be a flexible creator of coat-of-arms. The program randomly picks a shield shape, how to divide the shield (if any) (called divisions or ordinaries), and symbol (if any) (called charges).  Also, it randomly chooses a color from a palete of true heraldric colors for each piece being careful about not overlaying black on black for example. To add new symbol designs or ordinaries or shield shapes, just add a new file in the subdirectories provided.  Just ensure it follows the rules about the picture (for example on symbols, paint any changeable portions black). To simplify the program rather than drawing the geometric ordinaries, we just add the ordinary image in the file and perform color changes.  

Pseudo code lines for the Coat Of Arms generation are:
1) randomly pick ordinary image from directory
2) switch ordinary black to random color
3) if not solid, switch ordinary white to random color
4) resize Ordinary because many shield shapes do not conform to uniform white space border
5) randomly pick shape from directory
6) frame the shield shape over the resized ordinary chopping off extra
7) overlay randomly picked symbol
8) switch symbol black to random color 


