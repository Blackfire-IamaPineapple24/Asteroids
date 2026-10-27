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
    public class SpriteShip : Sprite
    {
        protected float _drag = 0.5f;
        protected float _forwardThrust = AsteroidsData._screenBounds.Width;
        protected float _angularThrust = float.Pi;
        protected bool _moving = false;
        protected int _turning = 0;

        public SpriteShip(Vector2 location, Vector2? velocity = null, float? angle = null, Color? colour = null) : base(AsteroidsData._shipTxr, location, velocity, angle, colour) {}

        public override void UpdateSprite(GameTime gameTime)
        {
            _velocity *= float.Lerp(1f, _drag, (float)gameTime.ElapsedGameTime.TotalSeconds);
            _velocity.X = float.Clamp(_velocity.X, -AsteroidsData._screenBounds.Width * 2f, AsteroidsData._screenBounds.Width * 2f);
            _velocity.X = float.Clamp(_velocity.X, -AsteroidsData._screenBounds.Height * 2f, AsteroidsData._screenBounds.Height * 2f);

            if (_moving) _velocity += GetForward() * _forwardThrust * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _angle += _turning * _angularThrust * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.UpdateSprite(gameTime);
        }
    }
}
