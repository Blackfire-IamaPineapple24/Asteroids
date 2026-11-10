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
        protected float _duration, _lifeCounter, _startSize, _endSize;
        
        public SpriteParticle(Texture2D texture, Vector2 location, Vector2? velocity = null, Color? colour = null, float? duration = null, float? startSize = null, float? endSize = null) : base(texture, location, velocity, null, colour)
        {
            _duration = duration ?? 1f;
            _lifeCounter = _duration;
            _startSize = startSize ?? 1f;
            _endSize = endSize ?? 0f;
            _canWrap = false;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            if (_isDead) return;

            base.UpdateSprite(gameTime);

            _lifeCounter -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            float currentSize = float.Lerp(_endSize, _startSize, _lifeCounter / _duration);
            _drawBounds.Size = (_drawBounds.Size.ToVector2() * currentSize).ToPoint();

            if (_lifeCounter < 0 || !AsteroidsData._screenBounds.Contains(_location)) _isDead = true;
        }
    }
}
