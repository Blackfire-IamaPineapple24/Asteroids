using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class SpriteParticle : Sprite
    {
        protected float _duration, startSize, endSize;

        public SpriteParticle(Texture2D texture, Vector2 location, Vector2? velocity = null, float? angle = null, Color? colour = null, float? duration = null, float? startSize = null, float? endSize = null) : base(texture, location, velocity, angle, colour)
        {
            
        }
    }
}
