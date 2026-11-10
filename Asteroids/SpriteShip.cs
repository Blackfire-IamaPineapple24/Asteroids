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
        protected bool _shooting = false;
        protected float _shootTimer = 1f / 3f;
        protected float _shootCooldown = 1f / 3f;
        protected float _shotSpeed = 1000f;
        protected float _shotKickback = 50f;

        public SpriteShip(Vector2 location, Vector2? velocity = null, float? angle = null, Color? colour = null) : base(AsteroidsData._shipTxr, location, velocity, angle, colour) {}

        public override void UpdateSprite(GameTime gameTime)
        {
            _velocity *= float.Lerp(1f, _drag, (float)gameTime.ElapsedGameTime.TotalSeconds);
            _velocity.X = float.Clamp(_velocity.X, -AsteroidsData._screenBounds.Width * 2f, AsteroidsData._screenBounds.Width * 2f);
            _velocity.X = float.Clamp(_velocity.X, -AsteroidsData._screenBounds.Height * 2f, AsteroidsData._screenBounds.Height * 2f);

            Vector2 forward = GetForward();

            if (_moving)
            {
                _velocity += GetForward() * _forwardThrust * (float)gameTime.ElapsedGameTime.TotalSeconds;
                AsteroidsData._newSpriteList.Add(new SpriteParticleThruster(_location - (GetForward() * 16f)));
            }
            _angle += _turning * _angularThrust * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_shooting)
            {
                if (_shootTimer <= 0f)
                {
                    _shootTimer = _shootCooldown;
                    AsteroidsData._newSpriteList.Add(new SpriteParticleShot(_location + (GetForward() * 32f), GetForward() * _shotSpeed));
                    _velocity -= forward * _shotKickback;
                }
                else
                {
                    _shootTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            else
            {
                _shootTimer = 0f;
            }

            base.UpdateSprite(gameTime);
        }
    }
}
