# Flocking-Boids
An example of swarm intelligence based on the Boids model.

This is the code behind my original December 2008 blog post [FlockingBoids (C#)](http://www.robosoup.com/2008/12/flocking-boids-c.html).

In my ecosystem, two different types of Boids exist, namely Regular Boids and Zombie Boids. The Regular Boids are very social, fast moving creatures, which like to flock together. The Zombie Boids are solitary soles, whose single reason for living is to chase after Regular Boids, albeit very slowly.

There is no real problem I am trying to solve here, other than to enjoy watching the carnage that emerges! It would be very easy to add nicer graphics, or even turn this simulation into a screen saver. As usual, the full C# source code to generate this application is listed below.

Before I go into detail about the code, some background on Boids. In 1986, Craig Reynolds developed a computer model that simulated animal movement, such as flocks of birds and schools of fish. He called the simulated flocking creatures Boids.

As with most artificial life simulations, Boids is an example of emergent behaviour. The complexity of Boids arises from the interaction of individual agents complying with a simple set of rules. Reynolds basic flocking model consisted of three simple steering behaviours that determined how individual Boids should manoeuvre based on their velocity and position within the flock:

Separation: steer to avoid crowding local flock-mates
Cohesion: steer to move toward the average position of local flock-mates
Alignment: steer towards the average heading of local flock-mates

To provide even more life like effects, further rules could be added, such as obstacle avoidance and goal seeking.

The flocking algorithm requires that each Boid only react to flock-mates within its local neighbourhood. This neighbourhood is defined by the Boid’s field of view relative to the rest of the flock. Flock-mates outside of this neighbourhood are ignored.

This [YouTube video](https://youtu.be/HBvin3jXjsQ) shows an example of the behaviour you can expect to emerge.
