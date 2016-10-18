// Copyright (c) 2016 robosoup
// www.robosoup.com

using System.Collections.Generic;

namespace Boids
{
    class Swarm
    {
        public List<Boid> Boids = new List<Boid>();

        public Swarm(int boundary)
        {
            for (var i = 0; i < 15; i++)
                Boids.Add(new Boid((i > 12), boundary));
        }

        public void MoveBoids()
        {
            foreach (var boid in Boids)
                boid.Move(Boids);
        }
    }
}
