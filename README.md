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
#### Traffic Movements, Traffic Signal Phases, and Traffic Signals
At a road crossing or junction, different or the same *modes* of traffic (e.g. vehicles and pedestrians or vehicles and vehicles) come into conflict and it is necessary to control these conflicts to ensure safety and to manage traffic flow. To do so, it is necessary to model the various traffic movements or turns that are permitted to take place at the crossing or junction. In most cases, each movement will have different levels of traffic and demand and, therefore, needs to be controlled by a dedicated traffic signal of the relevant type (e.g. a 3-aspect vehicular or 2-aspect pedestrian signal). This also provides the capability to manage every possible combination of movements, to minimise traffic delay.

In traffic control engineering, in Britain, the term *phase* is used to denote and model a particular traffic signal and is named after a unique letter of the alphabet (beginning with `A`) for the site in question. In reality, a single phase may be used to control multiple physical signals. This is because, at most traffic signal sites, multiple copies of the signal for a particular movement may be installed to ensure adequate visibility of the signal states to relevant road users. For example, on a multi-lane approach, a gantry may be installed, across the width of the road, with multiple signals for the same movement installed on it to ensure that drivers in each lane can clearly see the signal that applies to them. Therefore, a traffic phase can control more than one physical signal, but all signal types must be the same and match the phase's type (e.g. a standard vehicular movement phase may only be associated with 3-aspect vehicular signals). A phase type is, therefore, closely associated with a particular signal type.

When a phase is said to be green, it means that the movements the phase controls have been given the right of way and their on-street traffic signals are denoting this by way of displaying the pattern and/or colour that regulations specify as having the right of way. When a phase is said to be red, it means that the movements the phase controls have lost the right of way and their on-street traffic signals are denoting this in the way in which regulations dictate. For example when, in Britain, a vehicular signal changes from green to amber, its associated phase is effectively red, as amber is an order to stop. The phase continues to be seen as red while the signal is red and even when the red and amber combination of signals are shown. Only when the signal is green does its phase become green.

#### Phase Conflicts
At traffic signal sites, a number of movements will be in conflict with other movements. To ensure safety of road users, the traffic signal phases that give these movements the right of way must never be green at the same time. To enforce this, traffic signal controllers are configured to be aware of conflicting phases and to never allow them to be green at the same time, even if specified in traffic signal timing plans.

In traffic controller specications, phase conflicts are normally denoted within a matrix/table similar to that shown below. In this example, phases that conflict have a cross placed where their columns and rows intersect. Those that do not conflict have no such indication at their intersection.

| |A|B|C|D|
|-|-|-|-|-|
|A|-| | |X|
|B| |-|X|X|
|C| |X|-| |
|D|X|X| |-|

In the above example phases `A` and `D` conflict with one another and phase `B` conflicts with both phases `C` and `D`. This means that while phase `A` is green, all phases except `D` can be green too. If phase `B` is green, phase `A` may also be green, but `C` and `D` must be red. If `C` is green, then `A` and `D` can also be green, but `B` must be red. If `D` is green, then `C` can also be green, but neither `A`, nor `B` can be green.

#### Dummy Phases
In some cases, to achieve the form of traffic control envisaged by a traffic control engineer, it may be necessary to employ *dummy phases* which do not actually control traffic signals. These phases are introduced to invoke fictitious conflicts to ensure a particular combination of real signal phase greens or reds are achievable.

In many cases, dummy phases are used to force an *all-red* signal combination on street. In the example below, phase `E` is in conflict with all other phases. Therefore, when `E` is green, no other phase can be green (i.e. all other phases must be red). `E` itself, however, is not required to be associated with an actual traffic signal on street, making it a dummy phase.

| |A|B|C|D|E|
|-|-|-|-|-|-|
|A|-| | |X|X|
|B| |-|X|X|X|
|C| |X|-| |X|
|D|X|X| |-|X|
|E|X|X|X|X|-|

 This can be for regulatory reasons, which may specify that when a traffic signal controller is powered up, it must force all signals to go red and remain as such for a prescribed duration. It can also be for maintenance reasons. For example, an all-red signal combination can be activated to allow maintenance staff to enter the middle of a junction safely, and remain there for as long as necessary, by adjusting the duration of the all-red signal combination. Also, all-red can be used to cause deliberate delays, to road users, to allow any excess of vehicles still in the middle of the junction (perhaps due to a flow restriction downstream of their exit) to exit the junction before a conflicting phase is made to go green.

#### Minimum and Maximum Phase Green Durations
While a phase is green its conflicting phases will be red and road users whose signals these phases control will have to remain stationary. This obviously results in a delay to these road users and, when concerning vehicular traffic, secondary issues such as an increase in local pollution levels. Therefore, it is necessary that phases are not permitted to be green for unreasonable durations. To enforce this, phases may be given a maximum green duration limit within a traffic signal controller's specifications. Also, to ensure that road users have been given reasonable time to start moving into and exit the signal site, phases must remain green for a minimum duration before being permitted to be turned red again.

The minimum and maximum phase durations may be calculated by traffic control engineers, based on their knowledge of the shape and topology of traffic signal sites, may be dictated by regulation, or may be set due to a combination of both.

#### Intergreens
Where phases conflict, it is important that they are not permitted to be green at the same time. However, even when a phase goes red, its conflicting phases should not be permitted to go green immediately. This is to ensure that any traffic (including pedestrians) that is still within the conflicting space has safely cleared the area.

We have already discussed how all-red combination of signals can be employed to cause deliberate delays to allow traffic to clear a junction. However, using such signal combinations can be very wasteful in obtaining highest levels of traffic throughput, as even non-conflicting phases are forced to be red unnecessarily.

To define necessary safety-critical delays between phases going red and other (normally, conflicting) phases going green, phase *intergreens* are specified within traffic signal controllers' configuration parameters. Intergreens are defined as number of seconds of delay necessary to be implemented between a particular phase going red and another conflicting phase going green. Like minimum and maximum phase durations, intergreens can be defined based on the shape and topology of signal sites (and traffic speeds), by regulation, or a combination of both.

The following table shows the intergreen for the phases discussed earlier. The letter on each row defines the 'from' phase and the letter on each column defines the 'to' phase. Therefore, the numbers given at the intersection of the rows and columns define the intergreen durations (in seconds) that must be realised.

| |A|B|C|D|E|
|-|-|-|-|-|-|
|A|-| | |3|5|
|B| |-|3|3|5|
|C| |8|-| |5|
|D|9|9| |-|5|
|E|5|5|5|5|-|


Note that, where there is no phase conflict, there is no intergreen. Also, note that the value of the intergreens are not necessarily symmetrical along the diagonal (e.g. the `A` to `D` intergreen is not the same as the `D` to `A` intergreen). This is because some road users may require more time to clear the point of conflict than others. Let's assume that phase `A` and `B` are vehicular traffic phases, while `C` and `D` are pedestrian phases. As vehicles tend to move faster than pedestrians, the intergreen from a vehicular phase to the pedestrian phases can be short (3 seconds, in this example), while the intergreen from a pedestrian phase to a vehicular phase will need to be longer (8 and 9 seconds, in this example).

Note that the intergreen duration must include any regulatory signal states that denote the loss of right of way. As previously stated, in Britain, a green vehicular signal must be followed by 3 seconds of an amber signal, before going red. Therefore, the lowest possible intergreen value for a vehicular traffic phase is 3 seconds and lower values cannot be permitted. This is something that software used in designing, validating, and programming a traffic signal controller must check, based on the given phase types.

#### Variable Intergreens
Similarly to how an all-red signal combination may need to be extended to allow for traffic in the middle of a junction to safely clear points of conflict, integreen durations can be extended to realise the safe effect while avoiding the unnecessary delays that an all-read signal combination causes to road users that are not concerned.

Integreens are usually extended by installation of relevant detectors, whose output data can be monitored by a traffic signal controller to decided whether there is any need to extend an intergreen period for longer than the given minimum. For example, infra-red detectors installed at a pedestrian crossing for monitoring people in the road can provide data on whether any pedestrians are still crossing the road after the default intergreen period, from the pedestrian phase to a vehicular phase, has expired. The controller can then extend the integreen duration, by a calculated value, to ensure pedestrian safety.

Variable intergreens are denoted, within a traffic signal controller, by way of a second integreen table/matrix which specifies the maximum intergreen durations. The traffic signal controller will then ensure that any extensions granted do not exceed these limits. Where a maximum intergreen matches the default (or minimum) intergreen, the phase concerned does not have a variable intergreen. If we assume the following to be a maximum integreen table for the integreen table discussed above, only phases `C` and `D` (which we said were pedestrian phases) are permitted to have an extended intergreen before they go red and opposing vehicular phases go green.

| |A|B|C|D|E|
|-|-|-|-|-|-|
|A|-| | |3|5|
|B| |-|3|3|5|
|C| |15|-| |5|
|D|16|16| |-|5|
|E|5|5|5|5|-|

#### Stages
**TODO**

#### Phase Starting and Ending Delays
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
