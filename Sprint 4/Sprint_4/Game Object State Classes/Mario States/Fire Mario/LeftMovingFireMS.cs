﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftMovingFireMS : IMarioState
    {
        Mario mario;
        IAnimatedSprite sprite;

        public LeftMovingFireMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftMovingMarioFire);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new LeftMovingSmallMS(mario));
        }
        public void Up()
        {
            mario.state = new LeftJumpingFireMS(mario);
        }
        public void Down()
        {
            mario.state = new LeftCrouchingFireMS(mario);
        }
        public void GoLeft()
        {
            mario.position.X--;
        }
        public void GoRight()
        {
            mario.state = new RightMovingFireMS(mario);
        }
        public void Idle()
        {
            mario.state = new LeftIdleFireMS(mario);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            mario.state = new LeftMovingBigMS(mario);
        }
        public void MakeSmallMario()
        {
            mario.state = new LeftMovingSmallMS(mario);
        }
        public void MakeFireMario()
        {
           // null
        }
        public void MakeFireballMario()
        {
            // null
        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
