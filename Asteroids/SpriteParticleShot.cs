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

        public override void UpdateSprite(GameTime gameTime)
        {
            AsteroidsData._spriteList.OfType<SpriteRock>().ToList().ForEach(eachRock =>
            {
                if (IsColliding(eachRock))
                {
                    _isDead = true;
                    eachRock.OnHit();
                }
            });

            base.UpdateSprite(gameTime);
        }
    }
}
