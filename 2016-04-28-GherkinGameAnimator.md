![headerImage](images/2016/04/remixGameAni.jpg)
# Gherkin Game Animator
###### The Story So Far
This was my final college assignment for Chichester College in 2013. The project was beyond the scope of the course and as far as I got was to parse a man and a scene into a 3d navigable environment with some non working controls on the screen.

I have learned very much in my time since college and this project aims to complete my first open source application. Any minor look and feel infringements will (I hope) be forgiven.

## The Brief

+ Import and rig a .obj model with groups from Maya and rig a Human IK skeleton to it.
+ Create an Adobe Flash-like time-line onion skinning environment for creating cubic-spline angular and displacement animations.
+ Implement Joints influenced by 2+ bones.
+ Export to a c# class including all necessary data storage formats.
+ Use this to build the most basic implementation of Virtua Fighter 1.

## Why?
Games animators always use key frames and tweening to create clips. But what if what you really wanted was an animation which could stop half way through a move and go in the direction of another keyframe (possibly even merge to a different tween)
I had learned about cubic splines in school and thought htis would be a perfect opprotunity to utilise them in a 3d environment.

## My background knowledge
I worked all of this out from first principals so it may not neccessarily be the best way to do things

## The Workflow
### Import and rig
1. Import a well laid out model from Maya or max in .obj format with some groups defined (i.e. so that a joint in the arm does not influence the stomache even though they may be close to each other)
2. get given an IK rig of a human being and move the nodes around into the right places.
3. using a highlighting tool defing which polygons are each side of a joint
4. using a tool similar to Maya's joint tool define the polygons in a joint and the influence on them by different bones.
* at all times it should be possible to move the joints and see how things are working out.

### Animate
1. Take the rigged model (and I may even warm up with a hieracrhical model rather than jointed) and pose it.
2. capture the pose and define velocities of all parts before and at end of tween (and at keyframes within) the onionskinning process should utilise alpha transparent models at every 5th or 10th fram to see how things are going thus manipulating a velocity at start would alter all frames instantaneously.

### Compose
+ A basic keyboard based game action composer should allow to jump to different keyframes via hlaf tweens in the middle of a tween at various motion speeds.

### Compile
+ The character would be output as a C# group of classes or compiled .dll effectively offering methods for moves in real time and returning a snapshot of the model in 3d space relative to ?origin at a given time.

## Technology To be utilised
I am going to make heavy use of MSCodeProvider because if you can see a c# class it is a lot easier to use.
Sense dictates that we do not emit to text files and then compile from disk as a program which does that could be dangerous. Instead emit c# to a text file and then make a dll and serialise the objects.

The cubic splines from A-Level maths will handle movement.

Plenty of exception handling

Regex

C# WPF for graphics.

## Implementation
### Stages
#### Phase 1
1. Create a skeleton class for each character with static properties for the positions of the limbs and polygon data.
2. Create a spline set of classes.
3. Test rendering of character at various poses with stacked matrices.
4. Build a UI utilising custom classes for keyframe which should render a user control which a c# user would recognise **or** should I make custom user controls. **i think** create user controls with meaningful properties and events which alter abstracted entities like frames.
5. get to grips with drag and drop in 3d within a viewport (big one)
6. Improve UI to offer **gizmo**-like tools for initial and final velocity.

#### Phase 2
