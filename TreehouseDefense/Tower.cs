using System;

namespace TreehouseDefense
{
  class Tower 
  {
    private const int _range = 1;
    private const int _power = 1;
    private const double _accuracy = .75;
    
    private static readonly Random _random = new Random();
    
    private readonly MapLocation _location;
    
    public Tower(MapLocation location)
    {
      _location = location;
      //create validation so you can't place towers on the path.
      
    }
    
    public bool IsSuccessfulShot()
    {
      return _random.NextDouble() < _accuracy;
    }
    
    public void FireOnInvaders(Invader[] invaders)
    { 
      foreach(Invader invader in invaders)
      {
        if(invader.IsActive && _location.InRangeOf(invader.Location, _range))
        {
          if(IsSuccessfulShot())
          {
            invader.DecreaseHealth(_power);
            Console.WriteLine("Shot at and hit an invader!");
            
            if(invader.IsNeutralized)
            {
              Console.WriteLine("Neutralized an invader!");
            }
          } 
          else
          {
            Console.WriteLine("Shot at and missed and invader.");
          }
          break;
        }
      }
    }
  }
}