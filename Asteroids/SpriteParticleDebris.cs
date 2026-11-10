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
    public class SpriteParticleDebris : SpriteParticle
    {
        protected static float _debrisSpeed = 500f;

        public SpriteParticleDebris(Vector2 location) : base(AsteroidsData._particleTxr, location, GetSpawnVelocity(), Color.White, 3.0f) { }

        private static Vector2 GetSpawnVelocity()
        {
            float angle = AsteroidsData._rng.NextSingle() * float.Tau;
            float speed = _debrisSpeed * AsteroidsData._rng.NextSingle();
            return new Vector2(float.Cos(angle), float.Sin(angle)) * speed;
        }
    }
}
