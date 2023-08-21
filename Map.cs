using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledMagusProject
{
    internal class Map
    {
        private int tilewidth;
        private int tileheight;
        private int width;
        private int height;

        public Map(int pTileWidth, int pTileHeight,int pWidth, int pHeight)
        {
            tilewidth=pTileWidth;
            tileheight=pTileHeight;
            width=pWidth;
            height=pHeight;

            

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 tilePostion = Vector2.Zero;
            spriteBatch.Begin();
             for(int i = 0; i < width; i++) 
                    { 
            
                    for(int j=0; j < height; j++)
                        {
                            spriteBatch.FillRectangle(tilePostion, new Size2(tilewidth, tileheight), Color.White);
                            spriteBatch.FillRectangle(tilePostion + new Vector2(1,1), new Size2(tilewidth-2, tileheight-2), Color.Black);

                                tilePostion.Y += tileheight;

                        }
                tilePostion.Y = 0;
                tilePostion.X += tilewidth; 
            
                    }
             spriteBatch.End();
        }
    }

}
