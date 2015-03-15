﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightCrouchingFireMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;
        

        public RightCrouchingFireMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightCrouchingMarioFire);
            this.game = game;
        }
        public Rectangle getRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }

        public void TakeDamage()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightCrouchingSmallMS(game));
        }
        public void Up()
        {
            game.level.mario.state = new RightIdleFireMS(game);
        }
        public void Down()
        {
            game.level.mario.position.Y++;
        }
        public void GoLeft()
        {
            game.level.mario.state = new LeftCrouchingFireMS(game);
        }
        public void GoRight()
        {
        }
        public void Idle()
        {
            game.level.mario.state = new RightIdleFireMS(game);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            game.level.mario.state = new RightCrouchingBigMS(game);
        }
        public void MakeSmallMario()
        {
            game.level.mario.state = new RightCrouchingSmallMS(game);
        }
        public void MakeFireMario()
        {
            // null
        }
        public void MakeDeadMario()
        {
            game.level.mario.state = new DeadMS(game);
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