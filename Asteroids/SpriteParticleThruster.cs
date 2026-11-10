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
    public class SpriteParticleThruster : SpriteParticle
    {
        public SpriteParticleThruster(Vector2 location) : base(AsteroidsData._particleTxr, location, null, Color.LightSalmon, 5f, 2f)
        {
            _canCollide = true;
        }
    }
}
