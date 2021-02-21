using MarsRover.Business.Abstract;
using MarsRover.Model;
using System;

namespace MarsRover.Business.Services
{
    public class RoverService : IRoverService
    {
        #region ctor

        public Plateau RoverPlateau { get; set; }
        public Position RoverPosition { get; set; }
        public Directions RoverDirection { get; set; }

        public RoverService(Plateau roverPlateau, Position roverPosition, Directions roverDirection)
        {
            RoverPlateau = roverPlateau;
            RoverPosition = roverPosition;
            RoverDirection = roverDirection;
        }

        #endregion

        #region process

        public void Process(string commands)
        {
            foreach (var command in commands)
            {
                switch (command.ToString())
                {
                    case "L":
                        TurnLeft();
                        break;

                    case "R":
                        TurnRight();
                        break;

                    case "M":
                        Move();
                        break;

                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", command));
                }
            }
        }

        void TurnLeft()
        {
            switch (RoverDirection)
            {
                case Directions.N:
                    RoverDirection = Directions.W;
                    break;

                case Directions.S:
                    RoverDirection = Directions.E;
                    break;

                case Directions.W:
                    RoverDirection = Directions.S;
                    break;

                case Directions.E:
                    RoverDirection = Directions.N;
                    break;

                default:
                    throw new ArgumentException(string.Format("Invalid value: {0}", RoverDirection));
            }
        }

        void TurnRight()
        {
            switch (RoverDirection)
            {
                case Directions.N:
                    RoverDirection = Directions.E;
                    break;

                case Directions.S:
                    RoverDirection = Directions.W;
                    break;

                case Directions.W:
                    RoverDirection = Directions.N;
                    break;

                case Directions.E:
                    RoverDirection = Directions.S;
                    break;

                default:
                    throw new ArgumentException(string.Format("Invalid value: {0}", RoverDirection));
            }
        }

        void Move()
        {
            IsValidPosition();

            switch (RoverDirection)
            {
                case Directions.N:
                    RoverPosition.Y++;
                    break;

                case Directions.E:
                    RoverPosition.X++;
                    break;

                case Directions.S:
                    RoverPosition.Y--;
                    break;

                case Directions.W:
                    RoverPosition.X--;
                    break;

                default:
                    throw new ArgumentException(string.Format("Invalid value: {0}", RoverDirection));
            }
        }

        void IsValidPosition()
        {
            if (RoverPosition.X > RoverPlateau.PlateauPosition.X || RoverPosition.Y > RoverPlateau.PlateauPosition.Y)
            {
                throw new IndexOutOfRangeException(string.Format("Invalid position value: {0} {1}", RoverPosition.X, RoverPosition.Y));
            }
        }

        #endregion

        #region print

        public string Print()
        {
            return string.Format("{0} {1} {2}", RoverPosition.X, RoverPosition.Y, RoverDirection);
        }

        #endregion
    }
}