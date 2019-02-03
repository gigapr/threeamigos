# Three Amigos

## Background

### Traffic Signals
#### Purpose
Traffic signals are often used on roads to better control and manage the flow of *traffic*, at junctions and other areas of conflicting traffic movements (e.g. at pedestrian crossings), and to improve safety of road users at conflict points.

#### Traffic
Traffic should not be seen as vehicles and drivers alone. It includes other road users such as pedestrians, cyclists, horse riders, and trams.

#### Traffic Signal Controllers
To implement control and timing of traffic signals, by turning *traffic signal aspects* (or lights) on and off, special hardware in the form of *traffic signal controllers* are installed at traffic-signal-controlled sites. Such controllers have relevant electric power and electronic components and software for turning traffic signal aspects on and off, as dictated by *traffic signal plans* and safety configuration parameters that have been preprogrammed into them at prior to *commissioning*. Many modern traffic signal controllers are capable of controlling more than one traffic signal site simultaneously, reducing *street furniture* and costs of installation. In a lot of cases, traffic signal controllers manage signal timings with the help of data from external inputs from detectors installed on the road and connected up to the controllers. In the case of larger cities, traffic signal controllers are networked with a central remote *urban traffic control* system, from which they receive commands that dictate the traffic signal timings that they implement.

#### Urban Traffic Control Systems
Urban traffic control (*UTC*) systems are usually used in larger cities to allow a *traffic management authority* to monitor and dictate traffic signal timings, to on-street traffic signal controllers, from a centralised location. This allows the authority to use other sources of real-time information, such as knowledge of up-coming or current special events and other disruptions to normal traffic flow, such as accidents and other emergencies, which may have been observed via city-wide closed-circuit television (*CCTV*) networks or reported by law enforcement authorities. UTC, combined with the on-street traffic controllers and detectors connected to them form a supervisory control and data acquisition (*SCADA*) system whose purpose is to monitor and control the movement of road users to match relevant policies.

Even where UTC is used to dictate and adjust traffic signal timings, the on-street traffic controllers enforce safety parameters that have been preprogrammed into them. This ensures that any errors made by traffic signal managers, in formulating timings that are demanded of signal controllers by UTC do not put road users at risk. UTC systems normally include their own configuration and safety parameters which, where relevant, include or are derived from the safety parameters of the traffic signal controllers that they control and UTC systems monitor the actions reported by traffic signal controllers to ensure that they are operating within the specified parameters. Where the UTC system finds that a particular traffic signal controller appears to not be following the demands of UTC, it may decide to change the method by which the traffic signal controller sets signal timings. For example, UTC may revert to allowing the traffic signal controller to run plans that have been preprogrammed into it, while only monitoring the traffic signal controller and raising a warning or alarm for the attention of a traffic signal manager or maintenance technicians.

### Signal Types and Signal Aspects
#### Signal Aspects
A single traffic signal is made up of one or more traffic *signal aspects*. In a modern traffic signal, an aspect is a light bulb or one or more light-emitting diodes (LEDs), which emits a particular colour of visible light and/or forms a particular pattern, depending on the type and purpose of the aspect. For example, in Britain, a standard vehicular traffic aspect forms a coloured circle of light that may be red, amber, or green. This light may be displayed in the form of an arrow to indicate its applicability to a particular movement of traffic only (e.g. left-turning traffic only).

Signal aspects may also be used to light up a static road traffic signal to indicate its applicability at the current time of day. For example a signal aspect may be used to light up a no-right-turn sign for particular periods of the day.

Physical specifications of a traffic signal aspect depend on local or national regulations, but for the sake of developing a software model of a signal aspect, it should be treated as something that can have two or more states. These states may be on, off (or flashing), or may indicate the image that the aspect displays in that state. Therefore, at the lowest possible level, a signal aspect is of a particular type, which defines its colour and/or other capabilities.

#### Signal Types, Aspect Counts, and Aspect Types
A signal itself may be of a particular type, which defines the type and number of aspects that it is made up of.

A three-aspect traffic signal is the most common type of traffic signal around the world. Normally, the top aspect is red, the middle is amber/orange/yellow, and the bottom is green. In almost all cases, red dictates to road users who face the signal that they must remain stopped behind a stop line that has either been drawn on the surface of the road or is implied in some other way, such as by the position of the pole on which the signal has been installed. The meaning of traffic signal aspects and their on and off combination patterns (and expected actions of road users, when they observe them) is defined by local or national regulations. In the case of Britain, the meaning of these signals and other road signs are defined by the [Highway Code](https://www.gov.uk/guidance/the-highway-code). In some parts of the world, a red signal means stop to all traffic approaching it, but in other parts of the world, there may be an implied permission to turn right/left while giving way to opposing traffic. In some cases (such as that in Britain), a green signal may still mean the need to give way to opposing traffic (e.g. when making right-turns at junctions).

Some signals may be made up of only two aspects. For example, in Britain, a pedestrian traffic signal is made up of a red and a green aspect only, with red (normally in the shape of a person standing) indicating that pedestrians must stop by the edge of the road until the red aspect is turned off and the green aspect is turned on. The green aspect (normally in the shape of a person walking) indicates to pedestrians that they may enter the road to cross it, if safe, and have been given adequate time to make the crossing before a conflicting movement of traffic is given right of way. In the case of *pelican* crossings, the green aspect may flash before being turned off and the red aspect being turned back on while, at other types of crossing, there may be a black-out period (where neither the red, nor the green aspect are on). Now-a-days, in London, it is possible to come across pedestrian traffic signals that include a *countdown* aspect, which displays the number of seconds remaining before the red aspect is switched back on and right of way is lost. In other parts of the world, countdown aspects may be used on vehicular traffic signals too to inform drivers of the number of seconds remaining before the green signal is turned on or off (usually the former, as the latter may encourage speeding by drivers).

In some cases, a signal may be made up of just one aspect, which emits different patterns of light. For example, in Britain, a single white light aspect is used to control tram traffic. The aspect forms a white horizontal bar of light to indicate that trams must remain stopped, a while vertical bar to indicate that they have the right of way, or a small circle of white light, to warn that trams must stop unless it is not safe to do so (e.g. the signal changed just as the tram driver crossed the stop line).

In summary, a traffic signal type dictates the number of aspects it is made up of and the type of each of these aspects. Therefore, a particular traffic signal type is a composition of one or more traffic signal aspect types. A traffic signal type is also capable of cycling through two or more states and, under each state, a different combination of aspect states may be active.

#### On, Off, and Flashing Aspects and Their Combinations
As mentioned above, a single traffic signal may have a number of aspects. These aspects can be on or off, depending on the traffic signal type, which is itself defined by local or national regulations. For example, in Britain, a vehicular signal whose only currently on aspect is red denotes the order to remain stopped. This is then followed by a combination of the red and amber aspects both turning on, to indicate the impending turning on of the green signal, before both the red and amber aspects are turned off and the green aspect is turned on to indicate the right of way (unless turning right or the exit is blocked). Later, this is followed by only the amber aspect being turned on to order vehicles to stop behind the stop line, unless it is not safe to do so. The amber aspect turns off as the red aspect alone is turned back on.

Differences in regulations around the world mean that different combination of traffic signal aspect on or flashing states will apply (internationally), at different times, as a traffic signal cycles through its states. For example, in some parts of the world, the red signal is immediately followed by a green signal, with no transition through amber. Also, as a signal cycles from one state to another, other constraints may need to be met. For example, in the case of a vehicular signal in Britain, the amber-only state must last exactly 3 seconds, while the amber and red state must last exactly 2 seconds. Neither of these two states counts as the right of way having been given to traffic.

Depending on their purpose and local or national regulations that apply, aspects of a traffic signal may be made to flash (i.e. turn on and off). For example, in Britain, pedestrian green aspects at pelican crossings flash, after a period of being on, to indicate the imminent loss of right of way by pedestrians and to indicate that pedestrians must not start crossing. At the same time, the amber aspect of the opposing/crossing traffic signal flashes to indicate to drivers that they may proceed, only if there are no pedestrians still crossing.

In some parts of the world, flashing signals are used during lower traffic level/*demand* periods such as during the very early hours of the morning to reduce delay to road users that cycling through signals may cause. Here, flashing red aspects may indicate that drivers facing the signal must note that they are on a minor road and must give way to traffic on the main road, while signals on the main road have flashing ambers aspects to indicate to drivers that they are travelling on the main road, but must proceed with caution nevertheless.

Based on the above, software that models a traffic signal must be capable of cycling through all states that apply, based on applicable regulations, and ensure that the relevant signal aspect states occur. This, of course, means that the signal is composed of relevant aspects, which also meet applicable regulations. 

#### Indicative and Sign Aspects
As mentioned earlier, as well as displaying a particular colour of light, a traffic signal aspect may display a particular pattern, shape, or silhouette, or may simply turn on (or off) a static traffic sign (such as one that indicates the lack of permission to turn left).

In the case of vehicular traffic, traffic signal aspects may display arrows to indicate the turn directions to which the signals apply. Again, the use and shape of these arrows are usually specified by local or national regulations. For example, in Britain, no red or amber arrow aspects are used. Instead, only green arrows are used to indicate the permission to turn left (called a *left filter arrow*) or to indicate that right-turning traffic has full right of way (called an *indicative right arrow*). In such cases the single arrow aspects are actually part of a separate signal, which is associated with or is dependent on the state of a three-aspect signal (explained later, under **Phases**). For example, in Britain, a filter arrow signal precedes the associated 3-aspect signal's green signal and an indicative right arrow signal follows the associated 3-aspect signal's green signal.

In some cases, an aspect may display words, such as *BUS*, in the case of signals for buses in Ireland, or *Don't Walk*, to tell pedestrians to not attempt to cross the road in some parts of the USA. Unless the physical implementation of these signal aspects is such that the pattern or image displayed by them can be controlled by software (alike a dot-matrix display), the pattern or image can be thought of as a hardware implementation detail only(e.g. installing the relevant pattern mask over the signal aspect).

So, when defining a traffic signal type, it may be necessary for the type to be capable of being associated with another traffic signal. Relevant (safety and regulatory) mechanisms will also need to be implemented to ensure that any rules or regulations on signal dependency and precedence are adhered to.

### Phases and Stages
#### Traffic Movements, Traffic Signal Phases, and Traffic Signal Counts
At a road crossing or junction, different or the same *modes* of traffic (e.g. vehicles and pedestrians or vehicles and vehicles) come into conflict and it is necessary to control these conflicts to ensure safety and to manage traffic flow. To do so, it is necessary to model the various traffic movements or turns that are permitted to take place at the crossing or junction. In most cases, each movement will have different levels of traffic and demand and, therefore, needs to be controlled by a dedicated traffic signal of the relevant type (e.g. a 3-aspect vehicular or 2-aspect pedestrian signal). This also provides the capability to manage every possible combination of movements, to minimise traffic delay.

In traffic control engineering, in Britain, the term *phase* is used to denote and model a particular traffic signal and is named after a unique letter of the alphabet (beginning with `A`) for the site in question. In reality, a single phase may be used to control multiple physical signals. This is because, at most traffic signal sites, multiple copies of the signal for a particular movement may be installed to ensure adequate visibility of the signal states to relevant road users. For example, on a multi-lane approach, a gantry may be installed, across the width of the road, with multiple signals for the same movement installed on it to ensure that drivers in each lane can clearly see the signal that applies to them. Therefore, a traffic phase can control more than one physical signal, but all signal types must be the same and match the phase's type (e.g. a standard vehicular movement phase may only be associated with 3-aspect vehicular signals). A phase type is, therefore, closely associated with a particular signal type.

#### Phase Conflicts
**TODO**

#### Dummy Phases
**TODO**

#### Minimum and Maximum Green Signal Durations
**TODO**

#### Intergreens and Variable Intergreens
**TODO**

#### Stages
**TODO**

### Signal Timing Plans
**TODO**

### Cycles, Splits, Offsets, and Co-ordination
**TODO**
* Cyclical Nature of Signal Timing Plans
* Sharing Cycle Period Between Movements
* Co-ordinating Signals Between Sites and Traffic Platooning

### Detectors and Optimisation
**TODO**
* Variability of Demand
* Inadequacy of Fixed Signal Timings
* Detection of Traffic Demand
* Detection of Traffic Volume
* Detector Types (Induction, Infrared, Radar, Image Recognition)

## What We are Aiming to Build
**TODO**
* Traffic Signal Controller Software and Interface Definitions for Integration with Signalling Hardware and Detectors
* Tools for Configuring Traffic Signal Controller Software Instances
* Tools for Developing and Validating Signal Timing Plans
* Mechanisms for Monitoring and Co-ordinating Signal Timings Between Sites
* Mechanisms for Monitoring and Co-ordinating Signal Timings With a Central System
