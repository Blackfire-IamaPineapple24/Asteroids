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
    public class SpriteParticleShot : SpriteParticle
    {        
        public SpriteParticleShot(Vector2 location, Vector2 velocity) : base(AsteroidsData._particleTxr, location, velocity, Color.White, 60f, 1f, 1f)
        {
            _canCollide = true;
        }
    }
}
