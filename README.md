# ProjectX

Making a tetris clone with multiplayer functionality like tetrinet

## Tetrinet

TetriNET plays like standard multiplayer Tetris but with a twist: clearing rows will cause special blocks to appear in the player's field. If a line containing a special block is cleared, then that special block is added to the player's inventory. Clearing multiple lines at once increases the number of special blocks received.

At any point, a player may use the special block at the beginning of their inventory on one of the six fields (either their own or an opponent's). The effect depends on the type of special block:

- a : Add Line - Adds one broken line to the bottom of the target field. 
- c : Clear Line - Clears the line on the bottom of the target field.
- b : Clear Special Blocks - Causes all special blocks on the target field to return to normal blocks.
- r : Random Blocks Clear - Random blocks are removed from the target field, often creating gaps in lines.
- o : Block Bomb - Causes any Block Bombs on the target field to "explode", causing surrounding pieces to scatter throughout the field.
- q : Blockquake - Causes blocks on each line on the target field to shift, creating an earthquake-like effect.
- g : Block Gravity - Causes blocks on that target field to immediately fall into any gaps and instantly deletes any complete lines which are created.
- s : Switch Fields - User and target switch fields.
- n : Nuke Field - Removes all blocks from the target field.

The last player still able to place pieces in their field is the winner.

Depending on the server used, some alternative rules may be available.

pure: special blocks are disabled, providing gameplay similar to traditional multiplayer Tetris.
7tetris: the first player to make seven Tetris is the winner.

